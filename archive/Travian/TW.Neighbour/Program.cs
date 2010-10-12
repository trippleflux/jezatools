#region

#endregion

using System;
using log4net;

namespace TW.Neighbour
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
                consoleApp.SearchNeighbourhood();
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                Log.Error(exception.StackTrace);
            }
        }
    }
}