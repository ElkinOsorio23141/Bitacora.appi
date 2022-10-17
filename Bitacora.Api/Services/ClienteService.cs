using System.Collections.Generic;
using Bitacora.Api.Interfaces.Repositories;
using Bitacora.Api.Interfaces.Services;
using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Interfaces.Services.Common;
using Microsoft.Extensions.Configuration;

namespace Bitacora.Api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClientesRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IErrorLoggingDependency _errorLoggingDependency;

        public ClienteService(IClientesRepository repository, IConfiguration configuration, IErrorLoggingDependency errorLoggingDependency)
        {
            _repository = repository;
            _configuration = configuration;
            _errorLoggingDependency = errorLoggingDependency;
        }

        public List<Cliente> GetAllClientes()
        {
            return _repository.GetAllClientes();
        }
    }
}
