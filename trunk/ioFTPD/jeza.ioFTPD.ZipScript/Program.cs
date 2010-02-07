#region
using System;

#endregion

namespace jeza.ioFTPD.ZipScript
{
    public class Program
    {
        public static int Main (string[] args)
        {
            DateTime dtStart = DateTime.Now;
            ConsoleApp consoleApp = new ConsoleApp (args);
            consoleApp.Parse ();
            DateTime dtEnd = DateTime.Now;
            Console.WriteLine ("Checked in {0}ms...", (dtEnd - dtStart).TotalMilliseconds);
            return consoleApp.Process () ? 0 : 1;
        }
    }
}