using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace jcTBotService
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			// More than one user Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServiceBase[] ServicesToRun = new ServiceBase[] { new ServicejcTBot() };

			ServiceBase.Run(ServicesToRun);
			System.Console.WriteLine("test");
		}
	}
}