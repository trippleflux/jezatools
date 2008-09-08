using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace jcTBotClient
{
	/// <summary>
	/// Data (player UID, villagenames, ...) about player.
	/// </summary>
	public class Data
	{
		public Data(String pageContent, bool getResouresLevel, bool getBuildingsLevel)
		{
			Regex regPlayerID = new Regex("<a href=\"spieler.php.uid=(.*)\">Profil<.a>");
			if (regPlayerID.IsMatch(pageContent))
			{
				Match Mc = regPlayerID.Matches(pageContent)[0];
				playerUID = Mc.Groups[1].Value;
			}

			MatchCollection myMatchCollection = 
				Regex.Matches(pageContent, "<a href=\".newdid=(.*)\">(.*)<.a>");
			for (int i = 0; i < myMatchCollection.Count;i++ )
			{
				//102706" class="active_vl
				string regEx = myMatchCollection[i].Groups[1].Value;
				villagesList.Add(GetOnlyNumbers(regEx) + "|" + myMatchCollection[i].Groups[2].Value);
			}

			//<area href=\"build.php.id=\d\" coords=\"[0-9]{1,3}\,[0-9]{1,3}\,[0-9]{1,3}\" shape=\"circle\" title=\"(\w|\d|\s)*[0-9]{1,2}\">
			if (getResouresLevel)
			{
				MatchCollection resourcesCollection =
					Regex.Matches(pageContent, @"<area href=""build.php.id=[0-9]{1,3}"" coords=""[0-9]{1,3},[0-9]{1,3},[0-9]{1,3}"" shape=""circle"" title=""(\w|\d|\s)*[0-9]{1,2}"">");
				for (int i = 0; i < resourcesCollection.Count; i++)
				{
					Console.WriteLine("*** " + resourcesCollection[i].Groups[0].Value);
					//for (int c=0;c<resourcesCollection[i].Groups.Count;c++)
					//{
					//    Console.WriteLine("*** " + resourcesCollection[i].Groups[c].Value);
					//}
				}
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
