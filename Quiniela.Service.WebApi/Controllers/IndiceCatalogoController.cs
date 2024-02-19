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
    public class IndiceCatalogoController : Controller
    {
        private readonly IIndiceCatalogoApplication _indiceCatalogosApplication;
        private readonly AppSettings _appSettings;

        public IndiceCatalogoController(
            IIndiceCatalogoApplication indiceCatalogosApplication, IOptions<AppSettings> appSettings)
        {
            _indiceCatalogosApplication = indiceCatalogosApplication;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
        [HttpPost, ActionName("Create")]
        public IActionResult Create([FromBody] IndiceCatalogoDTO indiceCatalogoDto)
        {
            var response = _indiceCatalogosApplication.Insert(indiceCatalogoDto);

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost, ActionName("Update")]
        public IActionResult Update([FromBody] IndiceCatalogoDTO indiceCatalogoDto)
        {
            var response = _indiceCatalogosApplication.Update(indiceCatalogoDto);

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete([FromBody] int id)
        {
            var response = _indiceCatalogosApplication.Delete(id);

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet, ActionName("Get")]
        public IActionResult Get([FromBody] int id)
        {
            var response = _indiceCatalogosApplication.Get(id);

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet, ActionName("GetAll")]
        public IActionResult GetAll()
        {
            var response = _indiceCatalogosApplication.GetAll();

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }


        [HttpGet, ActionName("GetAllWithPagination")]
        public IActionResult GetAllWithPagination([FromBody]int page, int pageSize)
        {
            var response = _indiceCatalogosApplication.GetAllWithPagination(page, pageSize);

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }


        [HttpGet, ActionName("Count")]
        public IActionResult Count()
        {
            var response = _indiceCatalogosApplication.Count();

            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }

    }
}
