namespace jeza.ioFTPD.Archive
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleApp consoleApp = new ConsoleApp();
            consoleApp.ParseConfig();
            consoleApp.Execute();
        }
    }
}