using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] array)
        {
            if (baseLogger == null)
                throw new ArgumentNullException(nameof(baseLogger));

            baseLogger.Log(LogLevel.Error, string.Format(message, array[0]));
        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] array)
        {
            if (baseLogger == null)
                throw new ArgumentNullException(nameof(baseLogger));

            baseLogger.Log(LogLevel.Warning, string.Format(message, array[0]));
        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] array)
        {
            if (baseLogger == null)
                throw new ArgumentNullException(nameof(baseLogger));

            baseLogger.Log(LogLevel.Information, string.Format(message, array[0]));
        }

        public static void Debug(this BaseLogger baseLogger, string message, params object[] array)
        {
            if (baseLogger == null)
                throw new ArgumentNullException(nameof(baseLogger));

            baseLogger.Log(LogLevel.Debug, string.Format(message, array[0]));
        }
    }
}
