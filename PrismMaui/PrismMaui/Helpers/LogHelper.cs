using Microsoft.Extensions.Logging;

namespace PrismMaui.Helpers
{
    public static class LogHelper
    {
        private static ILogger logger;

        public static void SetLogger(ILogger newLogger)
        {
            logger ??= newLogger;
        }

        public static ILogger GetLogger()
        {
            return logger;
        }
    }
}
