using Bitacora.Api.Models;
using System.Collections.Generic;
using System;

namespace Bitacora.Api.Interfaces.Repositories
{
    public interface IEmpleadosRepository:IRepository<Empleado>
    {
        public List<Empleado> GetAllEmpleado();
    }
}
