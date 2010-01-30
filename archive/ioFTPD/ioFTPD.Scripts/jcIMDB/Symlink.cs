using System;
using System.Globalization;
using System.IO;

using jcScripts.jcHelper;

using log4net;

namespace jcScripts.jcIMDB
{
	/// <summary>
	/// Summary description for Symlink.
	/// </summary>
	public class Symlink
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Symlink));

		public static bool CheckSymlink(bool manulaCommand)
		{
			string path = ConfigReader.GetConfig("imdbTop250MoviesPath");
			string sympath = ConfigReader.GetConfig("imdbTop250SymlinkPath");
			int headLength = Convert.ToInt32(ConfigReader.GetConfig("imdbTop250headlength"));
			int minLength = Convert.ToInt32(ConfigReader.GetConfig("imdbTop250MinimumDirLength"));

			if ( Directory.Exists(sympath) )
			{
				DirectoryInfo di = new DirectoryInfo(sympath);
				DirectoryInfo[] diArr = di.GetDirectories();

				Log.InfoFormat("Checking Symlinks In '{0}'", sympath);

				foreach (DirectoryInfo dri in diArr)
				{
					string dirName = dri.Name.ToString().Substring(headLength);
					if ( dirName.Length < minLength )
					{
						Log.InfoFormat("Skip '{0}' Because Of Minumum Length", dirName);
						continue;
					}
//					string symDir = 
//						String.Format(CultureInfo.InvariantCulture, "{0}\\{1}", sympath, dirName);
					string orgDir = 
						String.Format(CultureInfo.InvariantCulture, "{0}\\{1}", path, dirName);
					Log.InfoFormat("Checking If '{0}' Exists", dirName);
					if ( !Directory.Exists(orgDir) )
					{
						Log.InfoFormat("'{0}' Doesnt Exists", orgDir);
						IO.DeleteFolder(dri.FullName);
					}
				}
			}

			return true;
		}
	}
}
