using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace jcTBotLibrary
{
	/// <summary>
	/// Data (player UID, villagenames, ...) about player.
	/// </summary>
	public class Data
	{
		/// <summary>
		/// Gets Granary, Warehouse, production...
		/// </summary>
		/// <param name="pageContent">Page source</param>
		/// <param name="getVillageIDs"></param>
		/// <param name="getResouresLevel">Gets level of the resources in village</param>
		/// <param name="getBuildingsLevel">Gets level of the buildings in village</param>
		/// <param name="getPlayerID">ID of the player</param>
		/// <param name="getproduction">Gets city resources production and kapacity</param>
		/// 
        public Data(
			String pageContent, 
			bool getPlayerID, 
			bool getVillageIDs, 
			bool getResouresLevel, 
			bool getBuildingsLevel,
			bool getproduction)
		{
            if (getPlayerID)
            {
            	PlayerUID = -1;
				Regex regPlayerID = new Regex(@"<a href=""spieler.php.uid=([0-9]{0,6})"">");
                if (regPlayerID.IsMatch(pageContent))
                {
                    Match Mc = regPlayerID.Matches(pageContent)[0];
					playerUID = Int32.Parse(Mc.Groups[1].Value.Trim());
                }
            }

            if (getVillageIDs)
            {
				//<div class="dname"><h1>Muta01</h1></div> - one village!!! ?newdid=0
				MatchCollection myMatchCollection =
                    Regex.Matches(pageContent, @"<a href="".newdid=(.*)\"">(.*)<.a>");
            	int villageCount = myMatchCollection.Count;
                for (int i = 0; i < villageCount; i++)
                {
                    //102706" class="active_vl
                    string regEx = myMatchCollection[i].Groups[1].Value;
					Village v = new Village();
					v.VillageId = GetOnlyNumbers(regEx);
                	v.VillageName = myMatchCollection[i].Groups[2].Value.Trim();
                	VillagesList.Add(v);
                }
				if (villageCount < 2)
				{
					const string regVillageName = @"<div class=""dname""><h1>(.*)</h1></div>";
					myMatchCollection =
		                Regex.Matches(pageContent, regVillageName);
					Village v = new Village();
					v.VillageId = "0";
					v.VillageName = myMatchCollection[0].Groups[1].Value.Trim();
					VillagesList.Add(v);
				}
            }

			if (getResouresLevel)
			{
				MatchCollection resourcesCollection =
					Regex.Matches(pageContent, @"<area href=""build.php.id=([0-9]{1,3})"" coords=""([0-9]{1,3}.)*"" shape=""circle"" title=""((\w|\d|\s)*)"">");
				for (int i = 0; i < resourcesCollection.Count; i++)
				{
					Resources r = new Resources();
					r.ResourceId = Int32.Parse(resourcesCollection[i].Groups[1].Value.Trim());
					string name = resourcesCollection[i].Groups[3].Value.Trim();
					string[] nameLevel = name.Split(' ');
					int nameLevelLength = nameLevel.Length;
					r.ResourceLevel = Int32.Parse(nameLevel[nameLevelLength - 1]);
					for (int n = 0; n < nameLevelLength - 2; n++)
					{
						r.ResourceName += nameLevel[n] + " ";
					}
					ResourcesId rId = new ResourcesId();
					rId.ResourcesVillageId.Add(r);
					ResourcesList.Add(rId);
				}
			}

			//<area href="build.php?id=19" title="Žitnica Stopnja 20" coords="53,91,53,37,128,37,128,91,91,112" shape="poly">
			if (getBuildingsLevel)
			{
				const string reg = @"<area href=""build.php.id=([0-9]{1,3})"" title=""((\w|\d|\s)*)"" coords=""([0-9]{1,3}.)*"" shape=""poly"">";
				MatchCollection buildingsCollection = Regex.Matches(pageContent, reg);
				for (int i = 0; i < buildingsCollection.Count; i++)
				{
					Buildings b = new Buildings();
					b.BuildingId = Int32.Parse(buildingsCollection[i].Groups[1].Value.Trim());
					string name = buildingsCollection[i].Groups[3].Value.Trim();
					string[] nameLevel = name.Split(' ');
					int nameLevelLength = nameLevel.Length;
					b.BuildingLevel = Int32.Parse(nameLevel[nameLevelLength - 1]);
					for (int n = 0; n < nameLevelLength - 2; n++)
					{
						b.BuildingName += nameLevel[n] + " ";
					}
					BuildingsId bId = new BuildingsId();
					bId.BuildingsVillageId.Add(b);
					BuildingsList.Add(bId);
				}
			}

			/*
<table align="center" cellspacing="0" cellpadding="0"><tr valign="top">
<td><img class="res" src="img/un/r/1.gif" title="Les"></td>
<td id=l4 title=132>3766/7800</td>

<td class="s7"> <img class="res" src="img/un/r/2.gif" title="Glina"></td>
<td id=l3 title=127>3541/7800</td>
<td class="s7"> <img class="res" src="img/un/r/3.gif" title="Železo"></td>
<td id=l2 title=121>4032/7800</td><td class="s7"> <img class="res" src="img/un/r/4.gif" title="Žito"></td>
<td id=l1 title=93>2095/2300</td>
<td class="s7"> &nbsp;<img class="res" src="img/un/r/5.gif" title="Poraba žita">&nbsp;122/215</td></tr></table>
			 */
			if (getproduction)
			{
				Production p = new Production();
				//wood
				string reg = @"id=l4 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<";
				MatchCollection resourcesKapacity = Regex.Matches(pageContent, reg);
				p.Wood = Int32.Parse(resourcesKapacity[0].Groups[2].Value.Trim());
				p.WoodPerHour = Int32.Parse(resourcesKapacity[0].Groups[1].Value.Trim());
				//clay
				reg = @"id=l3 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<";
				resourcesKapacity = Regex.Matches(pageContent, reg);
				p.Clay = Int32.Parse(resourcesKapacity[0].Groups[2].Value.Trim());
				p.ClayPerHour = Int32.Parse(resourcesKapacity[0].Groups[1].Value.Trim());
				//iron
				reg = @"id=l2 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<";
				resourcesKapacity = Regex.Matches(pageContent, reg);
				p.Iron = Int32.Parse(resourcesKapacity[0].Groups[2].Value.Trim());
				p.IronPerHour = Int32.Parse(resourcesKapacity[0].Groups[1].Value.Trim());
				p.WarehouseKapacity = Int32.Parse(resourcesKapacity[0].Groups[3].Value.Trim());
				//crop
				reg = @"id=l1 title=(.*)>([0-9]{1,7}).([0-9]{1,7})<";
				resourcesKapacity = Regex.Matches(pageContent, reg);
				p.Crop = Int32.Parse(resourcesKapacity[0].Groups[2].Value.Trim());
				p.CropPerHour = Int32.Parse(resourcesKapacity[0].Groups[1].Value.Trim());
				p.GranaryKapacity = Int32.Parse(resourcesKapacity[0].Groups[3].Value.Trim());

				productionList.Add(p);
			}

		}

		private static string GetOnlyNumbers(string input)
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

		private static bool IsNumber(char c)
		{
			return char.IsNumber(c);
		}

		/// <summary>
		/// //<a href="spieler.php?uid=8226">Profil</a>
		/// </summary>
		public int PlayerUID
		{
			get { return playerUID; }
			set { playerUID = value; }
		}

		private int playerUID;

		/// <summary>
		/// <a href="?newdid=10902">Muta01</a>
		/// <a href="?newdid=10903">Muta02</a>
		/// ...
		/// </summary>
		/// <remarks>
		/// List is in format villageID|villageName
		/// </remarks>
		/// <example>
		/// 10902|Muta01
		/// </example>
		public ArrayList VillagesList
		{
			get { return villagesList; }
			set { villagesList = value; }
		}

		private ArrayList villagesList = new ArrayList();

		public ArrayList ProductionList
		{
			get { return productionList; }
			set { productionList = value; }
		}

		private ArrayList productionList = new ArrayList();

		public ArrayList ResourcesList
		{
			get { return resourcesList; }
			set { resourcesList = value; }
		}

		private ArrayList resourcesList = new ArrayList();

		private ArrayList buildingsList = new ArrayList();

		public ArrayList BuildingsList
		{
			get { return buildingsList; }
			set { buildingsList = value; }
		}
	}
}
