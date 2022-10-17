using System.Linq;
using System.Threading.Tasks;
using Bitacora.Api.Interfaces.Services;
using Ekisa.Api.BotFetal.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Bitacora.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllCliente")]

        public async Task<ActionResult<Response>> GetAllCliente()
        {
            var response = _service.GetAllClientes();
            return new Response
            {
                IsSuccess = true,
                Message = response.Count() > 0 ? "Se consulto correctamente el cliente" : "No se encontraron registros",
                Result = response
            };
        }


    }
    
}
