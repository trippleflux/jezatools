using System;
using System.Configuration;
using System.Globalization;
using System.Reflection;

using jcScripts.jcHelper;
using Finisar.SQLite;

using log4net;
using log4net.Config;

namespace jcScripts.jcDupe
{
	/// <summary>
	/// Summary description for NewDir.
	/// </summary>
	public class NewDir
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// check OnNewDir if dir is a dupe
		/// </summary>
		/// <param name="args">input arguments</param>
		/// <returns><c>true</c> if dir is a dupe</returns>
		public static bool CheckDupeNewDir(string[] args)
		{
			Log.Info("->");

			if (!SkipDupe.CheckSkipDupe(args))
			{
				return false;
			}

			SQLiteConnection sqlite_conn;
			SQLiteCommand sqlite_cmd;
			SQLiteDataReader sqlite_datareader;

			string dbName = ConfigReader.GetConfig("dbDupeDir");
			string db = String.Format(CultureInfo.InvariantCulture, 
				@"Data Source={0};Version=3;New=False;Compress=True;", dbName);
			sqlite_conn = new SQLiteConnection(db);
			sqlite_conn.Open();
			sqlite_cmd = sqlite_conn.CreateCommand();

			string dbCommand = String.Format(CultureInfo.InvariantCulture, 
@"SELECT DISTINCT ReleaseDateTime, UserName, ReleaseName FROM dirDupe WHERE ReleaseName = '{0}'", Global.dupe_name);
			
			Log.InfoFormat("{0}", dbCommand);
			
			sqlite_cmd.CommandText = dbCommand;
			//sqlite_cmd.CommandText = "SELECT * FROM dirDupe";
			sqlite_datareader=sqlite_cmd.ExecuteReader();

			bool found = false;
			DateTime CurrTime = DateTime.Now;
			string skipDateFormat = ConfigReader.GetConfig("skipDateFormat");

			while (sqlite_datareader.Read())
			{
				Global.dupe_creator = sqlite_datareader["UserName"].ToString();
				Global.dupe_datetime = sqlite_datareader["ReleaseDateTime"].ToString();
				Global.dupe_name = sqlite_datareader["ReleaseName"].ToString();
				Global.dupe_tryer = Global.user;

				Console.WriteLine(
					Format.FormatStr1ng( 
						ConfigReader.GetConfig("msgDirIsDupe"), 0, null
					));

				string anounceDirIsDupe = ConfigReader.GetConfig("anounceDirIsDupe");
				if ( (anounceDirIsDupe != null) && (anounceDirIsDupe == "true") )
				{
					Console.WriteLine(
						Format.FormatStr1ng(ConfigReader.GetConfig("mircDirIsDupe"), 0, null));
				}

				Log.InfoFormat("Dir Is A Dupe! It Was Created By {0} On {1}", 
					sqlite_datareader["UserName"], sqlite_datareader["ReleaseDateTime"]);
				found = true;
			}
			sqlite_datareader.Close();

			if ( !found )
			{
				string what = "(ReleaseTime, ReleaseDateTime, ReleaseName, Pwd, UserName, GroupName)";
				string values = String.Format(CultureInfo.InvariantCulture, 
					"({4}, '{5}', '{0}', '{1}', '{2}', '{3}')",
					Global.dupe_name, 
					Global.dupe_pwd, 
					Environment.GetEnvironmentVariable("USER"), 
					Environment.GetEnvironmentVariable("GROUP"), 
					CurrTime.Ticks, 
					CurrTime.ToString(skipDateFormat));

				string insertCommand = 
					String.Format(CultureInfo.InvariantCulture,
					@"INSERT INTO dirDupe {0} VALUES {1};", what, values);

				Log.InfoFormat("{0}", insertCommand);

				sqlite_cmd.CommandText = insertCommand;
				sqlite_cmd.ExecuteNonQuery();
			}

			sqlite_conn.Close();

			Log.Info("<-");

			if ( !found )
				return false;
			else
				return true;
		}	
	}
}
