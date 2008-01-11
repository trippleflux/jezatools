using System;
using System.Threading;
using jcTBLib;
using WatiN.Core;

namespace jcTB
{
	public class Build
	{
		public Thread build;

		public IE Ie
		{
			get { return ie; }
		}

		private Resources resources;
		private Codes.ResourceCodes resCode;
		private IE ie;

		public Build(String buildName, Resources resources, Codes.ResourceCodes resCode, IE ie)
		{
			this.resources = resources;
			this.resCode = resCode;
			this.ie = ie;
			//build = new Thread(new ThreadStart(BuildLand));
			//build.Name = buildName;
			//build.Start();
		}

		private void BuildLand()
		{
			Int32[] landLevels = jcTBL.GetWantedResourceLand(resCode, resources);
			Int32[] landIDs = jcTBL.GetWantedResourceId(resCode);
			Console.WriteLine("{0} Level Is [ {1}], Wanted Level Is {2}",
				jcTBL.ResourceName, jcTBL.GetLevel2String(landLevels, false), jcTBL.WantedLevel);
			//do
			//{
				Int32 buildIndex = jcTBL.FindIndexOfMinimum(landLevels);
				Console.WriteLine("We Will Build Resource With Level {0} (ID={1})",
					landLevels[buildIndex], landIDs[buildIndex]);
				Console.WriteLine(jcTBL.GetLevel2String(resources.NeededResources[landIDs[buildIndex]], false));
				Thread.Sleep(15000);
				Console.WriteLine("Thread State : " + build.ThreadState);
				//Resources res = new Resources(ie);
			//} while (jcTBL.FindMinimum(landLevels) < jcTBL.WantedLevel);
			build.Abort();
			build.Join();
		}
	}
}