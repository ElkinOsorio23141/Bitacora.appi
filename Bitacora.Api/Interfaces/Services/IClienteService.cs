using System.Collections.Generic;
using Bitacora.Api.Models;

namespace Bitacora.Api.Interfaces.Services
{
    public interface IClienteService
    {
        public List<Cliente> GetAllClientes();

        public int CrearCliente(InsertarClienteParams cliente);
    }
}
