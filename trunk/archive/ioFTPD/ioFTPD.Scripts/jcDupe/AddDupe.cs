using System;
using System.Configuration;
using System.Globalization;

using jcScripts.jcHelper;
using Finisar.SQLite;

using log4net;
using log4net.Config;

namespace jcScripts.jcDupe
{
	/// <summary>
	/// Summary description for AddDupe.
	/// </summary>
	public class AddDupe
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// insert/update release name in DB
		/// </summary>
		/// <param name="args">args[1] is releasename</param>
		/// <returns></returns>
		public static bool AddUpdateDupe(string[] args)
		{
			Log.InfoFormat(" -> ");

			if (!SkipDupe.CheckSkipDirName(args))
			{
				Log.InfoFormat(" <- ");
				return false;
			}

			Global.dupe_name = IO.GetDirNameFromPwd(args[1]);
			Global.dupe_pwd = 
				String.Format(CultureInfo.InvariantCulture, "{0}{1}", Global.pwd, Global.dupe_name);

			Log.InfoFormat("Global.dupe_name={0}", Global.dupe_name);
			Log.InfoFormat("Global.dupe_pwd={0}", Global.dupe_pwd);

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
			sqlite_datareader=sqlite_cmd.ExecuteReader();

			bool found = false;
			DateTime CurrTime = DateTime.Now;
			string skipDateFormat = ConfigReader.GetConfig("skipDateFormat");

			while (sqlite_datareader.Read())
			{
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
					Global.user,
					Global.group,
					CurrTime.Ticks, 
					CurrTime.ToString(skipDateFormat));

				string insertCommand = 
					String.Format(CultureInfo.InvariantCulture,
					@"INSERT INTO dirDupe {0} VALUES {1};", what, values);

				Log.InfoFormat("{0}", insertCommand);

				sqlite_cmd.CommandText = insertCommand;
				sqlite_cmd.ExecuteNonQuery();
			}
			else
			{
				string updateCommand = 
					String.Format(CultureInfo.InvariantCulture,
					@"UPDATE dirDupe SET Pwd = '{0}' WHERE ReleaseName = '{1}';",
					Global.dupe_pwd, Global.dupe_name);

				Log.InfoFormat("{0}", updateCommand);

				sqlite_cmd.CommandText = updateCommand;
				sqlite_cmd.ExecuteNonQuery();
			}

			sqlite_conn.Close();

			Log.Info("<-");

			if ( found )
			{
				Console.WriteLine(
					Format.FormatStr1ng( 
					ConfigReader.GetConfig("msgAddDupe_update"), 0, null
					));
			}
			else
			{
				Console.WriteLine(
					Format.FormatStr1ng( 
					ConfigReader.GetConfig("msgAddDupe_insert"), 0, null
					));
			}
			
			return true;

		}
	}
}
