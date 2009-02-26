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

        public void ParseAlianceId(ServerInfo serverInfo)
        {
            //<a href="allianz.php?aid=2092">
            serverInfo.AlianceId = -1;
            Regex regAlianceID = new Regex(@"<a href=""allianz.php.aid=([0-9]{0,6})"">");
            if (regAlianceID.IsMatch(pageSource))
            {
                Match Mc = regAlianceID.Matches(pageSource)[0];
                serverInfo.AlianceId = Int32.Parse(Mc.Groups[1].Value.Trim());
            }
        }

        public void ParseAttackRang(PlayerData playerData, string username)
        {
            /*
            <tr>
            <td class="right nbr">21.&nbsp;</td>
            <td class="s7"><a href="spieler.php?uid=4133">bokson</a></td>
            <td>4051</td>
            <td>7</td>
            <td>17893</td>
            </tr> 
             */
            const string patternRang = @"<td class=""(.*)"">([0-9]{0,6}).&nbsp;</td>[\s]{0,3}<td class=""(.*)""><a href=""spieler.php.uid=([0-9]{0,6})"">(.*)</a></td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>";
            MatchCollection rangCollection =
                Regex.Matches(pageSource, patternRang);
            for (int i = 0; i < rangCollection.Count; i++)
            {
                string name = rangCollection[i].Groups[5].Value.Trim();
                if (name == username)
                {
                    playerData.Name = name;
                    playerData.AttackRang = Int32.Parse(rangCollection[i].Groups[2].Value.Trim());
                    playerData.Population = Int32.Parse(rangCollection[i].Groups[8].Value.Trim());
                    playerData.VillageCount = Int32.Parse(rangCollection[i].Groups[11].Value.Trim());
                    playerData.AttackPoints = Int32.Parse(rangCollection[i].Groups[14].Value.Trim());
                    break;
                }
            }
        }

        public void ParseDefenseRang(PlayerData playerData,
                                     string username)
        {
            /*
            <tr>
            <td class="right nbr">21.&nbsp;</td>
            <td class="s7"><a href="spieler.php?uid=4133">bokson</a></td>
            <td>4051</td>
            <td>7</td>
            <td>17893</td>
            </tr> 
             */
            const string patternRang = @"<td class=""(.*)"">([0-9]{0,6}).&nbsp;</td>[\s]{0,3}<td class=""(.*)""><a href=""spieler.php.uid=([0-9]{0,6})"">(.*)</a></td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>";
            MatchCollection rangCollection =
                Regex.Matches(pageSource, patternRang);
            for (int i = 0; i < rangCollection.Count; i++)
            {
                string name = rangCollection[i].Groups[5].Value.Trim();
                if (name == username)
                {
                    playerData.Name = name;
                    playerData.DefenseRang = Int32.Parse(rangCollection[i].Groups[2].Value.Trim());
                    playerData.Population = Int32.Parse(rangCollection[i].Groups[8].Value.Trim());
                    playerData.VillageCount = Int32.Parse(rangCollection[i].Groups[11].Value.Trim());
                    playerData.DefensePoints = Int32.Parse(rangCollection[i].Groups[14].Value.Trim());
                    break;
                }
            }
        }

        public void ParseRang(PlayerData playerData,
                                     string username)
        {
            /*
<td class="li ou nbr" align="right">161.&nbsp;</td>
<td class="s7 ou"><a href="spieler.php?uid=9500">jeza</a></td>
<td class="ou"><a href="allianz.php?aid=1467">FOR</a></td>
             */
            const string patternRang = @"<td class=""(.*)"" align=""right"">([0-9]{0,6}).&nbsp;</td>[\s]{0,3}<td class=""(.*)""><a href=""spieler.php.uid=([0-9]{0,6})"">(.*)</a></td>[\s]{0,3}<td(\sclass=""(.*)"")?><a href=""allianz.php.aid=([0-9]{0,6})"">(.*)</a></td>";
            MatchCollection rangCollection =
                Regex.Matches(pageSource, patternRang);
            for (int i = 0; i < rangCollection.Count; i++)
            {
                string name = rangCollection[i].Groups[5].Value.Trim();
                if (name == username)
                {
                    playerData.Name = name;
                    playerData.Rang = Int32.Parse(rangCollection[i].Groups[2].Value.Trim());
                    playerData.Aliance = rangCollection[i].Groups[9].Value.Trim();
                    break;
                }
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