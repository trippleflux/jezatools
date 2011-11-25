using System;
using jeza.ioFTPD.Framework;

namespace jeza.ioFTPD.Trial
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ConsoleAppTrial consoleAppTrial = new ConsoleAppTrial(args);
                consoleAppTrial.Parse();
                consoleAppTrial.Process();
            }
            catch (Exception exception)
            {
                Log.Debug(exception.Message);
                Log.Debug(exception.StackTrace);
            }
        }
    }
}
