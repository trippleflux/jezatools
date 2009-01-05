using System;
using System.Text.RegularExpressions;

namespace TravianBot.Framework
{
    public class HtmlParser
    {
        public HtmlParser(string pageSource)
        {
            this.pageSource = pageSource;
        }

        public void ParseVillages(ServerInfo serverInfo)
        {
            //<a href="?newdid=83117">01</a>
            MatchCollection villagesCollection =
                Regex.Matches(pageSource, @"<a href="".newdid=(.*)\"">(.*)<.a>");
            int villageCount = villagesCollection.Count;
            for (int i = 0; i < villageCount; i++)
            {
                //102706" class="active_vl
                int villageId = Int32.Parse(Misc.GetOnlyNumbers(villagesCollection[i].Groups[1].Value));
                string villageName = villagesCollection[i].Groups[2].Value.Trim();
                Village village = new Village(villageId, villageName);
                serverInfo.Villages.Add(village);
            }
            if (villageCount < 2)
            {
                const string regVillageName = @"<div class=""dname""><h1>(.*)</h1></div>";
                villagesCollection =
                    Regex.Matches(pageSource, regVillageName);
                Village village = new Village(0, villagesCollection[0].Groups[1].Value.Trim());
                serverInfo.Villages.Add(village);
            }
        }

        public void ParseUserId(ServerInfo serverInfo)
        {
            //<a href="spieler.php?uid=9500">Profil</a>
            serverInfo.UserId = -1;
            Regex regPlayerID = new Regex(@"<a href=""spieler.php.uid=([0-9]{0,6})"">");
            if (regPlayerID.IsMatch(pageSource))
            {
                Match Mc = regPlayerID.Matches(pageSource)[0];
                serverInfo.UserId = Int32.Parse(Mc.Groups[1].Value.Trim());
            }
        }

        public void ParseUnitsInVillage(ServerInfo serverInfo,
                                        int villageId)
        {
            const string patternUnits = @"<b>(\d+)</b></td><td>((\w*)(\s*)(\w*))</td>";
            MatchCollection unitsCollection =
                Regex.Matches(pageSource, patternUnits);
            Village village = serverInfo.GetVillage(villageId);
            village.RemoveVillageUnits();
            for (int i = 0; i < unitsCollection.Count; i++)
            {
                string unitName = unitsCollection[i].Groups[2].Value.Trim();
                int unitCount = Int32.Parse(unitsCollection[i].Groups[1].Value.Trim());
                Unit unit = new Unit(unitCount, unitName);
                village.AddVillageUnit(unit);
            }
        }

        private readonly string pageSource;
    }
}