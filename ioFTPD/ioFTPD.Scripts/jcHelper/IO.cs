using System;
using System.Globalization;
using System.IO;

using log4net;

namespace jcScripts.jcHelper
{
	/// <summary>
	/// Summary description for IO.
	/// </summary>
	public class IO
	{
		public static readonly ILog Log = LogManager.GetLogger(typeof(IO));

		/// <summary>
		/// Create A Directory.
		/// </summary>
		/// <param name="folderName">Folder Name (Full Path)</param>
		/// <returns><c>true</c> On Success</returns>
		public static bool CreateFolder(string folderName)
		{
			if (Directory.Exists(folderName)) 
			{
				Log.DebugFormat("'{0}' Already Exists", folderName);
				return false;
			}

			DirectoryInfo di = Directory.CreateDirectory(folderName);
			Log.DebugFormat("Created '{0}'", folderName);

			return true;
		}

		
		/// <summary>
		/// Delete A directory
		/// </summary>
		/// <param name="folderName">path to be deleted</param>
		/// <returns><c>false</c> if dir not found</returns>
		public static bool DeleteFolder(string folderName)
		{
			if (!Directory.Exists(folderName)) 
			{
				Log.DebugFormat("'{0}' Doesnt Exists", folderName);
				return false;
			}

			Directory.Delete(folderName, true);
			Log.DebugFormat("Deleted '{0}'", folderName);

			return true;
		}


		/// <summary>
		/// ge the dir name form pwd
		/// </summary>
		/// <param name="pwd">pwd from ioFTPD</param>
		/// <returns><c>null</c> if dir name could not be extracted from pwd</returns>
		public static string GetDirNameFromPwd(string pwd)
		{
			string dirName = null;
			string[] pwds = pwd.Split('/');
			int pwdLength = pwds.Length-1;
			Log.DebugFormat(" GetDirNameFromPwd.pwdLength='{0}'", pwdLength);
			if ( pwdLength > 0 )
			{
				for (int i=pwdLength;i>0;i--)
				{
					Log.DebugFormat("pwds[{1}]='{0}'", pwds[i], i);
					if ( pwds[i].Length > 0 )
					{
						dirName = pwds[i];
						break;
					}
				}
			}
			else
			{
				dirName = pwds[0];
			}
			Log.DebugFormat(" GetDirNameFromPwd='{0}'", dirName);
			return dirName;
		}
	
	
		/// <summary>
		/// ge the dir name form path
		/// </summary>
		/// <param name="pwd">path</param>
		/// <returns><c>null</c> if dir name could not be extracted from path</returns>
		public static string GetDirNameFromPath(string path)
		{
			string dirName = null;
			Log.DebugFormat("DirMisc.GetDirNameFromPwd='{0}'", dirName);
			return dirName;
		}


		public static bool CreateSymlink(string path, string vfs)
		{
			//printf("!vfs:chattr 1 \"d:\\desktop\\ioFTPD\\test\" \"/ioFTPD/users\"\n");
			string symlink = String.Format(CultureInfo.InvariantCulture, 
				"!vfs:chattr 1 \"{0}\" \"{1}\"", path, vfs);
			Console.WriteLine(symlink);
			Log.DebugFormat("Symlink Created: '{0}'", symlink);
			return true;
		}

	
		/// <summary>
		/// /// process the check if .nfo was not found
		/// </summary>
		/// <param name="dirInfo">directory to be deleted/renamed</param>
		/// <returns><c>true</c></returns>
		public static bool CheckNoNfo(DirectoryInfo dirInfo)
		{
			bool deleteNoNfo = 
				Convert.ToBoolean(ConfigReader.GetConfig("imdbTop250DeleteNoNfo"));
			string name = dirInfo.Name;
			if ( deleteNoNfo )
			{
				Log.DebugFormat("Directory Deleted '{0}'", dirInfo.FullName);
				dirInfo.Delete(true);
			}
			else
			{
				string path = ConfigReader.GetConfig("imdbTop250MoviesPath");
				string head = ConfigReader.GetConfig("imdbTop250NoNfo");
				String newDir = String.Format(CultureInfo.InvariantCulture, 
					"{0}\\{1}{2}", path, head, name);
				Log.DebugFormat("Directory Renamed '{0}' -> '{1}'", dirInfo.FullName, newDir);
				dirInfo.MoveTo(newDir);
			}
			//find and delete symlinks if any
			FindAndRemoveFolder(ConfigReader.GetConfig("imdbTop250SymlinkPath"), name);
			return true;
		}

		
		public static bool CheckNoImdb(DirectoryInfo dirInfo)
		{
			bool deleteNoImdb = 
				Convert.ToBoolean(ConfigReader.GetConfig("imdbTop250DeleteNoImdb"));
			string name = dirInfo.Name;
			if ( deleteNoImdb )
			{
				Log.DebugFormat("Directory Deleted '{0}'", dirInfo.FullName);
				dirInfo.Delete(true);
			}
			else
			{
				string path = ConfigReader.GetConfig("imdbTop250MoviesPath");
				string head = ConfigReader.GetConfig("imdbTop250NoIMDB");
				String newDir = String.Format(CultureInfo.InvariantCulture, 
					"{0}\\{1}{2}", path, head, name);
				Log.DebugFormat("Directory Renamed '{0}' -> '{1}'", dirInfo.FullName, newDir);
				dirInfo.MoveTo(newDir);
			}
			//find and delete symlinks if any
			FindAndRemoveFolder(ConfigReader.GetConfig("imdbTop250SymlinkPath"), name);
			return true;
		}


