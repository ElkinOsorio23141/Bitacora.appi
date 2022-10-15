using Ekisa.Api.BotFetal.Models.Enums;

namespace Ekisa.Api.BotFetal.Models
{
    public class Messages
    {
        #region Properties
        public TypeMessage Type { get; set; }
        public string Message { get; set; }
        public bool Flag { get; set; }
        #endregion
    }
}
