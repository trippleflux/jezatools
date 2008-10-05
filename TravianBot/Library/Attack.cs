#region

using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

namespace Library
{
	public class Attack
	{
		public void CheckFarmList(ServerData sd)
		{
			DataTable dt = SQL.GetFarmList(sd);
			foreach (DataRow row in dt.Rows)
			{
				int villageId = Int32.Parse(row[1].ToString().Trim());
				int neededTroops = Int32.Parse(row[7].ToString().Trim());

				string url = String.Format(CultureInfo.InvariantCulture, "{0}dorf1.php?newdid={1}", sd.Servername, villageId);
				Browser browser = new Browser();
				string pageSource = browser.GetPageSource(url);

				int availableTroops = GetAvailableTroops(row, pageSource);
				if (availableTroops >= neededTroops)
				{
					//attack
				}
			}
		}



		private static int GetAvailableTroops
			(DataRow row,
			 string pageSource)
		{
			int availableTroops = 0;
			string troopName = row[6].ToString().Trim();
			Regex regExTroopName =
				new Regex(string.Format(@"<td align=""right"">(.*)<b>([0-9]{{0,6}})<\\/b><\\/td><td>{0}<\/td>", troopName));
			if (regExTroopName.IsMatch(pageSource))
			{
				Match Mc = regExTroopName.Matches(pageSource)[0];
				availableTroops = Int32.Parse(Mc.Groups[2].Value.Trim());
			}
			return availableTroops;
		}
	}
}