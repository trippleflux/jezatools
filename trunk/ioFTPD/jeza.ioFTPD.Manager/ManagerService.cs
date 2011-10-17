using System;
using jeza.ioFTPD.Framework;

namespace jeza.ioFTPD.Manager
{
    public class ManagerService : IManager
    {
        public int ProcessZipScript(string[] args)
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

        public int ProcessArchiveScript(string[] args)
        {
            throw new NotImplementedException();
        }

        public int ProcessManager(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}