using System.ServiceModel;
using System.ServiceProcess;

namespace jeza.ioFTPD.Manager
{
    public class ManagerWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;

        public ManagerWindowsService()
        {
            ServiceName = "ioFTPDManagerWindowsService";
        }

        public static void Main()
        {
            ServiceBase.Run(new ManagerWindowsService());
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            serviceHost = new ServiceHost(typeof(ManagerService));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}