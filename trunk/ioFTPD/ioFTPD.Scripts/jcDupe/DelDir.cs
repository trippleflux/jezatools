using System;
using System.Globalization;

using jcScripts.jcHelper;
using Finisar.SQLite;

using log4net;
using log4net.Config;

namespace jcScripts.jcDupe
{
	/// <summary>
	/// Summary description for DelDir.
	/// </summary>
	public class DelDir
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// OnDelDir delete dir from DB if its there
		/// </summary>
		/// <param name="args">input arguments</param>
		/// <returns><c>true</c> if dir was deleted</returns>
		public static bool CheckDupeDelDir(string[] args)
		{
			Log.Info("DelDir.CheckDupeDelDir");

			if (!SkipDupe.CheckSkipDupe(args))
			{
				Log.Info("DelDir.CheckDupeDelDir");
                return true;
			}

			SQLiteConnection sqlite_conn;
			SQLiteCommand sqlite_cmd;

			string dbName = ConfigReader.GetConfig("dbDupeDir");
			string db = String.Format(CultureInfo.InvariantCulture, 
				@"Data Source={0};Version=3;New=False;Compress=True;", dbName);
			sqlite_conn = new SQLiteConnection(db);
			sqlite_conn.Open();
			sqlite_cmd = sqlite_conn.CreateCommand();

			string dbCommand = String.Format(CultureInfo.InvariantCulture, 
				@"DELETE FROM dirDupe WHERE ReleaseName = '{0}'", Global.dupe_name);
			
			Log.InfoFormat("{0}", dbCommand);
			
			sqlite_cmd.CommandText = dbCommand;
			sqlite_cmd.ExecuteNonQuery();

			sqlite_conn.Close();

			Log.Info("DelDir.CheckDupeDelDir");

			return true;
		}
	}
}
