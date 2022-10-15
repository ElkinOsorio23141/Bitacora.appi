using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekisa.Api.BotFetal.Configuration
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public dynamic Result { get; set; }
        public dynamic MetaData { get; set; }
    }
}
