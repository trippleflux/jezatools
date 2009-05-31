#region

using System;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

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
            //<a href="?newdid=73913">01</a> 3.5
            //<a href=\"\?newdid=([0-9]{0,7})\"\s?(accesskey=\"\w\")?>([\w\W\d\D\s\S]{0,50})<\/a>
            MatchCollection villagesCollection =
                Regex.Matches(pageSource, @"<a href="".newdid=([0-9]{0,7})""\s?(accesskey=""\w"")?>([\w\W\d\D\s\S]{0,50})<.a>");
            int villageCount = villagesCollection.Count;
            //Console.WriteLine("villageCount=" + villageCount);
            for (int i = 0; i < villageCount; i++)
            {
                //Console.WriteLine(villagesCollection[i].Groups[0].Value);
                //Console.WriteLine(villagesCollection[i].Groups[1].Value);
                //Console.WriteLine(villagesCollection[i].Groups[3].Value);
                //102706" class="active_vl
                int villageId = Int32.Parse(Misc.GetOnlyNumbers(villagesCollection[i].Groups[1].Value));
                string villageName = villagesCollection[i].Groups[3].Value.Trim();
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

        public void ParseAttackRang
            (PlayerData playerData,
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
            const string patternRang =
                @"<td class=""(.*)"">([0-9]{0,6}).&nbsp;</td>[\s]{0,3}<td class=""(.*)""><a href=""spieler.php.uid=([0-9]{0,6})"">(.*)</a></td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>";
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

        public void ParseDefenseRang
            (PlayerData playerData,
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
            const string patternRang =
                @"<td class=""(.*)"">([0-9]{0,6}).&nbsp;</td>[\s]{0,3}<td class=""(.*)""><a href=""spieler.php.uid=([0-9]{0,6})"">(.*)</a></td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>[\s]{0,3}<td(\sclass=""(.*)"")?>([0-9]{0,6})</td>";
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

        public void ParseRang
            (PlayerData playerData,
             string username)
        {
            /*
<td class="li ou nbr" align="right">161.&nbsp;</td>
<td class="s7 ou"><a href="spieler.php?uid=9500">jeza</a></td>
<td class="ou"><a href="allianz.php?aid=1467">FOR</a></td>
             */
            const string patternRang =
                @"<td class=""(.*)"" align=""right"">([0-9]{0,6}).&nbsp;</td>[\s]{0,3}<td class=""(.*)""><a href=""spieler.php.uid=([0-9]{0,6})"">(.*)</a></td>[\s]{0,3}<td(\sclass=""(.*)"")?><a href=""allianz.php.aid=([0-9]{0,6})"">(.*)</a></td>";
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

        public void ParseUnitsInVillage
            (ServerInfo serverInfo,
             int villageId)
        {
            /*
<tr>
						<td><a href="build.php?gid=16"><img class="unit u15" src="img/x.gif" alt="Paladinov" title="Paladinov" /></a></td>
						<td class="u_count"><b>747</b></td>
						<td class="u_name">Paladinov</td>
					</tr>
             */
            const string patternUnits = @"<td class=""u_count""><b>(\d+)</b></td>(.|[\r\n])*?<td class=""u_name"">((\w*)(\s*)(\w*))</td>";
            //const string patternUnits = @"<b>(\d+)</b></td><td>((\w*)(\s*)(\w*))</td>";
            MatchCollection unitsCollection =
                Regex.Matches(pageSource, patternUnits);
            //Console.WriteLine("unitsCollection.Count=" + unitsCollection.Count);
            Village village = serverInfo.GetVillage(villageId);
            village.RemoveVillageUnits();
            for (int i = 0; i < unitsCollection.Count; i++)
            {
                //Console.WriteLine("0" + unitsCollection[i].Groups[0].Value.Trim());
                //Console.WriteLine("1" + unitsCollection[i].Groups[1].Value.Trim());
                //Console.WriteLine("2" + unitsCollection[i].Groups[2].Value.Trim());
                //Console.WriteLine("3" + unitsCollection[i].Groups[3].Value.Trim());
                //Console.WriteLine("4" + unitsCollection[i].Groups[4].Value.Trim());
                string unitName = unitsCollection[i].Groups[4].Value.Trim();
                int unitCount = Int32.Parse(unitsCollection[i].Groups[1].Value.Trim());
                Unit unit = new Unit(unitCount, unitName);
                village.AddVillageUnit(unit);
            }
        }

        private readonly string pageSource;

        public void ParseMarketplace(Marketplace marketplace)
        {
            //<tr><td colspan="2">Trgovci 4/20<br><br></td></tr>
            string patternMerchants = String.Format(CultureInfo.InvariantCulture, @"<tr><td colspan=""2"">{0} (\d+)/(\d+)<br><br></td></tr>", Misc.GetConfigValue("availableMerchantsString"));
            Regex merchants = new Regex(patternMerchants);
            if (merchants.IsMatch(pageSource))
            {
                Match Mc = merchants.Matches(pageSource)[0];
                marketplace.AvailableMerchants = Int32.Parse(Mc.Groups[1].Value.Trim());
                marketplace.TotalMerchants = Int32.Parse(Mc.Groups[2].Value.Trim());
            }
            //<p>Vsak tvoj trgovec lahko prepelje <b>2000</b>
            string patternCarryMerchants = String.Format(CultureInfo.InvariantCulture, @"<p>{0} <b>(\d+)</b>", Misc.GetConfigValue("carryString"));
            Regex carry = new Regex(patternCarryMerchants);
            if (carry.IsMatch(pageSource))
            {
                Match Mc = carry.Matches(pageSource)[0];
                marketplace.TotalCarry = Int32.Parse(Mc.Groups[1].Value.Trim());
            }
        }

        public void ParseVillageProduction(Village village)
        {
/*
<div id="res">
	<table>
		<tr>
							<td><img src="img/x.gif" class="r1" alt="Les" title="Les" /></td>
				<td id="l4" title="22">159274/400000</td>

							<td><img src="img/x.gif" class="r2" alt="Glina" title="Glina" /></td>
				<td id="l3" title="22">161168/400000</td>
							<td><img src="img/x.gif" class="r3" alt="Železo" title="Železo" /></td>
				<td id="l2" title="22">166435/400000</td>
							<td><img src="img/x.gif" class="r4" alt="Žito" title="Žito" /></td>
				<td id="l1" title="5955">53916/320000</td>
							</tr>

		<tr>
			<td colspan="6"></td>
					<td><img src="img/x.gif" class="r5" alt="Poraba žita" title="Poraba žita" /></td>
			<td>41070/47025</td>
		</tr>
	</table>
</div>
*/
            const string patternWood = @"<td id=""l4"" title=""(\d+)"">(\d+)/(\d+)</td>";
            Regex wood = new Regex(patternWood);
            if (wood.IsMatch(pageSource))
            {
                Match Mc = wood.Matches(pageSource)[0];
                village.WoodAvailable = Int32.Parse(Mc.Groups[2].Value.Trim());
                village.WoodProduction = Int32.Parse(Mc.Groups[1].Value.Trim());
                village.CapacityWarehouse = Int32.Parse(Mc.Groups[3].Value.Trim());
            }
            const string patternClay = @"<td id=""l3"" title=""(\d+)"">(\d+)/(\d+)</td>";
            Regex clay = new Regex(patternClay);
            if (clay.IsMatch(pageSource))
            {
                Match Mc = clay.Matches(pageSource)[0];
                village.ClayAvailable = Int32.Parse(Mc.Groups[2].Value.Trim());
                village.ClayProduction = Int32.Parse(Mc.Groups[1].Value.Trim());
                village.CapacityWarehouse = Int32.Parse(Mc.Groups[3].Value.Trim());
            }
            const string patternIron = @"<td id=""l2"" title=""(\d+)"">(\d+)/(\d+)</td>";
            Regex iron = new Regex(patternIron);
            if (iron.IsMatch(pageSource))
            {
                Match Mc = iron.Matches(pageSource)[0];
                village.IronAvailable = Int32.Parse(Mc.Groups[2].Value.Trim());
                village.IronProduction = Int32.Parse(Mc.Groups[1].Value.Trim());
                village.CapacityWarehouse = Int32.Parse(Mc.Groups[3].Value.Trim());
            }
            const string patternCrop = @"<td id=""l1"" title=""(\d+)"">(\d+)/(\d+)</td>";
            Regex crop = new Regex(patternCrop);
            if (crop.IsMatch(pageSource))
            {
                Match Mc = crop.Matches(pageSource)[0];
                village.CropAvailable = Int32.Parse(Mc.Groups[2].Value.Trim());
                village.CropProduction = Int32.Parse(Mc.Groups[1].Value.Trim());
                village.CapacityGranary = Int32.Parse(Mc.Groups[3].Value.Trim());
            }
        }

        public int ParseMarketPlaceHiddenData()
        {
            //<input type="hidden" name="sz" value="47406">
            const string pattern = @"<input type=""hidden"" name=""sz"" value=""(\d+)"">";
            Regex crop = new Regex(pattern);
            if (crop.IsMatch(pageSource))
            {
                Match Mc = crop.Matches(pageSource)[0];
                return Int32.Parse(Mc.Groups[1].Value.Trim());
            }
            return -1;
        }
    }
}