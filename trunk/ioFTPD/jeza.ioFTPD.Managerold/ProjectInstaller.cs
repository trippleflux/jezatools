using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace jeza.ioFTPD.Manager
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller
                          {
                              Account = ServiceAccount.LocalSystem,
                          };
            service = new ServiceInstaller
                          {
                              ServiceName = "ioFTPDManagerWindowsService",
                              StartType = ServiceStartMode.Automatic,
                          };
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}