using System.Collections.Generic;
using Bitacora.Api.Models;

namespace Bitacora.Api.Interfaces.Repositories
{
    public interface IClientesRepository:IRepository<Cliente>
    {
        public List<Cliente> GetAllClientes();
    }
}
