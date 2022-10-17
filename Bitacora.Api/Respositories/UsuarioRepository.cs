using System.Collections.Generic;
using Bitacora.Api.Interfaces.Repositories;
using Bitacora.Api.Interfaces.Services;
using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Models;
using Ekisa.Api.BotFetal.Models.Context;
using Ekisa.Api.BotFetal.Repositories;
using Microsoft.Extensions.Configuration;

namespace Bitacora.Api.Respositories
{
    public class UsuarioRepository:Repository<Usuario>, IUsuariosRepository
    {
        private readonly CommandContext _commandContext;

        public UsuarioRepository(EkisaAppContext contextApp, IConfiguration configuration) : base(contextApp)
        {
            _commandContext = new CommandContext(configuration);
        }

        public List<Usuario> GetAllUsuario()
        {
            var usuario = new Usuario()
            {
                IdUsuario = 1
            };

            var usuarioAdd = new List<Usuario>();
            usuarioAdd.Add(usuario);

            return usuarioAdd;
        }

    }
}
