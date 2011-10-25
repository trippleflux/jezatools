using System;
using jeza.ioFTPD.Framework;

namespace jeza.ioFTPD.Archive
{
    internal class Program
    {
        private static void Main()
        {
            Log.Debug("--------------------------------------------------------------"); 
            Log.Debug("Archive...");
            try
            {
                ConsoleAppTasks consoleAppTasks = new ConsoleAppTasks();
                consoleAppTasks.ParseConfig();
                consoleAppTasks.Execute(TaskType.Archive);
            }
            catch (Exception exception)
            {
                Log.Debug(exception.ToString());
            }
        }
    }
}