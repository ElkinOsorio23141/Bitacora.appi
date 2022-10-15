using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekisa.Api.BotFetal.Interfaces.Services.Common
{
    public interface IErrorLoggingDependency
    {
        string Report(Exception ex);
        void Warning(object obj);
    }
}
