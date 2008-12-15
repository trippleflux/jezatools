using System;
using System.Diagnostics;
using System.Reflection;
using TravianBot.Framework;

namespace TravianBot.Runner
{
    public class ConsoleApp
    {
        public ConsoleApp(string[] args)
        {
            this.args = args;
        }

        public void Process()
        {
            try
            {
                ShowBanner();

                ServerInfo serverInfo = new ServerInfo();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        internal static void ShowBanner()
        {
// ReSharper disable AssignNullToNotNullAttribute
            FileVersionInfo version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
// ReSharper restore AssignNullToNotNullAttribute
            Console.WriteLine("TravianBot.Runner v{0}", version.FileVersion);
            Console.WriteLine();
        }

        private readonly string[] args;
    }
}