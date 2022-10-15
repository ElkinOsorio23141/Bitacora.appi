using Ekisa.Api.BotFetal.Configuration;
using Ekisa.Api.BotFetal.Interfaces.Services;
using Ekisa.Api.BotFetal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekisa.Api.BotFetal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotCitaController : ControllerBase
    {
        private readonly IChatBotCitaService _service;
        private readonly IWebhookService _webHookService;

        public ChatBotCitaController(IChatBotCitaService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetAllCitasByFecha")]
        public async Task<ActionResult<Response>> GetAllCitasByFecha(DateTime FechaI, DateTime FechaF)
        {
            var response = _service.GetAllCitasByFecha(FechaI, FechaF);

            return new Response { IsSuccess = true, Message = response?.Count > 0 ? "Consulta realizada con éxito" : "No se obtuvieron resultados.", Result = response };
        }
        [HttpGet]
        [Route("ConfirmarCita")]
        public async Task<ActionResult<Response>> ConfirmarCita(decimal numeroCita)
        {
            var response = _service.ConfirmarCita(numeroCita);

            return new Response { IsSuccess = true, Message = response > 0 ? "Cita Confirmada con éxito." : "No se confirmo la cita.", Result = response };
        }
        [HttpGet]
        [Route("CancelarCita")]
        public async Task<ActionResult<Response>> CancelarCita(decimal numeroCita)
        {
            var response = _service.CancelarCita(numeroCita);

            return new Response { IsSuccess = true, Message = response > 0 ? "Cita Cancelada con éxito." : "No se canceló la cita.", Result = response };
        }
    }
}
