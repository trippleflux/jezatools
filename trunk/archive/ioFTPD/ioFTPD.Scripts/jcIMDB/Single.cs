using System;
using System.Globalization;
using System.IO;

using jcScripts.jcHelper;

using log4net;

namespace jcScripts.jcIMDB
{
	/// <summary>
	/// Summary description for Single.
	/// </summary>
	public class Single
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Single));

		public static bool CheckSingle(string[] args)
		{
			string path = ConfigReader.GetConfig("imdbTop250MoviesPath");
			string dirName = 
				String.Format(CultureInfo.InvariantCulture, "{0}\\{1}", path, args[1]);
			Global.imdbtop250_dirname = args[1];

			if ( Directory.Exists(dirName) )
			{
				DirectoryInfo di = new DirectoryInfo(dirName);
				FileInfo[] rgFiles = di.GetFiles("*.nfo");
				
				int nfoFilesCount = rgFiles.Length;
				Log.InfoFormat("Found {0} '.nfo' Files", nfoFilesCount);

				if ( nfoFilesCount == 0 )
				{
					Console.WriteLine(
						Format.FormatStr1ng( 
						ConfigReader.GetConfig("msgImdbNfoNotFound"), 0, null
						));
					Log.InfoFormat(".nfo Not Found '{0}'", di);
					IO.CheckNoNfo(di);
				}
				else
				{
					bool imdbLinkNotFound = false;
					bool imdbRankNotFound = false;
					bool imdbRankThere = false;
					bool imdbLinkThere = false;
					foreach(FileInfo fi in rgFiles)
					{
						string fileName = fi.FullName;
						if ( (!File.Exists(fileName)) )
						{
							Log.InfoFormat("File Not Found '{0}'", fileName);
							continue;
						}
						else
						{
							switch ( ImdbInfo.CheckIMDB(di, fi, true, false) )
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

					if ( imdbLinkNotFound )
					{
						IO.CheckNoImdb(di);
					}

					if ( imdbRankNotFound )
					{
						IO.CheckNotInImdbTop250(di);
					}

				}	//( nfoFilesCount > 0 )
			}
			else
			{
				Log.InfoFormat("{0} Was Not Found!", dirName);
				Console.WriteLine(
					Format.FormatStr1ng( 
					ConfigReader.GetConfig("msgImdbDirNotFound"), 0, null
					));
			}
			return true;
		}
	}
}
