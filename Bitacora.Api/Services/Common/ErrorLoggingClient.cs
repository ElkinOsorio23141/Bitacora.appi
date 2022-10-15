using Ekisa.Api.BotFetal.Interfaces.Services.Common;
using Rollbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekisa.Api.BotFetal.Services.Common
{
    public class ErrorLoggingClient : IErrorLoggingDependency
    {
        string IErrorLoggingDependency.Report(Exception ex)
        {
            RollbarLocator.RollbarInstance.Error(ex);
            return ex.Message;
        }

        void IErrorLoggingDependency.Warning(object obj)
        {
            RollbarLocator.RollbarInstance.Warning(obj);
        }
    }
}
