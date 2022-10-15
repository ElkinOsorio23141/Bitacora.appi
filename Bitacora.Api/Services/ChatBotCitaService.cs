using Ekisa.Api.BotFetal.Configuration;
using Ekisa.Api.BotFetal.Interfaces;
using Ekisa.Api.BotFetal.Interfaces.Services;
using Ekisa.Api.BotFetal.Interfaces.Services.Common;
using Ekisa.Api.BotFetal.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ekisa.Api.BotFetal.Services.Ínfraestructure;

namespace Ekisa.Api.BotFetal.Services
{
    public class ChatBotCitaService : IChatBotCitaService
    {
        private readonly IChatBotCitaRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IErrorLoggingDependency _errorLoggingDependency;
        //private readonly IMessage _message;

        public Messages Message { get; private set; }
        public ChatBotCitaService(IChatBotCitaRepository repository, IConfiguration configuration, IErrorLoggingDependency errorLoggingDependency)
        {
            _repository = repository;
            _configuration = configuration;
            _errorLoggingDependency = errorLoggingDependency;
            //_message = message;
        }
        public async Task<Response> GetAll()
        {
            try
            {
                var citas = _repository.GetAll();
                return new Response { IsSuccess = true, Message = "OK", Result = citas };
            }
            catch (Exception ex)
            {
                _errorLoggingDependency.Report(ex);
            }
            return null;

        }
 
        public List<ChatBotCita> GetAllCitasByFecha(DateTime FechaI,
            DateTime FechaF)
        {
            //Message = _message.Success();
            return _repository.GetAllCitasByFecha(FechaI, FechaF);
        }

        public int ConfirmarCita(decimal numeroOrden)
        {
            int dto = 0;
            try
            {
                dto = _repository.ConfirmarCita(numeroOrden);
                //Message = _message.Success();

            }
            catch (Exception ex)
            {
                //Message = _message.Exception(ex.Message);
            }

            return dto;

        }

        public int CancelarCita(decimal numeroOrden)
        {
            int dto = 0;
            try
            {
                dto = _repository.CancelarCita(numeroOrden);
                //Message = _message.Success();

            }
            catch (Exception ex)
            {
                //Message = _message.Exception(ex.Message);
            }

            return dto;
        }
    }
}