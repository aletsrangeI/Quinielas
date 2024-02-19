namespace Quinielas.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task<int> Save(CancellationToken cancellationToken);
    }
}
