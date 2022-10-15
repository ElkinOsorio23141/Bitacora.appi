using Ekisa.Api.BotFetal.Models;
using Ekisa.Api.BotFetal.Models.Enums;

namespace Ekisa.Api.BotFetal.Services.Ínfraestructure
{
    public class Message : IMessage
    {
        public Messages Exception(string message)
        {
            return new Messages { Type = TypeMessage.Exception, Flag = false, Message = message };
        }

        public Messages Error(string message)
        {
            return new Messages { Type = TypeMessage.Error, Flag = false, Message = message };
        }

        public Messages Warning(string message)
        {
            return new Messages { Type = TypeMessage.Warning, Flag = false, Message = message };
        }

        public Messages Success()
        {
            return new Messages { Type = TypeMessage.Success, Flag = true, Message = "Ok" };
        }

        public Messages Success(string message)
        {
            return new Messages { Type = TypeMessage.Success, Flag = true, Message = message };
        }
    }
}
