using System;
using System.Configuration;

namespace TravianPlayer.Framework
{
	public class Misc
	{
		public static string GetConfigValue(string configKey)
		{
			string configValue = String.Empty;
			try
			{
				configValue = ConfigurationManager.AppSettings[configKey];
			}
			catch (Exception)
			{
				Console.WriteLine("Key '{0}' Not Found!!!", configKey);
			}
			return configValue;
		}
	}
}