using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekisa.Api.BotFetal.Models
{
    public class MessageReceived
    {
        public string From { get; set; }
        public string Body { get; set; }
        public int ChatbotId { get; set; }
        
    }
}
