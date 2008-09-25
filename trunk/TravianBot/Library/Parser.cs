using System;
using System.Text.RegularExpressions;

namespace Library
{
    public class Parser
    {
        /// <summary>
        /// Parses values from login page.
        /// </summary>
        /// <param name="sd"><see cref="ServerData"/></param>
        /// <param name="pageSource">page source</param>
        /// 
        public void LoginData(ServerData sd, string pageSource)
        {
            Regex regHiddenLoginValue = new Regex("<input type=\"hidden\" name=\"login\" value=\"(.*)\">");
            if (regHiddenLoginValue.IsMatch(pageSource))
            {
                Match Mc = regHiddenLoginValue.Matches(pageSource)[0];
                sd.HiddenLoginValue = Mc.Groups[1].Value;
            }

            Regex regLoginName = new Regex("<input class=\"fm fm110\" type=\"text\" name=\"(.*)\" value=");
            if (regLoginName.IsMatch(pageSource))
            {
                Match Mc = regLoginName.Matches(pageSource)[0];
                sd.TextboxLoginName = Mc.Groups[1].Value;
            }

            Regex regPasswordName = new Regex("<input class=\"fm fm110\" type=\"password\" name=\"(.*)\" value=");
            if (regPasswordName.IsMatch(pageSource))
            {
                Match Mc = regPasswordName.Matches(pageSource)[0];
                sd.TextboxPasswordName = Mc.Groups[1].Value;
            }

            Regex regHiddenName = new Regex("<p align=\"center\"><input type=\"hidden\" name=\"(.*)\" value=\"(.*)\">");
            if (regHiddenName.IsMatch(pageSource))
            {
                Match Mc = regHiddenName.Matches(pageSource)[0];
                sd.HiddenName = Mc.Groups[1].Value;
                sd.HiddenValue = Mc.Groups[2].Value;
            }
        }

