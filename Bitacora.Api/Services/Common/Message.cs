using Ekisa.Api.BotFetal.Models;
using Ekisa.Api.BotFetal.Models.Enums;

namespace Ekisa.Api.BotFetal.Services.Common
{

    public class Message
    {
        #region Public Methods
        public static Messages SetMessage(TypeMessage type, string text, bool flag)
        {
            return new Messages
            {
                Type = type,
                Message = text,
                Flag = flag
            };
        }
        #endregion
    }
}
