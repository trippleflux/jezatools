using System;
using System.Configuration;

using log4net;
using log4net.Config;

namespace jcScripts.jcHelper
{
	/// <summary>
	/// Summary description for ConfigReader.
	/// </summary>
	public class ConfigReader
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// Gets the value from config file
		/// </summary>
		/// <param name="cnfgValue">key</param>
		/// <returns></returns>
		public static string GetConfig(string cnfgValue)
		{
			string valueName = ConfigurationManager.AppSettings.Get(cnfgValue);
			if ( valueName == null )
				return null;
			else
				return valueName;
		}
	}
}
