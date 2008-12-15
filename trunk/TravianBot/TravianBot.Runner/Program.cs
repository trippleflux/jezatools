namespace TravianBot.Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleApp consoleApp = new ConsoleApp(args);
            consoleApp.Process();
        }
    }
}
