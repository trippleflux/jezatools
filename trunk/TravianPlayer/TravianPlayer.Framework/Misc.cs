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

		public static Int32 ConvertXY(Int32 x, Int32 y)
		{
			return ((x + 401) + ((400 - y) * 801));
		}

	    public static bool IsNumber(string input)
	    {
	        for (int c = 0; c < input.Length; c++)
	        {
	            if (!IsNumber(input[c]))
	            {
	                return false;
	            }
	        }
	        return true;
	    }

	    public static bool IsNumber(char c)
	    {
	        return Char.IsNumber(c);
	    }
	}
}