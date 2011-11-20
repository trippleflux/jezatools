using System;
using jeza.ioFTPD.Framework;

namespace jeza.ioFTPD.Manager
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Debug("--------------------------------------------------------------");
            Log.Debug("Manager...");
            Log.Debug("args: '{0}'", Misc.ArgsToString(args));
            int codeReturn = Constants.CodeOk;
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
                    //args: 'args[0]='listRequest' '
                    if (firstArgument.EndsWith("request"))
                    {
                        consoleAppTasks.Execute(TaskType.Request);
                    }
                    //args: 'args[0]='newdir', args[1]='D:\temp\testasd', args[2]='/temp/testasd''
                    if (firstArgument.Equals("newdir"))
                    {
                        codeReturn = consoleAppTasks.Execute(TaskType.DupeNewDir);
                    }
                    //args: 'args[0]='deldir', args[1]='D:\temp\testasd', args[2]='/temp/testasd''
                    if (firstArgument.Equals("deldir"))
                    {
                        codeReturn = consoleAppTasks.Execute(TaskType.DupeDelDir);
                    }
                    //args: 'args[0]='dupelist', args[1]='testasd''
                    if (firstArgument.Equals("dupelist"))
                    {
                        if (args.Length == 2)
                        {
                            consoleAppTasks.Execute(TaskType.DupeList);
                        }
                    }
                    //args: 'args[0]='duperemove', args[1]='testasd''
                    if (firstArgument.Equals("duperemove"))
                    {
                        if (args.Length == 2)
                        {
                            consoleAppTasks.Execute(TaskType.DupeRemove);
                        }
                    }
                } 
            }
            catch (Exception exception)
            {
                Log.Debug(exception.ToString());
                codeReturn = Constants.CodeFail;
            }
            return codeReturn;
        }
    }
}
