#region
using System;
using jeza.ioFTPD.Framework;

#endregion

namespace jeza.ioFTPD.ZipScript
{
    public class Program
    {
        public static int Main(string[] args)
        {
            DateTime startTime = new DateTime(DateTime.Now.Ticks);
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
            DateTime endTime = new DateTime(DateTime.Now.Ticks);
            Console.WriteLine("Checked in {0}ms", (endTime - startTime).TotalMilliseconds);
            return processExit ? 0 : 1;
        }
    }
}