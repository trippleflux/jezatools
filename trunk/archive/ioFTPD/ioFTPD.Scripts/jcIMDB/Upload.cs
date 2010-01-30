using System;
using System.IO;
using jcScripts.jcHelper;

using log4net;

namespace jcScripts.jcIMDB
{
	/// <summary>
	/// Summary description for Upload.
	/// </summary>
	public class Upload
	{
		public static readonly ILog Log = LogManager.GetLogger(typeof(Upload));

		/// <summary>
		/// Checks if upload is in imdbTop250 Dir and if File is .nfo
		/// </summary>
		/// <param name="args">input arguments</param>
		/// <returns><c>true</c> if everything is OK</returns>
		public static bool CheckUpload(string[] args)
		{
			string pwdFileName = args[3];
			bool nfo = pwdFileName.ToLower().EndsWith(".nfo");

			bool enable_ImdbUrlInfo = 
				Convert.ToBoolean(ConfigReader.GetConfig("enable_ImdbUrlInfo"));
			bool enable_imdbTop250 = 
				Convert.ToBoolean(ConfigReader.GetConfig("enable_imdbTop250"));

			if ( !nfo )
			{
				Log.Info("Not NFO File");
				return true;
			}
			
			if ( (enable_imdbTop250) && 
				 (pwdFileName.IndexOf(ConfigReader.GetConfig("imdbTop250MoviesVfs")) > -1) )
			{
				Log.Info("Its imdbTop250Movie");
				DirectoryInfo di = new DirectoryInfo(Global.path);
				FileInfo fi = new FileInfo(args[1]);
				ImdbInfo.CheckIMDB(di, fi, false, true);
			}

			if ( (enable_ImdbUrlInfo) )
			{
				string imdbLink = NfoReader.GetImdbLink(args[1]);
				Log.InfoFormat("imdbLink={0}", imdbLink);

				if ( String.Compare(imdbLink, "empty") != 0 )
				{
					string imdbPwd = ConfigReader.GetConfig("imdbDirs");
					if (imdbPwd != null)
					{
						if ( Compare.StrngLengthCompare(imdbPwd, Global.pwd, ' ', true) )
						{
							Log.Info("Checking URL Imdb Info");
							ImdbInfo.ImdbInfos(imdbLink);
						}
						else
						{
							Log.Info("Loging URL");
							Global.url = imdbLink;
							bool anounceUrlInfo = 
								Convert.ToBoolean(ConfigReader.GetConfig("anounceUrlInfo"));
							if ( anounceUrlInfo )
							{
								Console.WriteLine(
									Format.FormatStr1ng( 
									ConfigReader.GetConfig("mircUrlInfo"), 0, null
									));
							}
						}
					}
					else
					{
						Log.WarnFormat("'imdbDirs' Was Not Found!");
					}
				}
				else
				{
					Log.Debug("'imdbLink' Was Not Found!");
				}

			}

			return true;
		}
	}
}
