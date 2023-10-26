using Empresa.Ecommerce.Persistence.Context;
using Quinielas.Application.Interface.Persistence;
using Quinielas.Domain.Entities;

namespace Quinielas.Persistence.Repositories;
public class UserRepository : IUserRepository
{

    protected readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #region  Metodos sincronos
    public User Authenticate(string username, string password)
    {
        User user = _dbContext.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);

        if (user == null) return null;

        return user;
    }

    public User Get(int id)
    {
        User user = _dbContext.Users.SingleOrDefault(x => x.UserId == id);

        if (user == null) return null;

        return user;
    }

    public bool Insert(User entity)
    {
        _dbContext.Users.Add(entity);

        return _dbContext.SaveChanges() > 0;
    }

    public bool Update(User entity)
    {
        _dbContext.Users.Update(entity);

        return _dbContext.SaveChanges() > 0;
    }

    public IEnumerable<User> GetAll()
    {
        IEnumerable<User> users = _dbContext.Users.ToList();

        return users;
    }

    public bool Delete(int id)
    {
        User user = _dbContext.Users.SingleOrDefault(x => x.UserId == id);

        if (user == null) return false;

        _dbContext.Users.Remove(user);

        return _dbContext.SaveChanges() > 0;
    }
    public IEnumerable<User> GetAllWithPagination(int page, int pageSize)
    {
        IEnumerable<User> users = _dbContext.Users.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return users;
    }
    public int Count()
    {
        return _dbContext.Users.Count();
    }
    
    #endregion
}
