using System;
using System.Configuration;

namespace jcReleaseCollector
{
	public class Settings
	{
		/// <summary>
		/// Gets the value from config file
		/// </summary>
		/// <param name="cnfgValue">key</param>
		/// <returns><c>value</c></returns>
		public static string GetConfig(string cnfgValue)
		{
			string valueName = ConfigurationManager.AppSettings.Get(cnfgValue);
			if (valueName == null)
			{
				return String.Empty;
			}
			else
			{
				return valueName;
			}
		}
	}
}
