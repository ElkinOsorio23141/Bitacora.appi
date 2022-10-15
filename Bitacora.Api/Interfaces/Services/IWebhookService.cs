using Ekisa.Api.BotFetal.Configuration;
using Ekisa.Api.BotFetal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekisa.Api.BotFetal.Interfaces.Services
{
    public interface IWebhookService
    {
        Task<Response> SendMessages(int IdCliente);
        Task<Response> ReceiveMessage(MessageReceived model);
    }
}
