using Ekisa.Api.BotFetal.Models;

namespace Ekisa.Api.BotFetal.Services.Ínfraestructure
{
    public interface IMessage
    {
        Messages Exception(string message);
        Messages Error(string message);
        Messages Warning(string message);
        Messages Success();
        Messages Success(string message);
    }
}
