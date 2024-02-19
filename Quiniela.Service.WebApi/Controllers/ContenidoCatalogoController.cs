using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiniela.Service.WebApi.Helpers;
using Quinielas.Application.DTO;
using Quinielas.Application.Interface.UseCases;
using Microsoft.Extensions.Options;

namespace Quiniela.Service.WebApi
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContenidoCatalogoController : Controller
    {
        private readonly IContenidoCatalogoApplication _contenidoCatalogosApplication;
        private readonly AppSettings _appSettings;

        public ContenidoCatalogoController(
            IContenidoCatalogoApplication contenidoCatalogosApplication, IOptions<AppSettings> appSettings)
        {
            _contenidoCatalogosApplication = contenidoCatalogosApplication;
            _appSettings = appSettings.Value;
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Create([FromBody] ContenidoCatalogoDTO indiceCatalogoDto)
        {
            var response = _contenidoCatalogosApplication.Insert(indiceCatalogoDto);

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost, ActionName("Update")]
        public IActionResult Update([FromBody] ContenidoCatalogoDTO indiceCatalogoDto)
        {
            var response = _contenidoCatalogosApplication.Update(indiceCatalogoDto);

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete([FromBody] int id)
        {
            var response = _contenidoCatalogosApplication.Delete(id);

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet, ActionName("Get")]
        public IActionResult Get([FromBody] int id)
        {
            var response = _contenidoCatalogosApplication.Get(id);

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet, ActionName("GetAll")]
        public IActionResult GetAll()
        {
            var response = _contenidoCatalogosApplication.GetAll();

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }


        [HttpGet, ActionName("GetAllWithPagination")]
        public IActionResult GetAllWithPagination([FromBody] int page, int pageSize)
        {
            var response = _contenidoCatalogosApplication.GetAllWithPagination(page, pageSize);

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }


        [HttpGet, ActionName("Count")]
        public IActionResult Count()
        {
            var response = _contenidoCatalogosApplication.Count();

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost, ActionName("FillFootballLeagues")]
        public IActionResult FillFootballLeagues(int IdCatalogo)
        {
            var response = _contenidoCatalogosApplication.LlenaLigaByDeporte(IdCatalogo);
            if (!response.IsFaulted) return BadRequest(response);

            return Ok(response);
        }
    }
}
