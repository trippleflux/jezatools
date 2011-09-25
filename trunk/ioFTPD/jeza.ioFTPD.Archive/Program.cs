using System;
using jeza.ioFTPD.Framework;

namespace jeza.ioFTPD.Archive
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Debug((string) "Archive...");
            try
            {
                ConsoleApp consoleApp = new ConsoleApp();
                consoleApp.ParseConfig();
                consoleApp.Execute();
            }
            catch (Exception exception)
            {
                Log.Debug(exception.ToString());
            }
        }
    }
}