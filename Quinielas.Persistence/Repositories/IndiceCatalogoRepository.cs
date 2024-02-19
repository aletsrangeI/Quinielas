using Quinielas.Application.Interface.Persistence;
using Quinielas.Domain.Entities;
using Quinielas.Persistence.Context;

namespace Quinielas.Persistence.Repositories
{
    public class IndiceCatalogoRepository : IIndiceCatalogoRepository
    {

        protected readonly ApplicationDbContext _dbContext;

        public IndiceCatalogoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Count()
        {
            return _dbContext.IndiceCatalogos.Count();
        }

        public bool Delete(int id)
        {
            IndiceCatalogo indiceCatalogo = _dbContext.IndiceCatalogos.SingleOrDefault(x => x.Id == id);

            if (indiceCatalogo == null) return false;

            _dbContext.IndiceCatalogos.Remove(indiceCatalogo);

            return _dbContext.SaveChanges() > 0;
        }

        public IndiceCatalogo Get(int id)
        {
            IndiceCatalogo indiceCatalogo = _dbContext.IndiceCatalogos.SingleOrDefault(x => x.Id == id);

            if (indiceCatalogo == null) return null;

            return indiceCatalogo;
        }

        public IEnumerable<IndiceCatalogo> GetAll()
        {
            IEnumerable<IndiceCatalogo> indiceCatalogos = _dbContext.IndiceCatalogos.ToList();

            return indiceCatalogos;
        }

        public IEnumerable<IndiceCatalogo> GetAllWithPagination(int page, int pageSize)
        {
            IEnumerable<IndiceCatalogo> indiceCatalogos = _dbContext.IndiceCatalogos.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return indiceCatalogos;
        }

        public bool Insert(IndiceCatalogo entity)
        {

            _dbContext.IndiceCatalogos.Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(IndiceCatalogo entity)
        {
            _dbContext.IndiceCatalogos.Update(entity);

            return _dbContext.SaveChanges() > 0;
        }
    }
}
