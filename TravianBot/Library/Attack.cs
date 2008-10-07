#region

using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

#endregion

namespace Library
{
	public class Attack
	{
		public void CheckFarmList(ServerData sd)
		{
			DataTable dt = SQL.GetFarmList(sd);
			if (dt.Rows.Count == 0)
			{
				SQL.UpdateAttackInProgress(sd, 0);
			}
			else
			{
				foreach (DataRow row in dt.Rows)
				{
					int villageId = Int32.Parse(row[1].ToString().Trim());
					int neededTroops = Int32.Parse(row[7].ToString().Trim());
					//Console.WriteLine("Check in {0}", villageId);
					string url = String.Format(CultureInfo.InvariantCulture, "{0}dorf1.php?newdid={1}", sd.Servername, villageId);
					Browser browser = new Browser();
					string pageSource = browser.GetPageSource(url);

					int availableTroops = GetAvailableTroops(row, pageSource);
					Console.WriteLine("We Need '{0}' Troops And We Have '{1}'", neededTroops, availableTroops);
					if (availableTroops >= neededTroops)
					{
						Random rnd = new Random();
						Int32 parA = rnd.Next(10001, 99999);
						Int32 parC = Int32.Parse(row[4].ToString().Trim());
						Int32 coordX = Int32.Parse(row[2].ToString().Trim());
						Int32 coordY = Int32.Parse(row[3].ToString().Trim());
						Int32 parKID = tbLibrary.ConvertXY2Z(coordX, coordY);
						String parTroops = row[5].ToString().Trim();
						String buttonCords = String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19));
						String postData = String.Format(CultureInfo.InvariantCulture, "id=39&a={0}&c={1}&kid={2}{3}{4}", parA, parC,
						                                parKID,
						                                parTroops, buttonCords);
						url = String.Format(CultureInfo.InvariantCulture, "{0}a2b.php?newdid={1}", sd.Servername, villageId);
						String pageSourcePost;
						browser.PostData(url, postData, out pageSourcePost);
						//int farmListId = Int32.Parse(row[0].ToString().Trim());
						//SQL.UpdateAttackInProgress(sd, farmListId, 1);
						Console.WriteLine("ATTACK: {0} - {1}", postData, row[8]);
						Thread.Sleep(1000);
					}
					else
					{
						break;
					}
				}
			}
		}



		private static int GetAvailableTroops
			(DataRow row,
			 string pageSource)
		{
			int availableTroops = 0;
			string troopName = row[6].ToString().Trim();
			//Console.WriteLine("Searching for '{0}'", troopName);
			//<td align="right">&nbsp;<b>28</b></td><td>Gorjačarjev</td>
			Regex regExTroopName =
				new Regex(String.Format(CultureInfo.InvariantCulture, @"<b>([0-9]{{0,6}})<\/b><\/td><td>{0}<\/td>", troopName));
			if (regExTroopName.IsMatch(pageSource))
			{
				Match Mc = regExTroopName.Matches(pageSource)[0];
				availableTroops = Int32.Parse(Mc.Groups[1].Value.Trim());
			}
			return availableTroops;
		}
	}
}