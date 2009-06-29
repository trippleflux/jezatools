using System.Configuration;

namespace jcMp3Sort
{
	class Settings
	{
		private static string mPathSortingMp3Artist = GetConfig("path.Sorting.Mp3.Artist");
		private static string mPathSortingMp3Genre = GetConfig("path.Sorting.Mp3.Genre");
		private static string mPathSortingMp3Year = GetConfig("path.Sorting.Mp3.Year");

		private static string mPathSourceMp3Upload = GetConfig("path.Source.Mp3.Upload");
		
		public static string pathSortingMp3Artist
		{
			get { return mPathSortingMp3Artist; }
		}

		public static string pathSortingMp3Genre
		{
			get { return mPathSortingMp3Genre; }
		}

		public static string pathSortingMp3Year
		{
			get { return mPathSortingMp3Year; }
		}

		public static string pathSourceMp3Upload
		{
			get { return mPathSourceMp3Upload; }
		}

		/// <summary>
		/// Gets the value from config file
		/// </summary>
		/// <param name="cnfgValue">key</param>
		/// <returns><c>value</c></returns>
		private static string GetConfig(string cnfgValue)
		{
			string valueName = ConfigurationManager.AppSettings.Get(cnfgValue);
			if (valueName == null)
			{
				return null;
			}
			else
			{
				return valueName;
			}
		}
	}
}
