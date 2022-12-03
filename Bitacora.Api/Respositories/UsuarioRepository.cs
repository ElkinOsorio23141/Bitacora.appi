using System;
using System.Collections.Generic;
using Bitacora.Api.Interfaces.Repositories;
using Bitacora.Api.Interfaces.Services;
using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Models;
using Ekisa.Api.BotFetal.Models.Context;
using Ekisa.Api.BotFetal.Repositories;
using Ekisa.Api.BotFetal.Services.Common;
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

        public int CrearUsuario(InsertarUsuarioParams usuario)
        {
            try
            {
                var command = _commandContext.DbContext;
                var result = command.ExecuteNonQuery("spInsertarUsuarios",
                    new[]
                    {
                        new ParameterCommon
                            { Name = "@CodigoUsuario", Value = usuario.CodigoUsuario.ToString() },
                        new ParameterCommon
                            { Name = "@NombreUsuario", Value = usuario.NombreUsuario.ToString() },
                        new ParameterCommon
                            { Name = "@ClaveUsuario", Value = usuario.ClaveUsuario.ToString() },
                        new ParameterCommon
                            { Name = "@IdEmpleado", Value = usuario.IdEmpleado.ToString() },
                        new ParameterCommon
                            { Name = "@IdPerfil", Value = usuario.IdPerfil.ToString() },
                        new ParameterCommon
                            { Name = "@Estado", Value = usuario.Estado.ToString() },

                    });

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else { return 0; }
            }
            catch (Exception ex) { return 0; }
        }



    }
}
