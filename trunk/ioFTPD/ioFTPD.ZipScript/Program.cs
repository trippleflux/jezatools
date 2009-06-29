namespace ioFTPD.ZipScript
{
    class Program
    {
        static int Main(string[] args)
        {
            ConsoleApp consoleApp = new ConsoleApp(args);
            consoleApp.Parse();
            return consoleApp.Process() ? 0 : 1;
        }
    }
}