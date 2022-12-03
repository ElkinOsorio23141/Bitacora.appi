using System.Collections.Generic;
using Bitacora.Api.Models;

namespace Bitacora.Api.Interfaces.Services
{
    public interface IUsuarioService
    {
        public List<Usuario> GetAllUsuario();

        public int CrearUsuario(InsertarUsuarioParams usuario);
    }
}
