using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Interfaces.Repositories;
using System.Collections.Generic;
using System;

namespace Bitacora.Api.Interfaces.Repositories
{
    public interface IEmpleadosRepository:IRepository<Empleado>
    {
        public List<Empleado> GetAllEmpleado();
    }
}
