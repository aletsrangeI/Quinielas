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
                var transaccion = _unitOfWork.IndiceCatalogos.Insert(indiceCatalogo);

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

        public Response<IndiceCatalogoDTO> Get(int id)
        {
            var response = new Response<IndiceCatalogoDTO>();

            try
            {
                var indiceCatalogo = _unitOfWork.IndiceCatalogos.Get(id);
                response.Data = _mapper.Map<IndiceCatalogoDTO>(indiceCatalogo);

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

        public Response<IEnumerable<IndiceCatalogoDTO>> GetAll()
        {
            var response = new Response<IEnumerable<IndiceCatalogoDTO>>();

            try
            {
                var indiceCatalogos = _unitOfWork.IndiceCatalogos.GetAll();
                response.Data = _mapper.Map<IEnumerable<IndiceCatalogoDTO>>(indiceCatalogos);

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
                var transaccion = _unitOfWork.IndiceCatalogos.Delete(id);


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

        public Response<bool> Update(IndiceCatalogoDTO indiceCatalogoDTO)
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
                var transaccion = _unitOfWork.IndiceCatalogos.Update(indiceCatalogo);

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

        public Response<IEnumerable<IndiceCatalogoDTO>> GetAllWithPagination(int page, int pageSize)
        {
            var response = new Response<IEnumerable<IndiceCatalogoDTO>>();

            try
            {
                var indiceCatalogos = _unitOfWork.IndiceCatalogos.GetAllWithPagination(page, pageSize);
                response.Data = _mapper.Map<IEnumerable<IndiceCatalogoDTO>>(indiceCatalogos);

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
                var transaccion = _unitOfWork.IndiceCatalogos.Count();
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
    }
}
