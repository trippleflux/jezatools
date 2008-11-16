#region

using System;
using System.Text.RegularExpressions;

#endregion

namespace TravianPlayer.Framework
{
	public class HtmlParser : IPageParser
	{
		public Game Parse()
		{
			throw new NotImplementedException();
		}

		public HtmlParser(string pageSource)
		{
			this.pageSource = pageSource;
		}

		public LoginInfo ParseLoginPage()
		{
			LoginInfo loginInfo = new LoginInfo();
			Regex regHiddenLoginValue = new Regex("<input type=\"hidden\" name=\"login\" value=\"(.*)\">");
			if (regHiddenLoginValue.IsMatch(pageSource))
			{
				Match Mc = regHiddenLoginValue.Matches(pageSource)[0];
				loginInfo.HiddenLoginValue = Mc.Groups[1].Value;
			}

			Regex regLoginName = new Regex("<input class=\"fm fm110\" type=\"text\" name=\"(.*)\" value=");
			if (regLoginName.IsMatch(pageSource))
			{
				Match Mc = regLoginName.Matches(pageSource)[0];
				loginInfo.TextBoxUserame = Mc.Groups[1].Value;
			}

			Regex regPasswordName = new Regex("<input class=\"fm fm110\" type=\"password\" name=\"(.*)\" value=");
			if (regPasswordName.IsMatch(pageSource))
			{
				Match Mc = regPasswordName.Matches(pageSource)[0];
				loginInfo.TextBoxPassword = Mc.Groups[1].Value;
			}

			Regex regHiddenName = new Regex("<p align=\"center\"><input type=\"hidden\" name=\"(.*)\" value=\"(.*)\">");
			if (regHiddenName.IsMatch(pageSource))
			{
				Match Mc = regHiddenName.Matches(pageSource)[0];
				loginInfo.HiddenName = Mc.Groups[1].Value;
				loginInfo.HiddenValue = Mc.Groups[2].Value;
			}
			return loginInfo;
		}

		public Game ParseResourcesPage()
		{
			Game gameInfo = new Game();
			ParseVillagesList(gameInfo);
			ParseUserId(gameInfo);
			ParseVillageName(gameInfo);
			ParseProduction(gameInfo);
			ParseResourcesProduction(gameInfo);
			ParseUnitsInVillage(gameInfo);
			return gameInfo;
		}

		private void ParseUnitsInVillage(Game gameInfo)
		{
			//<\/td><td align=\"right\">(.*)<b>\d+<\/b><\/td><td>\w+<\/td>
//            int villageId = gameInfo.GetVillageId(gameInfo.VillageName);
//            const string patternUnits =
//@"<img class=""unit"" src=""img\/un\/u\/\w+\.gif"" border=""\d+""><\/a><\/td><td align=""right"">(.*)<b>\d+<\/b><\/td><td>(\w+)<\/td>";
//            MatchCollection unitsCollection =
//                Regex.Matches(pageSource, patternUnits);
//            for (int i = 0; i < unitsCollection.Count; i++)
//            {
//                for (int j = 0; j < unitsCollection[i].Groups.Count;j++ )
//                {
//                    string a = unitsCollection[i].Groups[j].Value.Trim();
//                }
//                string unitName = unitsCollection[i].Groups[3].Value.Trim();
//                int unitCount = Int32.Parse(unitsCollection[i].Groups[2].Value.Trim());
//                Unit unit = new Unit(unitCount, unitName);
//                gameInfo.GetVillageData(villageId).AddUnit(unit);
//            }
		}

		private void ParseResourcesProduction(Game gameInfo)
		{
			//<area href="build.php?id=1" coords="101,33,28" shape="circle" title="Gozdar Stopnja 10">
			int villageId = gameInfo.GetVillageId(gameInfo.VillageName);
			const string patternResources =
@"<area href=""build.php.id=([0-9]{1,3})"" coords=""([0-9]{1,3}.)*"" shape=""circle"" title=""(((\w+\s)*)(\w+\s)(\d+))"">";
			MatchCollection resourcesCollection =
				Regex.Matches(pageSource, patternResources);
			for (int i = 0; i < resourcesCollection.Count; i++)
			{
				int resourceId = Int32.Parse(resourcesCollection[i].Groups[1].Value.Trim());
				int resourceLevel = Int32.Parse(resourcesCollection[i].Groups[7].Value.Trim());
				string resourceName = resourcesCollection[i].Groups[4].Value.Trim();
				Building building = new Building(resourceId, resourceName, resourceLevel);
				gameInfo.GetVillageData(villageId).AddBuilding(building);
			}
		}

