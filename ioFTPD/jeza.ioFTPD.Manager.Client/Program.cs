using System;

namespace jeza.ioFTPD.Manager.Client
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                ManagerClient client = new ManagerClient();
                int managerReturnCode = client.ProcessZipScript(args);
                Console.WriteLine("Manager Response : {0}", managerReturnCode);
                return managerReturnCode;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}