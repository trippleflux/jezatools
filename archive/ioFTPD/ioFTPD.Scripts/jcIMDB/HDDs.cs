using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using jcScripts.jcHelper;
using log4net;

namespace jcScripts.jcIMDB
{
	/// <summary>
	/// Summary description for HDDs.
	/// </summary>
	public class HDDs
	{
		private static readonly ILog mLog = LogManager.GetLogger(typeof(HDDs));

		public HDDs()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static bool CheckImdb()
		{
			string hddtop250 = ConfigReader.GetConfig("imdbTop250hddMoviesPath");
			if (hddtop250 != null)
			{
				mLog.InfoFormat("hddtop250={0}", hddtop250);
				string[] splitHDDs = hddtop250.Split(' ');
				foreach (string hddPath in splitHDDs)
				{
					string pathName = hddPath.Trim();
					mLog.DebugFormat("Checking '{0}'", pathName);
					if (Directory.Exists(pathName))
					{
						mLog.InfoFormat("Found '{0}'", pathName);
						DirectoryInfo di = new DirectoryInfo(pathName);
						DirectoryInfo[] diArr = di.GetDirectories();
						int count = 0;
						foreach (DirectoryInfo dri in diArr)
						{
							mLog.InfoFormat("Check Dir ({1}) '{0}'", dri.FullName, count);
							string dirname = dri.ToString();
							Global.imdbtop250_dirname = dri.Name;

							//skip dir?
							Match skipDir = Regex.Match(dirname, ConfigReader.GetConfig("imdbTop250hddregexpSkipDir"));
							if ( skipDir.Success )
							{
								mLog.InfoFormat("SKIP '{0}'", dri);
								continue;
							}
							count++;

							//get .nfo files
							FileInfo[] rgFiles = dri.GetFiles("*.nfo");

							int nfoFilesCount = rgFiles.Length;
							mLog.InfoFormat("Found {0} '.nfo' Files", nfoFilesCount);

							if ( nfoFilesCount == 0 )
							{
								mLog.InfoFormat(".nfo Not Found '{0}'", dri);
								continue;
							}
							else
							{
								bool imdbRankThere = false;
								bool imdbLinkThere = false;
								foreach(FileInfo fi in rgFiles)
								{
									string fileName = fi.FullName;
									mLog.InfoFormat("Check File '{0}'", fileName);
									if ( (!File.Exists(fileName)) )
									{
										mLog.WarnFormat("File Not Found '{0}'", fileName);
										continue;
									}
									else
									{
										switch ( ImdbInfo.CheckIMDB(dri, fi, false, false) )
										{
											case (int)ImdbCodes.imdbLinkNotFound:
											{
												mLog.InfoFormat("imdbLinkNotFound '{0}'", fileName);
												break;
											}
											case (int)ImdbCodes.imdbRankNotFound:
											{
												mLog.InfoFormat("imdbRankNotFound '{0}'", fileName);
												break;
											}
											case (int)ImdbCodes.imdbOK:
											{
												imdbRankThere = true;
												imdbLinkThere = true;
												mLog.InfoFormat("imdbRankFound '{0}'", fileName);
												break;
											}
											default:
											{
												break;
											}
										}
										if ( imdbRankThere && imdbLinkThere )
										{
											mLog.InfoFormat("Stop Loop '{0}'", fileName);
											break;
										}
									}	//file was there

								}	//foreach(FileInfo fi in rgFiles)
								Thread.Sleep(250);
							}

						}
					}
					else
					{
						mLog.WarnFormat("'{0}' Doesnt Exists!", pathName);
					}
				}
				return true;
			}
			else
			{
				mLog.WarnFormat("ConfigReader.GetConfig(\"hddtop250\") Was Not Found!");
				return false;
			}
		}
	}
}
