using Quinielas.Application.Interface.Persistence;
using Quinielas.Domain.Entities;

namespace Quinielas.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    public User Authenticate(string username, string password)
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }

    public bool Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public User Get(string id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAllWithPagination(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllWithPaginationAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public bool Insert(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
