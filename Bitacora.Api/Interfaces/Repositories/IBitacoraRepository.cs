using System;
using System.Collections.Generic;
using Bitacora.Api.Models;

namespace Bitacora.Api.Interfaces.Repositories
{
    public interface IBitacoraRepository:IRepository<Caso>  
    {
        public List<Caso> GetAllCasosByFecha(DateTime FechaI, DateTime FechaF);

    }
}
