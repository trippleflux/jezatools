#region
using System;
using jeza.ioFTPD.Framework;

#endregion

namespace jeza.ioFTPD.ZipScript
{
    public class Program
    {
        public static int Main (string[] args)
        {
            bool processExit = false;
            try
            {
                ConsoleApp consoleApp = new ConsoleApp(args);
                consoleApp.Parse();
                processExit = consoleApp.Process();
            }
            catch (Exception exception)
            {
                Log.Debug(exception.Message);
                Log.Debug(exception.StackTrace);
            }
            return processExit ? 0 : 1;
        }
    }
}