using AutoMapper;
using Quinielas.Application.DTO;
using Quinielas.Application.Interface.Persistence;
using Quinielas.Application.Interface.UseCases;
using Quinielas.Application.Validator;
using Quinielas.Transversal.Common;

namespace Quinielas.Application.UseCases.Users
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UsersDTOValidator _usersDtoValidator;

        public UsersApplication(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UsersDTOValidator usersDtoValidator
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _usersDtoValidator = usersDtoValidator;
        }

        public Response<UserDTO> Authenticate(string username, string password)
        {
            var response = new Response<UserDTO>();
            var validation = _usersDtoValidator.Validate(
                new UserDTO { UserName = username, Password = password }
            );

            if (!validation.IsValid)
            {
                response.Message = "Errores de validacion";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var user = _unitOfWork.Users.Authenticate(username, password);
                response.Data = _mapper.Map<UserDTO>(user);
                response.isSuccess = true;
                response.Message = "Autenticación exitosa";
            }
            catch (InvalidOperationException) // Esto es propio de dapper sucede cuando no se puede mapear el resultado de la consulta a un objeto
            {
                response.isSuccess = false;
                response.Message = "El usuario no existe";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<UserDTO> Agregar(UserDTO userDTO)
        {
            var response = new Response<UserDTO>();
            var validation = _usersDtoValidator.Validate(userDTO);

            if (!validation.IsValid)
            {
                response.Message = "Errores de validacion";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var user = _mapper.Map<Domain.Entities.User>(userDTO);
                _unitOfWork.Users.Insert(user);
                response.Data = _mapper.Map<UserDTO>(user);
                response.isSuccess = true;
                response.Message = "Usuario creado exitosamente";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
