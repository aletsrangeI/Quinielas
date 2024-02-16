using AutoMapper;
using Quinielas.Application.DTO;
using Quinielas.Application.Interface.Persistence;
using Quinielas.Application.Interface.UseCases;
using Quinielas.Application.Validator;
using Quinielas.Transversal.Common;

namespace Quinielas.Application.UseCases.IndiceCatalogos
{
    public class IndiceCatalogosApplication : IIndiceCatalogoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IndiceCatalogoDTOValidator _indiceCatalogoDtoValidator;

        public IndiceCatalogosApplication(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IndiceCatalogoDTOValidator indiceCatalogoDtoValidator
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _indiceCatalogoDtoValidator = indiceCatalogoDtoValidator;
        }

        public Response<bool> Insert(IndiceCatalogoDTO indiceCatalogoDTO)
        {
            var response = new Response<bool>();
            var validation = _indiceCatalogoDtoValidator.Validate(indiceCatalogoDTO);

            if (!validation.IsValid)
            {
                response.Message = "Errores de validacion";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var indiceCatalogo = _mapper.Map<Domain.Entities.IndiceCatalogo>(indiceCatalogoDTO);
                _unitOfWork.IndiceCatalogos.Insert(indiceCatalogo);
                response.Data = true;
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
