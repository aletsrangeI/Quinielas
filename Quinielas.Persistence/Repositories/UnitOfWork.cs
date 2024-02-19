using Empresa.Ecommerce.Persistence.Context;
using Quinielas.Application.Interface.Persistence;

namespace Quinielas.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{
    public IUserRepository Users { get; }

    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext, IUserRepository userRepository)
    {
        _dbContext = dbContext;
        Users = userRepository;
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
