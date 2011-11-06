using System;
using jeza.ioFTPD.Framework;

namespace jeza.ioFTPD.Manager
{
    public class Program
    {
        static void Main(string[] args)
        {
            Log.Debug("--------------------------------------------------------------");
            Log.Debug("Manager...");
            Log.Debug("args: '{0}'", Misc.ArgsToString(args));
            try
            {
                int numberOfArguments = args.Length;
                if (numberOfArguments > 0)
                {
                    ConsoleAppTasks consoleAppTasks = new ConsoleAppTasks(args);
                    consoleAppTasks.ParseConfig();

                    string firstArgument = args[0].ToLowerInvariant();
                    //args: 'args[0]='schedulerNewDay' '
                    if (firstArgument.EndsWith("newday"))
                    {
                        consoleAppTasks.Execute(TaskType.NewDay);
                    }
                    //args: 'args[0]='schedulerWeekly' '
                    if (firstArgument.EndsWith("weekly"))
                    {
                        consoleAppTasks.Execute(TaskType.Weekly);
                    }
                } 
            }
            catch (Exception exception)
            {
                Log.Debug(exception.ToString());
            }
        }
    }
}
