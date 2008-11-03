#region

using System;
using System.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using mshtml;
using SHDocVw;

#endregion

namespace twL
{
	public class Browser
	{
		public static HTMLDocument GetPageSource
			(String url,
			 IWebBrowser2 ie)
		{
			object nullRef = null;
			ie.Navigate(url, ref nullRef, ref nullRef, ref nullRef, ref nullRef);
			WaitForComplete(ie);
			return (HTMLDocument) ie.Document;
		}



		public static HTMLDocument Login
			(ServerInfo si,
			 PlayerInfo pi,
			 InternetExplorer ie)
		{
			Console.WriteLine("Login to '{2}' as '{0}' with password '{1}'...", pi.Username, pi.Password, si.ServerUrl);
			GetPageSource(si.LoginPage, ie);
			string name = NameFromTagAndType(ie, "input", "text");
			string pass = NameFromTagAndType(ie, "input", "password");
			//Console.WriteLine(name);
			//Console.WriteLine(pass);
			if (name == String.Empty || pass == String.Empty)
			{
				return null;
			}
			HTMLDocument myDoc = (HTMLDocument) ie.Document;
			HTMLInputElement loginUsernameTextBox = (HTMLInputElement) myDoc.all.item(name, 0);
			loginUsernameTextBox.value = pi.Username;
			HTMLInputElement loginPasswordTextBox = (HTMLInputElement) myDoc.all.item(pass, 0);
			loginPasswordTextBox.value = pi.Password;
			String loginImageButtonName = NameFromTagAndType(ie, "input", "image");
			HTMLInputElement loginImageButton = (HTMLInputElement) myDoc.all.item(loginImageButtonName, 0);
			loginImageButton.click();
			WaitForComplete(ie);
			return myDoc;
		}



