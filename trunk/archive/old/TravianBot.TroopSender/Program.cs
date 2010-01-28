using System;

namespace TravianBot.TroopSender
{
    class Program
    {
        static void Main()
        {
            ConsoleApp consoleApp = new ConsoleApp();
            consoleApp.Parse();
            consoleApp.Process();
            Console.WriteLine("Pres any key to exit program...");
            Console.ReadKey();
        }
    }
}
