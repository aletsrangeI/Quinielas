namespace Quinielas.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IIndiceCatalogoRepository IndiceCatalogos { get; }
        IContenidoCatalogoRepository ContenidoCatalogos { get; }
        Task<int> Save(CancellationToken cancellationToken);
    }
}
