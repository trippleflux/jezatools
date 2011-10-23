using System;
using jeza.ioFTPD.Framework;

namespace jeza.ioFTPD.Manager
{
    public class ManagerService : IManager
    {
        public ManagerResponse ProcessZipScript(string[] args)
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
            ManagerResponse managerResponse = new ManagerResponse
                                              {
                                                  Code = processExit ? 0 : 1,
                                              };
            return managerResponse;
        }

        public ManagerResponse ProcessArchiveScript(string[] args)
        {
           return new ManagerResponse();
        }

        public ManagerResponse ProcessManager(string[] args)
        {
            return new ManagerResponse();
        }
    }
}