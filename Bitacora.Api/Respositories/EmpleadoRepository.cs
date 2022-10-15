using Bitacora.Api.Interfaces.Repositories;
using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Models.Context;
using Ekisa.Api.BotFetal.Repositories;
using System.Collections.Generic;
using Ekisa.Api.BotFetal.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

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
    }
}
