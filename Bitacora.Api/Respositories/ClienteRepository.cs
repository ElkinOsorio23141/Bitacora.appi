using System.Collections.Generic;
using Bitacora.Api.Interfaces.Repositories;
using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Models;
using Ekisa.Api.BotFetal.Models.Context;
using Ekisa.Api.BotFetal.Repositories;
using Microsoft.Extensions.Configuration;

namespace Bitacora.Api.Respositories
{
    public class ClienteRepository: Repository<Cliente>, IClientesRepository
    {
        private readonly CommandContext _commandContext;

        public ClienteRepository(EkisaAppContext contextapp, IConfiguration configuration) : base(contextapp)
        {
            _commandContext = new CommandContext(configuration);
        }

        public List<Cliente> GetAllClientes()
        {
            var cliente = new Cliente()
            {
                Idcliente = 1
            };

            var clientesAdd = new List<Cliente>();
            clientesAdd.Add(cliente);

            return clientesAdd;
        }


    }
}
