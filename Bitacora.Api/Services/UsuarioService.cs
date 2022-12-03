using System.Collections.Generic;
using Bitacora.Api.Interfaces.Repositories;
using Bitacora.Api.Interfaces.Services;
using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Interfaces.Services.Common;
using Microsoft.Extensions.Configuration;

namespace Bitacora.Api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuariosRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IErrorLoggingDependency _errorLoggingDependency;

        public UsuarioService(IUsuariosRepository repository, IConfiguration configuration, IErrorLoggingDependency errorLoggingDependency)
        {
            _repository = repository;
            _configuration = configuration;
            _errorLoggingDependency = errorLoggingDependency;
        }

        public List<Usuario> GetAllUsuario()
        {
            return _repository.GetAllUsuario();
        }

        public int CrearUsuario(InsertarUsuarioParams usuario)
        {
            return _repository.CrearUsuario(usuario);
        }

    }
}
