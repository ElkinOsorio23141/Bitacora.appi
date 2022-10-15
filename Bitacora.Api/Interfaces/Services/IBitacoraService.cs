using System;
using System.Collections.Generic;
using Bitacora.Api.Models;

namespace Bitacora.Api.Interfaces.Services
{
    public interface IBitacoraService
    {
        public List<Caso> GetAllCasosByFecha(DateTime FechaI, DateTime FechaF);
    }
}
