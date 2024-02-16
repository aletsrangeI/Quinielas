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

    }
}
