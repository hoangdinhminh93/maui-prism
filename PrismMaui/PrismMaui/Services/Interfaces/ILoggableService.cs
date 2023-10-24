using Microsoft.Extensions.Logging;
using PrismMaui.Helpers;

namespace PrismMaui.Services.Interfaces
{
    public interface ILoggableService
    {
        void SetLogger(ILogger logger)
        {
            LogHelper.SetLogger(logger);
        }
    }
}
