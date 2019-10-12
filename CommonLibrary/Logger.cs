using System;
using System.Configuration;
using System.IO;

namespace CommonLibrary
{
    public enum LogLevel
    {
        Error,
        System,
        All,
    }

    public static class Logger
    {
        private static bool _isLogging;
        private static string _logFile;
        private static LogLevel _logLevel;

        static Logger()
        {
            var appSettings = ConfigurationManager.AppSettings;

            _isLogging = Convert.ToBoolean(appSettings["log"]);
            _logFile = appSettings["log_file"];
            Enum.TryParse(appSettings["log_level"], out _logLevel);

            if (_isLogging) File.Delete(_logFile);
        }

        public static void Write(string str, LogLevel level = LogLevel.All)
        {
            if (_isLogging)
            {
                if (_logLevel >= level)
                    File.AppendAllText(_logFile, level.ToString() + ": " + str + "\n");
            }
        }
    }
}
