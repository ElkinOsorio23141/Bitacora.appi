using Bitacora.Api.Interfaces.Services;
using Bitacora.Api.Models;
using System;
using System.Collections.Generic;
using Bitacora.Api.Interfaces.Repositories;
using Ekisa.Api.BotFetal.Interfaces.Services.Common;
using Microsoft.Extensions.Configuration;

namespace Bitacora.Api.Services
{
    public class BitacoraService : IBitacoraService
    {
        private readonly IBitacoraRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IErrorLoggingDependency _errorLoggingDependency;
        public  BitacoraService(IBitacoraRepository repository, IConfiguration configuration, IErrorLoggingDependency errorLoggingDependency)
        {
            _repository = repository;
            _configuration = configuration;
            _errorLoggingDependency = errorLoggingDependency;
        }

        
        public List<Caso> GetAllCasosByFecha(DateTime FechaI, DateTime FechaF)
        {
            return _repository.GetAllCasosByFecha(FechaI, FechaF);
        }
    }
}
