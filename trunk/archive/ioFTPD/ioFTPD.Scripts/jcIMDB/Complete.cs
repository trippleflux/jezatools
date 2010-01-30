using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

using jcScripts.jcHelper;

using log4net;

namespace jcScripts.jcIMDB
{
	/// <summary>
	/// Summary description for Complete.
	/// </summary>
	public class Complete
	{
		public static readonly ILog Log = LogManager.GetLogger(typeof(Complete));

		public static bool CheckComplete(bool manualCommand)
		{
			string path = ConfigReader.GetConfig("imdbTop250MoviesPath");
			/*
			string vfs = ConfigReader.GetConfig("imdbTop250MoviesVfs");
			string sympath = ConfigReader.GetConfig("imdbTop250SymlinkPath");
			string symvfs = ConfigReader.GetConfig("imdbTop250SymlinkVfs");
			*/

			if ( Directory.Exists(path) )
			{
				DirectoryInfo di = new DirectoryInfo(path);
				DirectoryInfo[] diArr = di.GetDirectories();
				if ( manualCommand )
				{
					Console.WriteLine("!buffer off\n");
				}
				int count = 0;
				foreach (DirectoryInfo dri in diArr)
				{
					Log.InfoFormat("Check Dir ({1}) '{0}'", dri.FullName, count);
					string dirname = dri.ToString();
					Global.imdbtop250_dirname = dri.Name;

					//skip dir?
					Match skipDir = Regex.Match(dirname, ConfigReader.GetConfig("imdbTop250regexpSkipDir"));
					if ( skipDir.Success )
					{
						if ( manualCommand )
						{
							Console.WriteLine(
								Format.FormatStr1ng( 
								ConfigReader.GetConfig("msgImdbSkipDirName"), 0, null
								));
							Log.InfoFormat("SKIP '{0}'", dri);
						}
						continue;
					}

					count++;
					//get .nfo files
					FileInfo[] rgFiles = dri.GetFiles("*.nfo");

					int nfoFilesCount = rgFiles.Length;
					Log.InfoFormat("Found {0} '.nfo' Files", nfoFilesCount);

					if ( nfoFilesCount == 0 )
					{
						if ( manualCommand )
						{
							Console.WriteLine(
								Format.FormatStr1ng( 
								ConfigReader.GetConfig("msgImdbNfoNotFound"), 0, null
								));
							Log.InfoFormat(".nfo Not Found '{0}'", dri);
						}
						IO.CheckNoNfo(dri);
						continue;
					}
					else
					{
//						foreach(FileInfo fi in rgFiles)
//						{
//							if ( ImdbInfo.CheckIMDB(dri, fi, manualCommand, false) == 1)
//							{
//								break;
//							}
//						
//						}	//foreach(FileInfo fi in rgFiles)
//						Thread.Sleep(250);
						bool imdbLinkNotFound = false;
						bool imdbRankNotFound = false;
						bool imdbRankThere = false;
						bool imdbLinkThere = false;
						foreach(FileInfo fi in rgFiles)
						{
							string fileName = fi.FullName;
							Log.InfoFormat("Check File '{0}'", fileName);
							if ( (!File.Exists(fileName)) )
							{
								Log.InfoFormat("File Not Found '{0}'", fileName);
								continue;
							}
							else
							{
								switch ( ImdbInfo.CheckIMDB(dri, fi, manualCommand, false) )
								{
									case (int)ImdbCodes.imdbLinkNotFound:
									{
										imdbLinkNotFound = true;
										Log.InfoFormat("imdbLinkNotFound '{0}'", fileName);
										break;
									}
									case (int)ImdbCodes.imdbRankNotFound:
									{
										imdbRankNotFound = true;
										Log.InfoFormat("imdbRankNotFound '{0}'", fileName);
										break;
									}
									case (int)ImdbCodes.imdbOK:
									{
										imdbRankThere = true;
										imdbLinkThere = true;
										Log.InfoFormat("imdbRankFound '{0}'", fileName);
										break;
									}
									default:
									{
										break;
									}
								}
								if ( imdbRankThere && imdbLinkThere )
								{
									Log.InfoFormat("Stop Loop '{0}'", fileName);
									break;
								}
							}	//file was there

						}	//foreach(FileInfo fi in rgFiles)
						Thread.Sleep(250);

						if ( imdbLinkNotFound )
						{
							IO.CheckNoImdb(dri);
						}

						if ( imdbRankNotFound )
						{
							IO.CheckNotInImdbTop250(dri);
						}
					}	//( nfoFilesCount > 0 )
				}	//foreach (DirectoryInfo dri in diArr)
				if ( manualCommand )
				{
					Global.imdbtop250_dircount = count.ToString();
					Console.WriteLine(
						Format.FormatStr1ng( 
						ConfigReader.GetConfig("msgImdbDirsCount"), 0, null
						));
				}
			}
			else
			{
				Log.InfoFormat("{0} Not Found!", path);
				if ( manualCommand )
				{
					Console.WriteLine(
						Format.FormatStr1ng( 
						ConfigReader.GetConfig("msgImdbDirNotFound"), 0, null
						));
				}
			}
			return true;
		}
	}
}
