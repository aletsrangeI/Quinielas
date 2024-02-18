using Quinielas.Application.DTO;
using Quinielas.Transversal.Common;

namespace Quinielas.Application.Interface.UseCases
{
    public interface IIndiceCatalogoApplication
    {
        Response<bool> Insert(IndiceCatalogoDTO indiceCatalogoDTO);

        Response<IndiceCatalogoDTO> Get(int id);

        Response<IEnumerable<IndiceCatalogoDTO>> GetAll();

        Response<bool> Delete(int id);

        Response<bool> Update(IndiceCatalogoDTO indiceCatalogoDTO);

        Response<IEnumerable<IndiceCatalogoDTO>> GetAllWithPagination(int page, int pageSize);

        Response<int> Count();
    }
}
