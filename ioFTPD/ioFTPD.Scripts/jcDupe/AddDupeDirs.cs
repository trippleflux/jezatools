using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using jcScripts.jcHelper;
using Finisar.SQLite;

using log4net;
using log4net.Config;

namespace jcScripts.jcDupe
{
	/// <summary>
	/// Summary description for AddDupeDirs.
	/// </summary>
	public class AddDupeDirs
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private static bool isLevel = false;

		/// <summary>
		/// adds whole directory to DB.
		/// uses level for recursive add
		/// </summary>
		/// <param name="args">input argumets</param>
		/// <returns><c>true</c></returns>
		public static bool AddUpdateDupeDirs(string[] args)
		{
			Log.InfoFormat(" AddUpdateDupeDirs ->");
			int level = Int32.Parse(args[1]);
			Log.InfoFormat("level={0}", level);
			if ( level == 1 )
			{
				isLevel = true;
			}
			Console.WriteLine("!buffer off\n");
			ListDirs(Global.path, Global.pwd, level);
			Log.InfoFormat(" AddUpdateDupeDirs <-");
			return true;
		}


		private static int ListDirs(string dirName, string dirPwd, int level)
		{
			Log.InfoFormat(" ListDirs -> dirName={0}, dirPwd={1}, level={2}", dirName, dirPwd, level);

			DirectoryInfo di = new DirectoryInfo(dirName);
			DirectoryInfo[] diArr = di.GetDirectories();

			Log.DebugFormat(" Directories Coount In '{0}' Is {1}", di.FullName, diArr.Length);

			if ( diArr.Length == 0 )
			{
				
			}
			foreach (DirectoryInfo dri in diArr)
			{
				string tempPwd = "";
				if ( level > 1 )
				{
					tempPwd = dirPwd+dri.Name;
					Log.DebugFormat("level = {0}, FullName={1}, tempPwd={2}", level, dri.FullName, tempPwd);
					ListDirs(dri.FullName, tempPwd, level-1);
				}
				else
				{
					if ( isLevel )
					{
						tempPwd = dirPwd+dri.Name;
					}
					else
					{
						tempPwd = dirPwd+"/"+dri.Name;
					}
					string[] args = {"adddupe", tempPwd};
					Global.pwd = dirPwd+"/";
					Log.InfoFormat(" Adding '{0}'", tempPwd);
					AddDupe.AddUpdateDupe(args);
				}
			}
			return 1;
		}
	}
}
