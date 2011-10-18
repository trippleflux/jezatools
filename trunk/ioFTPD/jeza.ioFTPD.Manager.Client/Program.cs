using System;
using jeza.ioFTPD.Framework;

namespace jeza.ioFTPD.Manager.Client
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                DateTime startTime = new DateTime(DateTime.Now.Ticks);
                ManagerClient client = new ManagerClient();
                ManagerResponse managerResponse = client.ProcessZipScript(args);
                Console.WriteLine(managerResponse.Console);
                DateTime endTime = new DateTime(DateTime.Now.Ticks);
                Console.WriteLine("Checked in {0}ms", (endTime - startTime).TotalMilliseconds);
                return managerResponse.Code;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}