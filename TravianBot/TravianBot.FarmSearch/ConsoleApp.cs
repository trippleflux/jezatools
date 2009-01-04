using System;

namespace TravianBot.FarmSearch
{
    public class ConsoleApp
    {
        public ConsoleApp(string[] args)
        {
            this.args = args;
        }

        public void Process()
        {
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }
        }

        private readonly string[] args;
    }
}