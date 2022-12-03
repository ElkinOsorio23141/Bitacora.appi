using System;
using System.Collections.Generic;
using Bitacora.Api.Interfaces.Repositories;
using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Models;
using Ekisa.Api.BotFetal.Models.Context;
using Ekisa.Api.BotFetal.Repositories;
using Ekisa.Api.BotFetal.Services.Common;
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

        public int CrearCliente(InsertarClienteParams cliente)
        {
            try
            {
                var command = _commandContext.DbContext;
                var result = command.ExecuteNonQuery("spInsertarCliente",
                    new[]
                    {
                        new ParameterCommon
                            { Name = "@IdentificacionCliente", Value = cliente.IdentificacionCliente.ToString() },
                        new ParameterCommon
                            { Name = "@IdTipoIdentificacion", Value = cliente.IdTipoIdentificacion },
                        new ParameterCommon
                            { Name = "@NombreCliente", Value = cliente.NombreCliente.ToString() },
                        new ParameterCommon
                            { Name = "@DirecionCliente", Value = cliente.DirecionCliente.ToString() },
                        new ParameterCommon
                            { Name = "@CodigoCiudad", Value = cliente.CodigoCiudad.ToString() },
                        new ParameterCommon
                            { Name = "@TelefonoCliente", Value = cliente.TelefonoCliente.ToString() },
                        new ParameterCommon
                            { Name = "@CorreoCliente", Value = cliente.CorreoCliente.ToString() },
                        new ParameterCommon
                            { Name = "@Observacion", Value = cliente.Observacion.ToString() },
                        new ParameterCommon
                            { Name = "@EstadoCliente", Value = cliente.EstadoCliente },
                        new ParameterCommon
                            { Name = "@Poliza", Value = cliente.Poliza.ToString() },
                        new ParameterCommon
                            { Name = "@FechaVencePoliza", Value = cliente.FechaVencePoliza },
                        new ParameterCommon
                            { Name = "@NotaPoliza", Value = cliente.NotaPoliza.ToString() },
                        new ParameterCommon
                            { Name = "@TipoCliente", Value = cliente.TipoCliente.ToString() },

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
