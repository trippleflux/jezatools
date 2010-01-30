using System.Configuration;

namespace UidChanger
{
	/// <summary>
	/// Summary description for ConfigReader.
	/// </summary>
	public class ConfigReader
	{
		/// <summary>
		/// Gets the value from config file
		/// </summary>
		/// <param name="cnfgValue">key</param>
		/// <returns></returns>
		public static string GetValue(string cnfgValue)
		{
			string valueName = ConfigurationManager.AppSettings.Get(cnfgValue);
			if ( valueName == null )
				return null;
			else
				return valueName;
		}
	}
}
