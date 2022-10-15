namespace Ekisa.Api.BotFetal.Services.Common
{
    using System;
    public class GenerateCustomException
    {
        public static string ExeptionMessage(Exception ex)
        {
            return ex.InnerException != null && ex.InnerException?.Message == "common" ? ex.Message : "Excepción sin definición";
        }
    }
}
