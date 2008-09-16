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
		/// <param name="getPlayerID"></param>
		/// 
        public Data(String pageContent, bool getPlayerID, bool getVillageIDs, bool getResouresLevel, bool getBuildingsLevel)
		{
            if (getPlayerID)
            {
                Regex regPlayerID = new Regex("<a href=\"spieler.php.uid=(.*)\">Profil<.a>");
                if (regPlayerID.IsMatch(pageContent))
                {
                    Match Mc = regPlayerID.Matches(pageContent)[0];
                    playerUID = Mc.Groups[1].Value;
                }
            }

            if (getVillageIDs)
            {
                MatchCollection myMatchCollection =
                    Regex.Matches(pageContent, "<a href=\".newdid=(.*)\">(.*)<.a>");
                for (int i = 0; i < myMatchCollection.Count; i++)
                {
                    //102706" class="active_vl
                    string regEx = myMatchCollection[i].Groups[1].Value;
                    villagesList.Add(GetOnlyNumbers(regEx) + "|" + myMatchCollection[i].Groups[2].Value);
                }
            }

			if (getResouresLevel)
			{
				MatchCollection resourcesCollection =
					Regex.Matches(pageContent, @"<area href=""build.php.id=[0-9]{1,3}"" coords=""[0-9]{1,3},[0-9]{1,3},[0-9]{1,3}"" shape=""circle"" title=""(\w|\d|\s)*[0-9]{1,2}"">");
				for (int i = 0; i < resourcesCollection.Count; i++)
				{
					Console.WriteLine("*** " + resourcesCollection[i].Groups[0].Value);
				}
			}

            if (getBuildingsLevel)
            {
                //MatchCollection resourcesCollection =
                //    Regex.Matches(pageContent, @"<area href=""build.php.id=[0-9]{1,3}"" coords=""[0-9]{1,3},[0-9]{1,3},[0-9]{1,3}"" shape=""circle"" title=""(\w|\d|\s)*[0-9]{1,2}"">");
                //for (int i = 0; i < resourcesCollection.Count; i++)
                //{
                //    Console.WriteLine("*** " + resourcesCollection[i].Groups[0].Value);
                //}
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
		public string PlayerUID
		{
			get { return playerUID; }
			set { playerUID = value; }
		}

		private string playerUID;

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
	}
}
