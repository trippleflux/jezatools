using System;
using System.Globalization;

using jcScripts.jcHelper;
using Finisar.SQLite;

using log4net;
using log4net.Config;

namespace jcScripts.jcDupe
{
	/// <summary>
	/// Summary description for jcD.
	/// </summary>
	public class ImportDupes
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static void ImportFromjScripts()
		{
			Log.Info("->");
			
			SQLiteConnection sqlite_conn_jcS, sqlite_conn_jS;
			SQLiteCommand sqlite_cmd_jcS, sqlite_cmd_jS;
			SQLiteDataReader sqlite_datareader_jcS, sqlite_datareader_jS;

			string dbName = ConfigReader.GetConfig("dbDupeDir");
			string db_jcS = String.Format(CultureInfo.InvariantCulture, 
				@"Data Source={0};Version=3;New=False;Compress=True;", dbName);

			string db_jS = String.Format(CultureInfo.InvariantCulture, 
				@"Data Source=jScripts.dupe.dir.db;Version=3;New=False;Compress=True;");
			sqlite_conn_jcS = new SQLiteConnection(db_jcS);
			sqlite_conn_jcS.Open();
			sqlite_cmd_jcS = sqlite_conn_jcS.CreateCommand();

			sqlite_conn_jS = new SQLiteConnection(db_jS);
			sqlite_conn_jS.Open();
			sqlite_cmd_jS = sqlite_conn_jS.CreateCommand();

			//sqlite_cmd_jS.CommandText = "SELECT * FROM DIRDUPE WHERE ReleaseName like 'UFC.61.Bitter.Rivals.DSRip.Xvid-MaM'";
			sqlite_cmd_jS.CommandText = "SELECT * FROM DIRDUPE";
			sqlite_datareader_jS=sqlite_cmd_jS.ExecuteReader();

			DateTime linuxTime = new DateTime(1970,1,1,0,0,0);
			string skipDateFormat = ConfigReader.GetConfig("skipDateFormat");
			int count = 0;
			
			while (sqlite_datareader_jS.Read())
			{
				string cmdText = 
					String.Format(CultureInfo.InvariantCulture, 
						"SELECT COUNT(*) FROM dirDupe WHERE ReleaseName = '{0}'", 
					sqlite_datareader_jS["ReleaseName"].ToString());
				sqlite_cmd_jcS.CommandText = cmdText;
				sqlite_datareader_jcS=sqlite_cmd_jcS.ExecuteReader();
				bool found = false;
				while (sqlite_datareader_jcS.Read())
				{
					if ( Int32.Parse(sqlite_datareader_jcS.GetValue(0).ToString()) == 0 )
					{
						found = true;
					}
				}
				sqlite_datareader_jcS.Close();

				if ( found )
				{
					long dbTime = 
						Int64.Parse(sqlite_datareader_jS["ReleaseTime"].ToString() + "0000000");
					long dbNanoTime = dbTime + linuxTime.Ticks;
					DateTime dt = new DateTime(dbNanoTime);

					string what = "(ReleaseTime, ReleaseDateTime, ReleaseName, Pwd, UserName, GroupName)";
					string values = String.Format(CultureInfo.InvariantCulture, 
							"({4}, '{5}', '{0}', '{1}', '{2}', '{3}')",
							sqlite_datareader_jS["ReleaseName"].ToString(), 
							sqlite_datareader_jS["Pwd"].ToString(), 
							sqlite_datareader_jS["UserName"].ToString(), 
							sqlite_datareader_jS["GroupName"].ToString(), 
							dt.Ticks, 
							dt.ToString(skipDateFormat));

					string insertCommand = 
						String.Format(CultureInfo.InvariantCulture,
						@"INSERT INTO dirDupe {0} VALUES {1};", what, values);

					Log.DebugFormat("{0}", insertCommand);
					Console.WriteLine("{0}", sqlite_datareader_jS["ReleaseName"].ToString());

					sqlite_cmd_jcS.CommandText = insertCommand;
					sqlite_cmd_jcS.ExecuteNonQuery();
					found = false;
					count++;
				}
			}

			sqlite_datareader_jS.Close();
			Log.DebugFormat("Total {0} Releases Added", count);
			Console.WriteLine("\nTotal {0} Releases Added", count);
			
			sqlite_conn_jS.Close();		
			sqlite_conn_jcS.Close();
	
			Log.Info("<-");
		}
	}
}
