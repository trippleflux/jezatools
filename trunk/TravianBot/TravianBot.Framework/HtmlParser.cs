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
            for (int i = 0; i < unitsCollection.Count; i++)
            {
                string unitName = unitsCollection[i].Groups[2].Value.Trim();
                int unitCount = Int32.Parse(unitsCollection[i].Groups[1].Value.Trim());
                Unit unit = new Unit(unitCount, unitName);
                serverInfo.GetVillage(villageId).AddVillageUnit(unit);
            }
        }

        private readonly string pageSource;
    }
}