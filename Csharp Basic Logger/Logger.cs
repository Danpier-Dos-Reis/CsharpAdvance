using System;
using System.Configuration;

namespace Csharp_Basic_Logger
{
    public static class Logger
    {
        public static void WriteLog(string message)
        {
            string logPath = ConfigurationManager.AppSettings["logPathTxtFile"];

            using (StreamWriter writer = new StreamWriter(logPath,true)){
                writer.Write(message);
            }
        }
    }
}
