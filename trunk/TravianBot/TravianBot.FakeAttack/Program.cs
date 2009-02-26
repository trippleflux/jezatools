using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravianBot.FakeAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList alianceIds = new ArrayList {2092, 2210};
            ConsoleApp consoleApp = new ConsoleApp();
            if (consoleApp.ConnectToserver())
            {
                if (consoleApp.CheckAliance(alianceIds))
                {
                    consoleApp.ParseConfig();
                    consoleApp.Process();
                }
            }
            Console.WriteLine("Pres any key to exit program...");
            Console.ReadKey();
        }
    }
}
