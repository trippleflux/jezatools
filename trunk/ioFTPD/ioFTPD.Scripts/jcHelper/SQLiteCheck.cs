using System;
using System.Globalization;
using System.IO;

using Finisar.SQLite;

using log4net;
using log4net.Config;

namespace jcScripts.jcHelper
{
	/// <summary>
	/// Summary description for SQLiteCheck.
	/// </summary>
	public class SQLiteCheck
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static bool CheckDupeDB(string dbName)
		{
			Log.Info("SQLiteCheck.CheckDupeDB");
			
			string fileName = ConfigReader.GetConfig(dbName);

			if ( File.Exists(fileName) )
			{
				Log.DebugFormat("DirDupe DB File '{0}/{1}' Is There.", dbName, fileName);
			}
			else
			{
				Log.DebugFormat("DirDupe DB File '{0}/{1}' Is Not There. Creating It...", dbName, fileName);

				SQLiteConnection sqlite_conn;
				SQLiteCommand sqlite_cmd;
				SQLiteDataReader sqlite_datareader;

				string db = String.Format(CultureInfo.InvariantCulture, 
					@"Data Source={0};Version=3;New=True;Compress=True;", fileName);
				sqlite_conn = new SQLiteConnection(db);

				sqlite_conn.Open();
				sqlite_cmd = sqlite_conn.CreateCommand();

				sqlite_cmd.CommandText = @"CREATE TABLE dirDupe (
					Id integer primary key, 
					ReleaseTime int(10),
					ReleaseDateTime varchar(19),
					ReleaseName varchar(256),
					Pwd varchar(256),
					Section varchar(32),
					UserName varchar(64),
					GroupName varchar(64),
					Wiped integer(1),
					Nuked integer(1),
					NukeReason varchar(64)
					);";
				sqlite_cmd.ExecuteNonQuery();

				sqlite_cmd.CommandText = @"CREATE INDEX DirDupeIndex ON dirDupe (ReleaseName);";
				sqlite_cmd.ExecuteNonQuery();

				Log.InfoFormat("Created Table dirDupe '{0}/{1}'", dbName, fileName);

				sqlite_cmd.CommandText = @"INSERT INTO dirDupe
					(ReleaseTime, ReleaseName, Pwd, Section, UserName, GroupName)
					VALUES (0, 'ReleaseName', '/test/ReleaseName', 'test', 'jcScripts', 'NoGroup');";
				sqlite_cmd.ExecuteNonQuery();

				Log.DebugFormat("SELECT * FROM dirDupe =");

				sqlite_cmd.CommandText = "SELECT * FROM dirDupe";
				sqlite_datareader=sqlite_cmd.ExecuteReader();

				// The SQLiteDataReader allows us to run through the result lines:
				while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
				{
					Log.DebugFormat("{1} {0}", sqlite_datareader["ReleaseName"], sqlite_datareader["Id"] );
				}

				sqlite_conn.Close();
			}

			Log.Info("SQLiteCheck.CheckDupeDB");
			
			return true;
		}
	}
}
