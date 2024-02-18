using Quinielas.Application.DTO;
using Quinielas.Transversal.Common;

namespace Quinielas.Application.Interface.UseCases
{
    public interface IContenidoCatalogoApplication
    {
        Response<bool> Insert(ContenidoCatalogoDTO contenidoCatalogoDTO);

        Response<ContenidoCatalogoDTO> Get(int id);

        Response<IEnumerable<ContenidoCatalogoDTO>> GetAll();

        Response<bool> Delete(int id);

        Response<bool> Update(ContenidoCatalogoDTO contenidoCatalogoDTO);

        Response<IEnumerable<ContenidoCatalogoDTO>> GetAllWithPagination(int page, int pageSize);

        Response<int> Count();

        Task<Response<bool>> LlenaLigaByDeporte(int IndiceCatalogoId);
    }
}
