using Quinielas.Domain.Entities;

namespace Quinielas.Application.Interface.Persistence
{
    public interface IContenidoCatalogoRepository : IGenericRepository<ContenidoCatalogo>
    {
        Task<bool> LlenaLigaByDeporte(int IndiceCatalogoId);
    }
}