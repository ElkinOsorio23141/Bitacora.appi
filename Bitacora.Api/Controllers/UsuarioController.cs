using System.Linq;
using System.Threading.Tasks;
using Bitacora.Api.Interfaces.Services;
using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Bitacora.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service; 
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllUsuario")]

        public async Task<ActionResult<Response>> GetAllUsuario()
        {
            var response = _service.GetAllUsuario();
            return new Response
            {
                IsSuccess = true,
                Message = response.Count() > 0 ? "Se consultó correctamente" : "No se encontraron registros",
                Result = response
            };
        }

        [HttpPost]
        [Route("PostCrearUsuario")]
        public async Task<ActionResult<Response>> PostCrearUsuario(InsertarUsuarioParams usuario)
        {
            var response = _service.CrearUsuario(usuario);
            return new Response
            {
                IsSuccess = true,
                Message = response > 0 ? "Se insertó correctamente" : "No se insertaron registros",
                Result = response
            };

        }
    }
}
