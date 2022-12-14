using System.Linq;
using System.Threading.Tasks;
using Bitacora.Api.Interfaces.Services;
using Ekisa.Api.BotFetal.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Bitacora.Api.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _service;

        public EmpleadoController(IEmpleadoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllEmpleado")]

        public async Task<ActionResult<Response>> GetAllEmpleado()
        {
            var response = _service.GetAllEmpleado();
            return new Response
            {
                IsSuccess = true,
                Message = response.Count() > 0 ? "Se consultó correctamente" : "No se encontraron registros",
                Result = response
            };
        }
    }
}