		public static bool CheckNotInImdbTop250(DirectoryInfo dirInfo)
		{
			bool deleteNotInTop250 = 
				Convert.ToBoolean(ConfigReader.GetConfig("imdbTop250DeleteNotInTop250"));
			string name = dirInfo.Name;
			if ( deleteNotInTop250 )
			{
				Log.DebugFormat("Directory Deleted '{0}'", dirInfo.FullName);
				dirInfo.Delete(true);
			}
			else
			{
				string path = ConfigReader.GetConfig("imdbTop250MoviesPath");
				string head = ConfigReader.GetConfig("imdbTop250NotInTop250");
				String newDir = String.Format(CultureInfo.InvariantCulture, 
					"{0}\\{1}{2}", path, head, name);
				Log.DebugFormat("Directory Renamed '{0}' -> '{1}'", dirInfo.FullName, newDir);
				dirInfo.MoveTo(newDir);
			}
			//find and delete symlinks if any
			FindAndRemoveFolder(ConfigReader.GetConfig("imdbTop250SymlinkPath"), name);
			return true;
		}


		public static bool CheckImdbTop250(DirectoryInfo dirInfo, int rank)
		{
			string name = dirInfo.Name;
			string symlinkPath = ConfigReader.GetConfig("imdbTop250SymlinkPath");
			//find and delete symlinks if any
			FindAndRemoveFolder(symlinkPath, name);

			//create index dir
			string head = ConfigReader.GetConfig("imdbTop250head");
			string symhead = String.Format(CultureInfo.InvariantCulture, head, rank);
			String newDir = String.Format(CultureInfo.InvariantCulture, 
				"{0}\\{1}{2}", symlinkPath, symhead, name);
			Log.DebugFormat("Creating Directory '{0}'", newDir);
			CreateFolder(newDir);
			
			//create virtual link (symlink) for folder
			string symlinkVfs = ConfigReader.GetConfig("imdbTop250MoviesVfs");
			string symlink = 
				String.Format(CultureInfo.InvariantCulture, "{0}{1}", symlinkVfs, name);
			Log.DebugFormat("Creating Symlink '{0}' -> '{1}'", newDir, symlink);
			CreateSymlink(newDir, symlink);
			
			return true;
		}


		public static bool FindAndRemoveFolder(string path, string name)
		{
			Log.DebugFormat("Searching For '{0}' In '{1}'", name, path);
			DirectoryInfo di = new DirectoryInfo(path);
			DirectoryInfo[] diArr = di.GetDirectories("*"+name+"*");
			Log.DebugFormat("Found '{0}' Folders", diArr.Length);
			foreach (DirectoryInfo dri in diArr)
			{
				Log.DebugFormat("Deleting '{0}'", dri.FullName);
				DeleteFolder(dri.FullName);
			}
			return true;
		}
	}
}
