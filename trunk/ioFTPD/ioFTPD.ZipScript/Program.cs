namespace ioFTPD.ZipScript
{
    public class Program
    {
        public static int Main (string[] args)
        {
            ConsoleApp consoleApp = new ConsoleApp (args);
            consoleApp.Parse ();
            return consoleApp.Process () ? 0 : 1;
        }
    }
}