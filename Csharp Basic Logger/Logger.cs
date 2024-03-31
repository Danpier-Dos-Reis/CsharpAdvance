using System;
using System.Configuration;
using NLog;

namespace Csharp_Basic_Logger
{
    public static class Logger
    {
        public static void ConfigureLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logInfo = new NLog.Targets.FileTarget("LogInfo"){ FileName = "C:\\Programming Practices\\Csharp Basic Logger\\Csharp Basic Logger\\LOG\\logInfo.log" };
            var logDebug = new NLog.Targets.ConsoleTarget("LogDebug") {
                Header = "<HELLO VENEZUELA>",
                Footer = "</HELLO VENEZUELA>"
            };

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Info, logInfo);

            //So in logDebug we can print debug messages and exceptions errors
            config.AddRule(LogLevel.Debug, LogLevel.Error, logDebug);

            // Apply config           
            NLog.LogManager.Configuration = config;
        }
    }
}
