using Quinielas.Application.DTO;
using Quinielas.Transversal.Common;

namespace Quinielas.Application.Interface.UseCases
{
    public interface IIndiceCatalogoApplication
    {
        Response<bool> Insert(IndiceCatalogoDTO indiceCatalogoDTO);
    }
}
