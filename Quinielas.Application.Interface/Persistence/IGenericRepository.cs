namespace Quinielas.Application.Interface.Persistence
{
    public interface IGenericRepository<T>
        where T : class
    {
        #region Metodos Sincronos
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithPagination(int page, int pageSize);
        int Count();
        #endregion
    }
}
