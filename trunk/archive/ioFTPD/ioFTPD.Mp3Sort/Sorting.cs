using System;
using System.IO;
using HundredMilesSoftware.UltraID3Lib;
using log4net;
using Monitor.Core.Utilities;
//using MediaInfoLib;

namespace jcMp3Sort
{
	internal class Sorting
	{
		private static readonly ILog mLog = LogManager.GetLogger(typeof (Sorting));



		public static int GetInfos(string dirName, int depth)
		{
			mLog.InfoFormat("dirName='{0}', depth={1}", dirName, depth);
			if (Directory.Exists(dirName))
			{
				DirectoryInfo di = new DirectoryInfo(dirName);
				DirectoryInfo[] diArr = di.GetDirectories();
				if (diArr.Length > 0)
				{
					if (depth > 1)
					{
						foreach (DirectoryInfo dri in diArr)
						{
							GetInfos(dri.FullName, depth - 1);
						}
					}
					else
					{
						//get mp3 infos
						foreach (DirectoryInfo dri in diArr)
						{
							mLog.DebugFormat("Checking '{0}'", dri.FullName);
							FileInfo[] rgFiles = dri.GetFiles("*.mp3");
							int filesCount = rgFiles.Length;
							if (filesCount > 0)
							{
								mLog.DebugFormat("Found {0} Mp3 Files In '{1}'", filesCount, dri.FullName);
								Console.WriteLine("-{0}", dri.FullName);
								bool found = false;
								foreach (FileInfo file in rgFiles)
								{
									if (found)
									{
										break;
									}
									mLog.DebugFormat("Get Mp3 Info For '{0}'", file.FullName);
									UltraID3 mp3Info = new UltraID3();
									mp3Info.Read(file.FullName);
									if (mp3Info.ID3v23Tag.FoundFlag || mp3Info.ID3v1Tag.FoundFlag)
									{
										mLog.DebugFormat("Mp3 Info For '{0}':\n{1}", file.FullName, mp3Info.ToString());
										found = true;
										CreateSymlinks(dri.FullName, dri.Name, "Artist", mp3Info.Artist);
										CreateSymlinks(dri.FullName, dri.Name, "Year", mp3Info.Year.ToString());
										CreateSymlinks(dri.FullName, dri.Name, "Genre", mp3Info.Genre);
									}
								}
							}
							else
							{
								mLog.InfoFormat("Directory '{0}' Doesnt Have Any Mp3 Files!", dri.FullName);
							}
						}
					}
				}
				else
				{
					mLog.WarnFormat("'{0}' Has No Directories!", dirName);
				}
			}
			else
			{
				mLog.WarnFormat("'{0}' Doesnt Exists!", dirName);
			}
			return 0;
		}



		private static bool CreateSymlinks(string targetFolder, string dirName, string what, string id3)
		{
			string symlinkRoot = "C:\\temp";
			string symlink = "C:\\temp\\delMe";
			if (what.Equals("Artist"))
			{
				symlinkRoot = String.Format("{0}\\{1}", Settings.pathSortingMp3Artist, dirName[0]);
				symlink = String.Format("{0}\\{1}", symlinkRoot, dirName);
			}
			if (what.Equals("Year"))
			{
				symlinkRoot = String.Format("{0}\\{1}", Settings.pathSortingMp3Year, id3);
				symlink = String.Format("{0}\\{1}", symlinkRoot, dirName);
			}
			if (what.Equals("Genre"))
			{
				symlinkRoot = String.Format("{0}\\{1}", Settings.pathSortingMp3Genre, id3);
				symlink = String.Format("{0}\\{1}", symlinkRoot, dirName);
			}
			//create directoryes
			if (!Directory.Exists(symlinkRoot))
			{
				Directory.CreateDirectory(symlinkRoot);
			}
			if (!Directory.Exists(symlink))
			{
				Directory.CreateDirectory(symlink);
			}
			CreateJunctionPoint(targetFolder, symlink);
			return true;
		}



		private static bool CreateJunctionPoint(string targetFolder, string junctionPoint)
		{
			mLog.InfoFormat("targetFolder='{0}', junctionPoint='{0}'", targetFolder, junctionPoint);
			// Create junction point and confirm its properties.
			JunctionPoint.Create(junctionPoint, targetFolder, true /*overwrite*/);
			if (JunctionPoint.Exists(junctionPoint))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}