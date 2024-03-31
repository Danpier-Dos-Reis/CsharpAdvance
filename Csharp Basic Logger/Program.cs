// See https://aka.ms/new-console-template for more information
using System;

namespace Csharp_Basic_Logger
{
    internal class Program
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Logger.ConfigureLogger(); //This is the local logger
            int numb = 0;

            try {
                _logger.Info("Init division");
                numb = 23/numb;
            }
            catch (Exception ex) { _logger.Error(ex.Message); }
            finally { _logger.Info("End division"); }
        }
    }
}