		private void ParseProduction(Game gameInfo)
		{
			Production production = new Production();
			//wood
			Regex wood = new Regex(@"id=l4 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (wood.IsMatch(pageSource))
			{
				Match Mc = wood.Matches(pageSource)[0];
				production.WoodTotal = Int32.Parse(Mc.Groups[2].Value.Trim());
				production.WoodPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				production.WarehouseKapacity = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			//clay
			Regex clay = new Regex(@"id=l3 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (clay.IsMatch(pageSource))
			{
				Match Mc = clay.Matches(pageSource)[0];
				production.ClayTotal = Int32.Parse(Mc.Groups[2].Value.Trim());
				production.ClayPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				production.WarehouseKapacity = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			//iron
			Regex iron = new Regex(@"id=l2 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (iron.IsMatch(pageSource))
			{
				Match Mc = iron.Matches(pageSource)[0];
				production.IronTotal = Int32.Parse(Mc.Groups[2].Value.Trim());
				production.IronPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				production.WarehouseKapacity = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			//crop
			Regex crop = new Regex(@"id=l1 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (crop.IsMatch(pageSource))
			{
				Match Mc = crop.Matches(pageSource)[0];
				production.CropTotal = Int32.Parse(Mc.Groups[2].Value.Trim());
				production.CropPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				production.GranaryKapacity = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			int villageId = gameInfo.GetVillageId(gameInfo.VillageName);
			gameInfo.GetVillageData(villageId).Production = production;
		}

		public void ParseVillagesList(Game gameInfo)
		{
			//<a href="?newdid=83117">01</a>
			MatchCollection villagesCollection =
				Regex.Matches(pageSource, @"<a href="".newdid=(.*)\"">(.*)<.a>");
			int villageCount = villagesCollection.Count;
			for (int i = 0; i < villageCount; i++)
			{
				//102706" class="active_vl
				int villageId = Int32.Parse(GetOnlyNumbers(villagesCollection[i].Groups[1].Value));
				string villageName = villagesCollection[i].Groups[2].Value.Trim();
				Village village = new Village(villageId, villageName);
				gameInfo.AddVillage(village);
			}
			if (villageCount < 2)
			{
				const string regVillageName = @"<div class=""dname""><h1>(.*)</h1></div>";
				villagesCollection =
					Regex.Matches(pageSource, regVillageName);
				Village village = new Village(0, villagesCollection[0].Groups[1].Value.Trim());
				gameInfo.AddVillage(village);
			}
		}

		public void ParseVillageName(Game gameInfo)
		{
			//<h1>01</h1>
			Regex regVillageName = new Regex(@"<h1>(.*)</h1>");
			if (regVillageName.IsMatch(pageSource))
			{
				Match Mc = regVillageName.Matches(pageSource)[0];
				gameInfo.VillageName = Mc.Groups[1].Value.Trim();
			}
		}

		public void ParseUserId(Game gameInfo)
		{
			//<a href="spieler.php?uid=9500">Profil</a>
			gameInfo.UserId = -1;
			Regex regPlayerID = new Regex(@"<a href=""spieler.php.uid=([0-9]{0,6})"">");
			if (regPlayerID.IsMatch(pageSource))
			{
				Match Mc = regPlayerID.Matches(pageSource)[0];
				gameInfo.UserId = Int32.Parse(Mc.Groups[1].Value.Trim());
			}
		}

		/// <summary>
		/// Return only numbers from string.
		/// </summary>
		/// <param name="input">Input string</param>
		/// <returns>Parsed string</returns>
		/// 
		public static string GetOnlyNumbers(string input)
		{
			String a = "";
			for (int c = 0; c < input.Length; c++)
			{
				if (IsNumber(input[c]))
				{
					a += input[c];
				}
			}

			return a;
		}

		/// <summary>
		/// Checks if specified character is number.
		/// </summary>
		/// <param name="c"><see cref="char"/></param>
		/// <returns><c>true</c> if character is number</returns>
		/// 
		private static bool IsNumber(char c)
		{
			return Char.IsNumber(c);
		}

		private readonly string pageSource;
	}
}