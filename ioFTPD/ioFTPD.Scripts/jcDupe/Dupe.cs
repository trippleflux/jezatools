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
	/// Summary description for Dupe.
	/// </summary>
	public class Dupe
	{
		public static readonly ILog Log = 
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static void ShowDupes(string[] args)
		{
			Log.Info("Dupe.ShowDupes");

			StringBuilder dupe = new StringBuilder();
			dupe.AppendFormat(CultureInfo.InvariantCulture, "%");
			for (int i = 1 ; i < args.Length ; i++)
			{
				dupe.AppendFormat(CultureInfo.InvariantCulture, "{0}%", args[i]);
			}
			Log.InfoFormat("Dupe String = '{0}'", dupe.ToString());
			Global.dupe_listsearch = dupe.ToString();

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
				"SELECT * FROM dirDupe WHERE ReleaseName LIKE '{0}' ORDER BY ReleaseTime DESC", dupe.ToString());
			sqlite_cmd.CommandText = cmdText;
			sqlite_datareader=sqlite_cmd.ExecuteReader();
			int count = 0;

			Console.WriteLine(
				Format.FormatStr1ng( 
				ConfigReader.GetConfig("msgListDupes_head"), 0, null
				));

			int maxShowDupes = Int32.Parse(Global.dupe_listtotal);

			while (sqlite_datareader.Read())
			{
				if ( count < maxShowDupes )
				{
					DateTime dt = 
						new DateTime(Int64.Parse(sqlite_datareader["ReleaseTime"].ToString()));
					string dateFormat = ConfigReader.GetConfig("dupeDateFormat");
					Global.dupe_listdatetime = dt.ToString(dateFormat);
					Global.dupe_listpwd = sqlite_datareader["Pwd"].ToString();
					Console.WriteLine(
						Format.FormatStr1ng( 
						ConfigReader.GetConfig("msgListDupes_body"), 0, null
						));
				}

				count++;
			}
			
			sqlite_datareader.Close();

			sqlite_cmd.CommandText = "SELECT COUNT(*) FROM dirDupe";
			sqlite_datareader=sqlite_cmd.ExecuteReader();
			int totalCount = 0;
			while (sqlite_datareader.Read())
			{
				totalCount = Int32.Parse(sqlite_datareader.GetValue(0).ToString());
			}
			sqlite_datareader.Close();
			sqlite_conn.Close();

			Global.dupe_total = totalCount.ToString();

			if ( count <= maxShowDupes )
			{
				Global.dupe_listfound = count.ToString();
				Global.dupe_listtotal = count.ToString();
			}
			else
			{
				Global.dupe_listfound = Global.dupe_listtotal;
				Global.dupe_listtotal = count.ToString();
			}

			Console.WriteLine(
				Format.FormatStr1ng( 
				ConfigReader.GetConfig("msgListDupes_foot"), 0, null
				));

			Log.Info("Dupe.ShowDupes");
		}
	}
}
