using System;
using System.Globalization;
using System.Text;

using jcScripts.jcHelper;
using Finisar.SQLite;
using log4net;
using log4net.Config;

namespace jcScripts.jcDupe
{
	/// <summary>
	/// Summary description for UnDupe.
	/// </summary>
	public class UnDupe
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		
		public static void UnDupeDir(string[] args)
		{
			Log.Info("UnDupe.UnDupeDir");

			Global.undupe_dir = args[1];
			Log.InfoFormat("Un Dupe String = '{0}'", Global.undupe_dir);

			SQLiteConnection sqlite_conn;
			SQLiteCommand sqlite_cmd;
			SQLiteDataReader sqlite_datareader;

			string dbName = ConfigReader.GetConfig("dbDupeDir");
			string db = String.Format(CultureInfo.InvariantCulture, 
				@"Data Source={0};Version=3;New=False;Compress=True;", dbName);

			sqlite_conn = new SQLiteConnection(db);
			sqlite_conn.Open();
			sqlite_cmd = sqlite_conn.CreateCommand();

			string cmdText = 
				String.Format(CultureInfo.InvariantCulture, 
				"SELECT COUNT(*) FROM dirDupe WHERE ReleaseName = '{0}'", Global.undupe_dir);
			sqlite_cmd.CommandText = cmdText;
			sqlite_datareader=sqlite_cmd.ExecuteReader();

			int count = 0;

			while (sqlite_datareader.Read())
			{
				count = Int32.Parse(sqlite_datareader.GetValue(0).ToString());
			}
			
			sqlite_datareader.Close();

			if ( count > 0 )
			{
				string deleteCommand = 
					String.Format(CultureInfo.InvariantCulture,
					@"DELETE FROM dirDupe WHERE ReleaseName = '{0}'", Global.undupe_dir);

				Log.InfoFormat("{0}", deleteCommand);

				sqlite_cmd.CommandText = deleteCommand;
				sqlite_cmd.ExecuteNonQuery();

				Console.WriteLine(
					Format.FormatStr1ng(ConfigReader.GetConfig("msgUnDupes_ok"), 0, null));

			}
			else
			{
				Console.WriteLine(
					Format.FormatStr1ng(ConfigReader.GetConfig("msgUnDupes_fail"), 0, null));
			}

			sqlite_conn.Close();

			Log.Info("UnDupe.UnDupeDir");
		}
	}
}
