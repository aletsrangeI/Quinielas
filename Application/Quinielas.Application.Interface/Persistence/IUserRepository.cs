using Quinielas.Domain.Entities;

namespace Quinielas.Application.Interface.Persistence {
    public interface IUserRepository : IGenericRepository<User> {
        User Authenticate(string username, string password);
    }
}
