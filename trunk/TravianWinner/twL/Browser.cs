#region

using System;
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


        public static HTMLDocument Login(ServerInfo si, PlayerInfo pi, InternetExplorer ie)
        {
			Console.WriteLine("Login...");
			GetPageSource(si.LoginPage, ie);
            string name = NameFromTagAndType(ie, "input", "text");
            string pass = NameFromTagAndType(ie, "input", "password");
            //Console.WriteLine(name);
            //Console.WriteLine(pass);
            if (name == String.Empty || pass == String.Empty)
            {
                return null;
            }
            HTMLDocument myDoc = (HTMLDocument)ie.Document;
            HTMLInputElement loginUsernameTextBox = (HTMLInputElement)myDoc.all.item(name, 0);
            loginUsernameTextBox.value = pi.Username;
            HTMLInputElement loginPasswordTextBox = (HTMLInputElement)myDoc.all.item(pass, 0);
            loginPasswordTextBox.value = pi.Password;
            String loginImageButtonName = NameFromTagAndType(ie, "input", "image");
            HTMLInputElement loginImageButton = (HTMLInputElement)myDoc.all.item(loginImageButtonName, 0);
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
        /// 
        /// </summary>
        /// <param name="ie"></param>
        /// <param name="tag"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// 
        private static string ValueFromTagTypeAndName
            (IWebBrowser2 ie,
             string tag,
             string type,
             string name)
        {
            String value = String.Empty;
            IHTMLDocument3 doc3 = (IHTMLDocument3) ie.Document;
            IHTMLElementCollection coll = doc3.getElementsByTagName(tag);
            foreach (IHTMLElement elm in coll)
            {
                if (elm.getAttribute("type", 0).ToString().ToLower() == type)
                {
                    if (elm.getAttribute("name", 0).ToString() == name)
                    {
                        value = elm.getAttribute("value", 0).ToString();
                        break;
                    }
                }
            }
            return value;
        }

        public static DateTime TryToBuild(InternetExplorer ie, BuildTask bt, ServerInfo si)
        {
            throw new NotImplementedException();
        }

        public static bool IsLogenIn(HTMLDocument source, PlayerInfo pi)
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

		public static DateTime NextCheck(String buildingUrl, IWebBrowser2 ie)
		{
			HTMLDocument source = GetPageSource(buildingUrl, ie);
			String pageSource = source.body.innerHTML.ToLower(CultureInfo.InvariantCulture);
			VillageInfo vi = GetProductionForVillage(pageSource);
			UpgradeCosts upgradeCosts = GetUpgradeCostsForBuilding(pageSource);
			int wood = ((vi.WoodAvailable - upgradeCosts.BuildingWoodCost) * 3600) / vi.WoodPerHour;
			int clay = ((vi.ClayAvailable - upgradeCosts.BuildingClayCost) * 3600) / vi.ClayPerHour;
			int iron = ((vi.IronAvailable - upgradeCosts.BuildingIronCost) * 3600) / vi.IronPerHour;
			int crop = ((vi.CropAvailable - upgradeCosts.BuildingCropCost) * 3600) / vi.CropPerHour;
			int[] list = { wood, clay, iron, crop };
			Misc.bubble_sort_generic(list);
			DateTime dt = new DateTime(DateTime.Now.Ticks);
			return dt.AddSeconds(Math.Abs(list[0]));
		}

		public static UpgradeCosts GetUpgradeCostsForBuilding(string pageSource)
		{
			//<img class="res" src="img/un/r/1.gif">6050
			UpgradeCosts upgradeCosts = new UpgradeCosts();
			const string reg = @"class=((res|""res"")) src=""img\/un\/r\/[1234].gif"">([0-9]{0,6})";
			MatchCollection neededResourcesCollection = Regex.Matches(pageSource, reg);
			if (neededResourcesCollection.Count > 0)
			{
				upgradeCosts.BuildingWoodCost = Int32.Parse(neededResourcesCollection[0].Groups[2].Value.Trim());
				upgradeCosts.BuildingClayCost = Int32.Parse(neededResourcesCollection[1].Groups[2].Value.Trim());
				upgradeCosts.BuildingIronCost = Int32.Parse(neededResourcesCollection[2].Groups[2].Value.Trim());
				upgradeCosts.BuildingCropCost = Int32.Parse(neededResourcesCollection[3].Groups[2].Value.Trim());
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
    }
}