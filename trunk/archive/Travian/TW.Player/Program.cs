#region

using System;
using log4net;

#endregion

namespace TW.Player
{
    internal class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        [STAThread]
        private static void Main()
        {
            try
            {
                ConsoleApp consoleApp = new ConsoleApp();
                consoleApp.PlayGame();
            }
            catch (Exception exception)
            {
                Log.Error(exception);
            }
        }
    }
}