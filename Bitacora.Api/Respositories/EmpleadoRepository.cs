using Bitacora.Api.Interfaces.Repositories;
using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Models.Context;
using Ekisa.Api.BotFetal.Repositories;
using System.Collections.Generic;
using Ekisa.Api.BotFetal.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Ekisa.Api.BotFetal.Services.Common;
using System;
using Newtonsoft.Json.Linq;

namespace Bitacora.Api.Respositories
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadosRepository
    {
        private readonly CommandContext _commandContext;


        public EmpleadoRepository(EkisaAppContext contextApp, IConfiguration configuration) : base(contextApp)
        {
            _commandContext = new CommandContext(configuration);
        }

        public List<Empleado> GetAllEmpleado()
        {
            var empleado = new Empleado()
            {
                IdEmpleado = 1
            };
            var empleadosAdd = new List<Empleado>();
            empleadosAdd.Add(empleado);

            return empleadosAdd;
        }


        public int CrearEmpleado(InsertarEmpleadoParams empleado)
        {
            try
            {
                var command = _commandContext.DbContext;
                var result = command.ExecuteNonQuery("spInsertarEmpleado",
                    new[]
                    {
                        new ParameterCommon
                            { Name = "@Identificacion", Value = empleado.Identificacion.ToString() },
                        new ParameterCommon
                            { Name = "@IdTipoIdentificacion", Value = empleado.IdTipoIdentificacion },
                        new ParameterCommon
                            { Name = "@PrimerNombre", Value = empleado.PrimerNombre.ToString() },
                        new ParameterCommon
                            { Name = "@SegundoNombre", Value = empleado.SegundoNombre.ToString() },
                        new ParameterCommon
                            { Name = "@PrimerApellido", Value = empleado.PrimerApellido.ToString() },
                        new ParameterCommon
                            { Name = "@SegundoApellido", Value = empleado.SegundoApellido.ToString() },
                        new ParameterCommon
                            { Name = "@Sexo", Value = empleado.Sexo.ToString() },
                        new ParameterCommon
                            { Name = "@FechaNacimiento", Value = empleado.FechaNacimiento },
                        new ParameterCommon
                            { Name = "@Direccion", Value = empleado.Direccion.ToString() },
                        new ParameterCommon
                            { Name = "@Telefono", Value = empleado.Telefono.ToString() },
                        new ParameterCommon
                            { Name = "@Celular", Value = empleado.Celular.ToString() },
                        new ParameterCommon
                            { Name = "@Correo", Value = empleado.Correo.ToString() },
                        new ParameterCommon
                            { Name = "@Estado", Value = empleado.Estado.ToString() },

                    });

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else { return 0; }
            }
            catch (Exception ex) { return 0; }
        }

        public int EliminarEmpleado(Empleado IdentificacionEmpleado)
        {
            try
            {
                var command = _commandContext.DbContext;
                var result = command.ExecuteNonQuery("spEliminarEmpleado",
                    new[]
                    {
                        new ParameterCommon
                            { Name = "@Identificacion",  Value = IdentificacionEmpleado.ToString() },

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
