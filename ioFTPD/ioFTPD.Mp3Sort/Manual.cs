using System;
using System.IO;
using log4net;

namespace jcMp3Sort
{
	internal class Manual
	{
		private static readonly ILog mLog = LogManager.GetLogger(typeof (Manual));



		public static bool CreateJunctions()
		{
			mLog.DebugFormat("Settings.pathSortingMp3Artist='{0}'", Settings.pathSortingMp3Artist);
			mLog.DebugFormat("Settings.pathSortingMp3Genre='{0}'", Settings.pathSortingMp3Genre);
			mLog.DebugFormat("Settings.pathSortingMp3Year='{0}'", Settings.pathSortingMp3Year);
			mLog.DebugFormat("Settings.pathSourceMp3Upload='{0}'", Settings.pathSourceMp3Upload);
			if (!Directory.Exists(Settings.pathSortingMp3Artist))
			{
				mLog.WarnFormat("'{0}' Doesnt Exists!", Settings.pathSortingMp3Artist);
				return true;
			}
			if (!Directory.Exists(Settings.pathSortingMp3Genre))
			{
				mLog.WarnFormat("'{0}' Doesnt Exists!", Settings.pathSortingMp3Genre);
				return true;
			}
			if (!Directory.Exists(Settings.pathSortingMp3Year))
			{
				mLog.WarnFormat("'{0}' Doesnt Exists!", Settings.pathSortingMp3Year);
				return true;
			}
			string[] sourceFolders = Settings.pathSourceMp3Upload.Split(' ');
			foreach (string sourceFolder in sourceFolders)
			{
				string dirName = sourceFolder.Split('|')[0];
				string dirDepth = sourceFolder.Split('|')[1];
				mLog.InfoFormat("Start '{0}'", dirName);
				Sorting.GetInfos(dirName, Int32.Parse(dirDepth));
			}
			return true;
		}
	}
}