using System;
using System.Threading.Tasks;
using Bitacora.Api.Interfaces.Services;
using Ekisa.Api.BotFetal.Configuration;
using Ekisa.Api.BotFetal.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bitacora.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : Controller
    {
        private readonly IBitacoraService _service;
        public BitacoraController(IBitacoraService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetAllCitasByFecha")]
        public async Task<ActionResult<Response>> GetAllCitasByFecha(DateTime FechaI, DateTime FechaF)
        {
            var response = _service.GetAllCasosByFecha(FechaI, FechaF);

            return new Response { IsSuccess = true, Message = response?.Count > 0 ? "Consulta realizada con éxito" : "No se obtuvieron resultados.", Result = response };
        }
    }
}
