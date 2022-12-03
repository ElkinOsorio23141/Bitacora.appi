using Bitacora.Api.Models;
using System.Collections.Generic;

namespace Bitacora.Api.Interfaces.Services
{
    public interface IEmpleadoService
    {
        public List<Empleado> GetAllEmpleado();

        public int CrearEmpleado(InsertarEmpleadoParams empleado);
    }
}
