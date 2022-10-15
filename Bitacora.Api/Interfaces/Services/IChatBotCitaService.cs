using Ekisa.Api.BotFetal.Configuration;
using Ekisa.Api.BotFetal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekisa.Api.BotFetal.Interfaces.Services
{
    public interface IChatBotCitaService
    {
        Task<Response> GetAll();
        public List<ChatBotCita> GetAllCitasByFecha(DateTime FechaI, DateTime FechaF);
        public int ConfirmarCita(decimal numeroOrden);
        public int CancelarCita(decimal numeroOrden);
    }
}
