using System.Collections.Generic;
using Bitacora.Api.Interfaces.Repositories;
using Bitacora.Api.Interfaces.Services;
using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Interfaces.Services.Common;
using Microsoft.Extensions.Configuration;

namespace Bitacora.Api.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadosRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IErrorLoggingDependency _errorLoggingDependency;


        public EmpleadoService(IEmpleadosRepository repository, IConfiguration configuration, IErrorLoggingDependency errorLoggingDependency)
        {
            _repository = repository;
            _configuration = configuration;
            _errorLoggingDependency = errorLoggingDependency;
        }


        public List<Empleado> GetAllEmpleado()
        {
            return _repository.GetAllEmpleado();
        }

        public int CrearEmpleado(InsertarEmpleadoParams empleado)
        {
            return _repository.CrearEmpleado(empleado);
        }

        public int EliminarEmpleado(Empleado IdentificacionEmpleado)
        {
            return _repository.EliminarEmpleado(IdentificacionEmpleado);
        }

    }
}
