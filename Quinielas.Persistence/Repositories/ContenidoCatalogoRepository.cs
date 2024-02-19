using Quinielas.Application.Interface.Persistence;
using Quinielas.Domain.Entities;
using Quinielas.HttpHandler;
using Quinielas.Persistence.Context;

namespace Quinielas.Persistence.Repositories
{
    public class ContenidoCatalogoRepository : IContenidoCatalogoRepository
    {

        private readonly IHttpGetRepository _httpGetRepository;
        private readonly IRequestConfigurationStrategy _requestConfigurationStrategy;
        protected readonly ApplicationDbContext _dbContext;


        public ContenidoCatalogoRepository(IHttpGetRepository httpGetRepository, IRequestConfigurationStrategy requestConfigurationStrategy, ApplicationDbContext dbContext)
        {
            _httpGetRepository = httpGetRepository;
            _requestConfigurationStrategy = requestConfigurationStrategy;
            _dbContext = dbContext;
        }

        public int Count()
        {
            return _dbContext.ContenidoCatalogos.Count();

        }

        public bool Delete(int id)
        {
            ContenidoCatalogo contenidoCatalogo = _dbContext.ContenidoCatalogos.SingleOrDefault(x => x.Id == id);

            if (contenidoCatalogo == null) return false;

            _dbContext.ContenidoCatalogos.Remove(contenidoCatalogo);

            return _dbContext.SaveChanges() > 0;
        }

        public ContenidoCatalogo Get(int id)
        {
            ContenidoCatalogo contenidoCatalogo = _dbContext.ContenidoCatalogos.SingleOrDefault(x => x.Id == id);

            if (contenidoCatalogo == null) return null;

            return contenidoCatalogo;
        }

        public IEnumerable<ContenidoCatalogo> GetAll()
        {
            IEnumerable<ContenidoCatalogo> contenidoCatalogos = _dbContext.ContenidoCatalogos.ToList();

            return contenidoCatalogos;
        }

        public IEnumerable<ContenidoCatalogo> GetAllWithPagination(int page, int pageSize)
        {
            IEnumerable<ContenidoCatalogo> contenidoCatalogos = _dbContext.ContenidoCatalogos.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return contenidoCatalogos;
        }

        public bool Insert(ContenidoCatalogo entity)
        {

            _dbContext.ContenidoCatalogos.Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> LlenaLigaByDeporte(int IndiceCatalogoId)
        {

            var response = false;

            var headers = new Dictionary<string, string>
                {
                    {"x-rapidapi-host", "v1.american-football.api-sports.io"}
                };

            var result = await _httpGetRepository.GetAsync<ResponseLeaguesAF>("https://v1.american-football.api-sports.io/leagues", headers, null);
            var liga = result.response.FirstOrDefault(x => x.league.id == 1); // NFL

            ContenidoCatalogo contenidoCatalogo = new();

            contenidoCatalogo.IdCatalogo = IndiceCatalogoId;
            contenidoCatalogo.Descripcion = liga.league.name;

            if (Insert(contenidoCatalogo))
            {
                response = true;
            }
            return response;
        }

        public bool Update(ContenidoCatalogo entity)
        {
            _dbContext.ContenidoCatalogos.Update(entity);

            return _dbContext.SaveChanges() > 0;
        }
    }
}