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
            consoleApp.CheckAliance(alianceIds);
            consoleApp.ParseConfig();
            consoleApp.Process();
        }
    }
}
