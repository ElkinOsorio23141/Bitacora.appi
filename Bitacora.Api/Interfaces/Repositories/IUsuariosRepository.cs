using System.Collections.Generic;
using Bitacora.Api.Models;

namespace Bitacora.Api.Interfaces.Repositories
{
    public interface IUsuariosRepository:IRepository<Usuario>
    {
        public List<Usuario> GetAllUsuario();

        public int CrearUsuario(InsertarUsuarioParams usuario);
    }
}
