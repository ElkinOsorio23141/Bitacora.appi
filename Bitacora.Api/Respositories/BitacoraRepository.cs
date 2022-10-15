using Bitacora.Api.Interfaces.Repositories;
using Bitacora.Api.Models;
using Ekisa.Api.BotFetal.Repositories;
using System;
using System.Collections.Generic;
using Ekisa.Api.BotFetal.Models;
using Ekisa.Api.BotFetal.Models.Context;
using Microsoft.Extensions.Configuration;

namespace Bitacora.Api.Respositories
{
    public class BitacoraRepository : Repository<Caso>, IBitacoraRepository
    {
        private readonly CommandContext _commandContext;

        public BitacoraRepository(EkisaAppContext contextApp, IConfiguration configuration) : base(contextApp)
        {
            _commandContext = new CommandContext(configuration);
        }

        public List<Caso> GetAllCasosByFecha(DateTime FechaI, DateTime FechaF)
        {
            return new List<Caso>()
            {
              new Caso()
              {
                  IdCaso = 10
              }  
            };
        }
    }
}