        /// <summary>
        /// Gets production of the village.
        /// </summary>
        /// <param name="sd"><see cref="ServerData"/></param>
        /// <param name="p"><see cref="Production"/></param>
        /// <param name="pageSource">Page source</param>
        /// 
        public void Production(ServerData sd, Production p, String pageSource)
        {
            /*
<table align="center" cellspacing="0" cellpadding="0"><tr valign="top">
<td><img class="res" src="img/un/r/1.gif" title="Les"></td>
<td id=l4 title=132>3766/7800</td>

<td class="s7"> <img class="res" src="img/un/r/2.gif" title="Glina"></td>
<td id=l3 title=127>3541/7800</td>
<td class="s7"> <img class="res" src="img/un/r/3.gif" title="�elezo"></td>
<td id=l2 title=121>4032/7800</td><td class="s7"> <img class="res" src="img/un/r/4.gif" title="�ito"></td>
<td id=l1 title=93>2095/2300</td>
<td class="s7"> &nbsp;<img class="res" src="img/un/r/5.gif" title="Poraba �ita">&nbsp;122/215</td></tr></table>
 */
                
            //wood
            Regex wood = new Regex(@"id=l4 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
            if (wood.IsMatch(pageSource))
            {
                Match Mc = wood.Matches(pageSource)[0];
                p.Wood = Int32.Parse(Mc.Groups[2].Value.Trim());
                p.WoodPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
            }
            //clay
            Regex clay = new Regex(@"id=l3 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
            if (clay.IsMatch(pageSource))
            {
                Match Mc = clay.Matches(pageSource)[0];
                p.Wood = Int32.Parse(Mc.Groups[2].Value.Trim());
                p.WoodPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
            }
            //iron
            Regex iron = new Regex(@"id=l2 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
            if (iron.IsMatch(pageSource))
            {
                Match Mc = iron.Matches(pageSource)[0];
                p.Wood = Int32.Parse(Mc.Groups[2].Value.Trim());
                p.WoodPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
            }
            //crop
            Regex crop = new Regex(@"id=l1 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
            if (crop.IsMatch(pageSource))
            {
                Match Mc = crop.Matches(pageSource)[0];
                p.Wood = Int32.Parse(Mc.Groups[2].Value.Trim());
                p.WoodPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
            }
            sd.ProductionList.Add(p);
        }

        /// <summary>
        /// Gets player UID
        /// </summary>
        /// <param name="sd"><see cref="ServerData"/></param>
        /// <param name="pageSource">Page source</param>
        /// 
        public void PlayerUid(ServerData sd, String pageSource)
        {
            sd.PlayerUID = -1;
            Regex regPlayerID = new Regex(@"<a href=""spieler.php.uid=([0-9]{0,6})"">");
            if (regPlayerID.IsMatch(pageSource))
            {
                Match Mc = regPlayerID.Matches(pageSource)[0];
                sd.PlayerUID = Int32.Parse(Mc.Groups[1].Value.Trim());
            }
        }

        /// <summary>
        /// Gets village IDs and names
        /// </summary>
        /// <param name="sd"><see cref="ServerData"/></param>
        /// <param name="v"><see cref="Village"/></param>
        /// <param name="pageSource">Page source</param>
        /// 
        public void VillageIDs(ServerData sd, Village v, String pageSource)
        {
            //<div class="dname"><h1>Muta01</h1></div> - one village!!! ?newdid=0
            MatchCollection myMatchCollection =
                Regex.Matches(pageSource, @"<a href="".newdid=(.*)\"">(.*)<.a>");
            int villageCount = myMatchCollection.Count;
            for (int i = 0; i < villageCount; i++)
            {
                //102706" class="active_vl
                string regEx = myMatchCollection[i].Groups[1].Value;
                v.VillageId = tbLibrary.GetOnlyNumbers(regEx);
                v.VillageName = myMatchCollection[i].Groups[2].Value.Trim();
                sd.VillagesList.Add(v);
            }
            if (villageCount < 2)
            {
                const string regVillageName = @"<div class=""dname""><h1>(.*)</h1></div>";
                myMatchCollection =
                    Regex.Matches(pageSource, regVillageName);
                v.VillageId = "0";
                v.VillageName = myMatchCollection[0].Groups[1].Value.Trim();
                sd.VillagesList.Add(v);
            }
        }

        /// <summary>
        /// Gets resource levels and list for village.
        /// </summary>
        /// <param name="sd"><see cref="ServerData"/></param>
        /// <param name="r"><see cref="Resource"/></param>
        /// <param name="pageSource">Page source</param>
        /// 
        public void Resources(ServerData sd, Resource r, String pageSource)
        {
            MatchCollection resourcesCollection =
                    Regex.Matches(pageSource, @"<area href=""build.php.id=([0-9]{1,3})"" coords=""([0-9]{1,3}.)*"" shape=""circle"" title=""((\w|\d|\s)*)"">");
            for (int i = 0; i < resourcesCollection.Count; i++)
            {
                string name = resourcesCollection[i].Groups[3].Value.Trim();
                string[] nameLevel = name.Split(' ');
                int nameLevelLength = nameLevel.Length;
                r.ResourceFullName = name;
                r.ResourceId = Int32.Parse(resourcesCollection[i].Groups[1].Value.Trim());
                r.ResourceLevel = Int32.Parse(nameLevel[nameLevelLength - 1]);
                for (int n = 0; n < nameLevelLength - 2; n++)
                {
                    r.ResourceName += nameLevel[n] + " ";
                }
                VillageData vd = new VillageData();
                vd.ResourcesForVillage.Add(r);
                sd.ResourcesList.Add(vd);
            }
        }

        /// <summary>
        /// Gets buildings levels and list for village.
        /// </summary>
        /// <param name="sd"><see cref="ServerData"/></param>
        /// <param name="b"><see cref="Building"/></param>
        /// <param name="pageSource">Page source</param>
        /// 
        public void Buildings(ServerData sd, Building b, String pageSource)
        {
            const string reg = @"<area href=""build.php.id=([0-9]{1,3})"" title=""((\w|\d|\s)*)"" coords=""([0-9]{1,3}.)*"" shape=""poly"">";
            MatchCollection buildingsCollection = Regex.Matches(pageSource, reg);
            for (int i = 0; i < buildingsCollection.Count; i++)
            {
                string name = buildingsCollection[i].Groups[3].Value.Trim();
                string[] nameLevel = name.Split(' ');
                int nameLevelLength = nameLevel.Length;
                b.BuildingFullName = name;
                b.BuildingId = Int32.Parse(buildingsCollection[i].Groups[1].Value.Trim());
                b.BuildingLevel = Int32.Parse(nameLevel[nameLevelLength - 1]);
                for (int n = 0; n < nameLevelLength - 2; n++)
                {
                    b.BuildingName += nameLevel[n] + " ";
                }
                VillageData vd = new VillageData();
                vd.BuildingsForVillage.Add(b);
                sd.BuildingsList.Add(vd);
            }
        }
    }
}