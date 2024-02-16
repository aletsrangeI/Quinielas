using Quinielas.Persistence.Context;
using Quinielas.Application.Interface.Persistence;

namespace Quinielas.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{
    public IUserRepository Users { get; }
    public IIndiceCatalogoRepository IndiceCatalogos { get; }

    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext, IUserRepository userRepository, IIndiceCatalogoRepository indiceCatalogoRepository)
    {
        _dbContext = dbContext;
        Users = userRepository;
        IndiceCatalogos = indiceCatalogoRepository;
    }

    public async Task<int> Save(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
