using AutoMapper;
using Quinielas.Application.DTO;
using Quinielas.Application.Interface.Persistence;
using Quinielas.Application.Interface.UseCases;
using Quinielas.Application.Validator;
using Quinielas.Transversal.Common;

namespace Quinielas.Application.UseCases.ContenidoCatalogos
{
    public class ContenidoCatalogoApplication : IContenidoCatalogoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ContenidoCatalogoDTOValidator _contenidoCatalogoDtoValidator;

        public ContenidoCatalogoApplication(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ContenidoCatalogoDTOValidator contenidoCatalogoDtoValidator
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contenidoCatalogoDtoValidator = contenidoCatalogoDtoValidator;
        }


        public Response<bool> Insert(ContenidoCatalogoDTO contenidoCatalogoDTO)
        {
            var response = new Response<bool>();
            var validation = _contenidoCatalogoDtoValidator.Validate(contenidoCatalogoDTO);

            if (!validation.IsValid)
            {
                response.Message = "Errores de validacion";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var ContenidoCatalogo = _mapper.Map<Domain.Entities.ContenidoCatalogo>(contenidoCatalogoDTO);
                var transaccion = _unitOfWork.ContenidoCatalogos.Insert(ContenidoCatalogo);

                if (transaccion)
                {
                    response.Data = true;
                    response.isSuccess = true;
                    response.Message = "Registro Agregado";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<ContenidoCatalogoDTO> Get(int id)
        {
            var response = new Response<ContenidoCatalogoDTO>();

            try
            {
                var ContenidoCatalogo = _unitOfWork.ContenidoCatalogos.Get(id);
                response.Data = _mapper.Map<ContenidoCatalogoDTO>(ContenidoCatalogo);

                if (response.Data != null)
                {
                    response.isSuccess = true;
                    response.Message = "Consulta Exitosa";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<ContenidoCatalogoDTO>> GetAll()
        {
            var response = new Response<IEnumerable<ContenidoCatalogoDTO>>();

            try
            {
                var ContenidoCatalogos = _unitOfWork.ContenidoCatalogos.GetAll();
                response.Data = _mapper.Map<IEnumerable<ContenidoCatalogoDTO>>(ContenidoCatalogos);

                if (response.Data != null)
                {
                    response.isSuccess = true;
                    response.Message = "Consulta Exitosa";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Delete(int id)
        {
            var response = new Response<bool>();

            try
            {
                var transaccion = _unitOfWork.ContenidoCatalogos.Delete(id);


                if (transaccion)
                {
                    response.Data = true;
                    response.isSuccess = true;
                    response.Message = "Registro eliminado";
                }
            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<bool> Update(ContenidoCatalogoDTO contenidoCatalogoDTO)
        {
            var response = new Response<bool>();
            var validation = _contenidoCatalogoDtoValidator.Validate(contenidoCatalogoDTO);

            if (!validation.IsValid)
            {
                response.Message = "Errores de validacion";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var contenidoCatalogo = _mapper.Map<Domain.Entities.ContenidoCatalogo>(contenidoCatalogoDTO);
                var transaccion = _unitOfWork.ContenidoCatalogos.Update(contenidoCatalogo);

                if (transaccion)
                {
                    response.Data = true;
                    response.isSuccess = true;
                    response.Message = "Registro Actualizado";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<ContenidoCatalogoDTO>> GetAllWithPagination(int page, int pageSize)
        {
            var response = new Response<IEnumerable<ContenidoCatalogoDTO>>();

            try
            {
                var ContenidoCatalogos = _unitOfWork.ContenidoCatalogos.GetAllWithPagination(page, pageSize);
                response.Data = _mapper.Map<IEnumerable<ContenidoCatalogoDTO>>(ContenidoCatalogos);

                if (response.Data != null)
                {
                    response.isSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public Response<int> Count()
        {
            var response = new Response<int>();

            try
            {
                var transaccion = _unitOfWork.ContenidoCatalogos.Count();
                response.Data = transaccion;
                response.isSuccess = true;
                response.Message = "Registros";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> LlenaLigaByDeporte(int IndiceCatalogoId)
        {
            var response = new Response<bool>();

            try
            {
                var transaccion = await _unitOfWork.ContenidoCatalogos.LlenaLigaByDeporte(IndiceCatalogoId);
                response.Data = transaccion;
                response.isSuccess = true;
                response.Message = "Registro Actualizado";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}