		public static void WaitForComplete(IWebBrowser2 ieWAIT)
		{
			do
			{
				Thread.Sleep(500);
			} while (ieWAIT.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE);
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="ie"></param>
		/// <param name="tag"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		private static string NameFromTagAndType
			(IWebBrowser2 ie,
			 string tag,
			 string type)
		{
			String name = String.Empty;
			IHTMLDocument3 doc3 = (IHTMLDocument3) ie.Document;
			IHTMLElementCollection coll = doc3.getElementsByTagName(tag);
			foreach (IHTMLElement elm in coll)
			{
				if (elm.getAttribute("type", 0).ToString().ToLower() == type)
				{
					name = elm.getAttribute("name", 0).ToString();
					break;
				}
			}
			return name;
		}



		/// <summary>
		/// Gets upgrade url from TAG and ATTRIBUTE
		/// </summary>
		/// <param name="ie"></param>
		/// <param name="tag"></param>
		/// <param name="attribute"></param>
		/// <returns></returns>
		/// 
		private static string UpgradeLinkFromTagAndAttribute
			(IWebBrowser2 ie,
			 string tag,
			 string attribute)
		{
			String name = String.Empty;
			IHTMLDocument3 doc3 = (IHTMLDocument3) ie.Document;
			IHTMLElementCollection coll = doc3.getElementsByTagName(tag);
			foreach (IHTMLElement elm in coll)
			{
				String attr = elm.getAttribute(attribute, 0).ToString();
				//<a href="dorf1.php?a=16&c=36e">Nadgradi na stopnjo 4</a>
				if ((attr.IndexOf("dorf1.php?a=") > -1)
				    || (attr.IndexOf("dorf2.php?a=") > -1))
				{
					name = attr;
					break;
				}
			}
			return name;
		}



		/// <summary>
		/// Finds and returns <c>innerText</c> from first element with TagName <c>tag</c>
		/// </summary>
		/// <param name="ie"><see cref="IWebBrowser2"/></param>
		/// <param name="tag">HTML tag</param>
		/// <returns><c>innerText</c> of the TAG or <c>String.Empty</c></returns>
		/// 
		public static string FirstNameFromTag
			(InternetExplorer ie,
			 String tag)
		{
			String name = String.Empty;
			IHTMLDocument3 doc3 = (IHTMLDocument3) ie.Document;
			IHTMLElementCollection coll = doc3.getElementsByTagName(tag);
			foreach (IHTMLElement elm in coll)
			{
				name = elm.innerText;
				break;
			}
			return name;
		}



		///// <summary>
		///// 
		///// </summary>
		///// <param name="ie"></param>
		///// <param name="tag"></param>
		///// <param name="type"></param>
		///// <param name="name"></param>
		///// <returns></returns>
		///// 
		//private static string ValueFromTagTypeAndName
		//    (IWebBrowser2 ie,
		//     string tag,
		//     string type,
		//     string name)
		//{
		//    String value = String.Empty;
		//    IHTMLDocument3 doc3 = (IHTMLDocument3) ie.Document;
		//    IHTMLElementCollection coll = doc3.getElementsByTagName(tag);
		//    foreach (IHTMLElement elm in coll)
		//    {
		//        if (elm.getAttribute("type", 0).ToString().ToLower() == type)
		//        {
		//            if (elm.getAttribute("name", 0).ToString() == name)
		//            {
		//                value = elm.getAttribute("value", 0).ToString();
		//                break;
		//            }
		//        }
		//    }
		//    return value;
		//}

		public static DateTime TryToBuild
			(InternetExplorer ie,
			 BuildTask bt,
			 ServerInfo si)
		{
			//http://s6.travian.si/build.php?newdid=73913&id=6
			string buildUrl = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}&id={2}",
			                                si.UpgradeBuildingPage, bt.VillageId, bt.BuildingId);
			GetPageSource(buildUrl, ie);
			//<h1><b>Glinokop Stopnja 2</b></h1>
			string headName = FirstNameFromTag(ie, "h1");
			//Console.WriteLine(headName);
			if ((headName.IndexOf(Misc.GetConfigValue("emptyBuilding")) > -1) || (headName.IndexOf(' ') == -1))
			{
				Console.WriteLine("Building on Id '{0}' not fouond! ['{1}']", bt.BuildingId, headName);
			}
			else
			{
				String[] head = headName.Split(' ');
				Int32 buildingLevel = Int32.Parse(head[head.Length - 1]);
				if (buildingLevel < bt.WantedBuildingLevel)
				{
					//<a href="dorf1.php?a=16&c=36e">Nadgradi na stopnjo 4</a>
					Console.WriteLine("Trying to upgrade {0}", headName);
					string link = UpgradeLinkFromTagAndAttribute(ie, "a", "href");
					if (!link.Equals(String.Empty))
					{
						Console.WriteLine("Upgrading {0}'{1}'", headName, bt.VillageId);
						GetPageSource(link, ie);
					}
				}
			}
            string nextCheckUrl = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}",
                                        si.ResourcesPage, bt.VillageId);
            HTMLDocument source = GetPageSource(nextCheckUrl, ie);
			String pageSource = source.body.innerHTML.ToLower(CultureInfo.InvariantCulture);
			String nextCheck = Misc.TimeToCompleteBuilding(pageSource);
			bt.NextCheck = Misc.AddSecondsToTime(nextCheck.Split(':'));
			Console.WriteLine("Next check for '{0}' in VillageId '{1}' at '{2}'", headName, bt.VillageId, bt.NextCheck);
			return bt.NextCheck;
		}



		public static bool IsLogedIn
			(HTMLDocument source,
			 PlayerInfo pi)
		{
			pi.Uid = -1;
			Regex regPlayerID = new Regex(@"<a href=""spieler.php.uid=([0-9]{0,6})"">");
			String pageSource = source.body.innerHTML.ToLower(CultureInfo.InvariantCulture);
			//Console.WriteLine(pageSource);
			if (regPlayerID.IsMatch(pageSource))
			{
				Match Mc = regPlayerID.Matches(pageSource)[0];
				pi.Uid = Int32.Parse(Mc.Groups[1].Value.Trim());
			}
			return pi.Uid > -1 ? true : false;
		}



		public static DateTime NextCheck
			(String buildingUrl,
			 IWebBrowser2 ie)
		{
			HTMLDocument source = GetPageSource(buildingUrl, ie);
			String pageSource = source.body.innerHTML.ToLower(CultureInfo.InvariantCulture);
			VillageInfo vi = GetProductionForVillage(pageSource);
			UpgradeCosts upgradeCosts = GetUpgradeCostsForBuilding(pageSource);
			Console.WriteLine(vi.AvailableResources());
			Console.WriteLine(vi.ProductionPerHour());
			Console.WriteLine(upgradeCosts.ToString());
			int[] list = Misc.GetUpgradeList(vi, upgradeCosts);
			DateTime dt = new DateTime(DateTime.Now.Ticks);
			return dt.AddSeconds(list[0] < 0 ? Math.Abs(list[0]) : 0);
		}



		public static UpgradeCosts GetUpgradeCostsForBuilding(string pageSource)
		{
			//<img class="res" src="img/un/r/1.gif">6050
			UpgradeCosts upgradeCosts = new UpgradeCosts();
			const string reg = @"class=((res|""res"")) src=""img\/un\/r\/[1234].gif"">([0-9]{0,6})";
			MatchCollection neededResourcesCollection = Regex.Matches(pageSource, reg);
			if (neededResourcesCollection.Count > 0)
			{
				upgradeCosts.BuildingWoodCost = Int32.Parse(neededResourcesCollection[0].Groups[3].Value.Trim());
				upgradeCosts.BuildingClayCost = Int32.Parse(neededResourcesCollection[1].Groups[3].Value.Trim());
				upgradeCosts.BuildingIronCost = Int32.Parse(neededResourcesCollection[2].Groups[3].Value.Trim());
				upgradeCosts.BuildingCropCost = Int32.Parse(neededResourcesCollection[3].Groups[3].Value.Trim());
			}
			return upgradeCosts;
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="pageSource"></param>
		/// <returns></returns>
		public static VillageInfo GetProductionForVillage(string pageSource)
		{
			VillageInfo vi = new VillageInfo();

			//wood
			Regex wood = new Regex(@"id=l4 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (wood.IsMatch(pageSource))
			{
				Match Mc = wood.Matches(pageSource)[0];
				vi.WoodAvailable = Int32.Parse(Mc.Groups[2].Value.Trim());
				vi.WoodPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				vi.WarehouseSize = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			//clay
			Regex clay = new Regex(@"id=l3 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (clay.IsMatch(pageSource))
			{
				Match Mc = clay.Matches(pageSource)[0];
				vi.ClayAvailable = Int32.Parse(Mc.Groups[2].Value.Trim());
				vi.ClayPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				vi.WarehouseSize = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			//iron
			Regex iron = new Regex(@"id=l2 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (iron.IsMatch(pageSource))
			{
				Match Mc = iron.Matches(pageSource)[0];
				vi.IronAvailable = Int32.Parse(Mc.Groups[2].Value.Trim());
				vi.IronPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				vi.WarehouseSize = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			//crop
			Regex crop = new Regex(@"id=l1 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (crop.IsMatch(pageSource))
			{
				Match Mc = crop.Matches(pageSource)[0];
				vi.CropAvailable = Int32.Parse(Mc.Groups[2].Value.Trim());
				vi.CropPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				vi.GranarySize = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			return vi;
		}



		public static bool GetIsLogedIn
			(ServerInfo si,
			 PlayerInfo pi,
			 InternetExplorer ie,
			 HTMLDocument pageSource)
		{
			bool isLogedIn = false;
			if (pageSource != null)
			{
				if (pageSource.body != null)
				{
					isLogedIn = IsLogedIn(pageSource, pi);
					if (!isLogedIn)
					{
						Console.WriteLine("Not Loged In...");
						Console.WriteLine(pageSource.body.innerText);
						do
						{
							pageSource = Login(si, pi, ie);
							isLogedIn = IsLogedIn(pageSource, pi);
							Thread.Sleep(5000);
						} while (!isLogedIn);
					}
				}
				else
				{
					Console.WriteLine("ERROR: pageSource.body");
				}
			}
			else
			{
				Console.WriteLine("ERROR: pageSource");
			}
			return isLogedIn;
		}



		public static Int32 GetTroopCountForUnit(HTMLDocument pageSource, String troopType)
		{
			Int32 trpCount = 0;
			if (pageSource != null)
			{
				if (pageSource.body != null)
				{
					String[] MainPage = pageSource.body.innerText.Split('\n');
					foreach (String pageLine in MainPage)
					{
						if (pageLine.IndexOf(troopType) > -1)
						{
							String troopLine = pageLine.Trim();
							trpCount = Int32.Parse(troopLine.Substring(0, troopLine.Length - troopType.Length));
							//Console.WriteLine("We Have " + troopLine + " [" + trpCount + "]");
							break;
						}
					}
				}
			}
			return trpCount;
		}
	}
}