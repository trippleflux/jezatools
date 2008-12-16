using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TravianBot.Framework
{
    public class ReportReader : IReader
    {
        public ReportReader(ServerInfo serverInfo)
        {
            this.serverInfo = serverInfo;
        }

        public void Parse(string pageSource)
        {
            string newReport = Misc.GetConfigValue("reportNewString");
            string pattern = @"<a href=""berichte.php.id=([0-9]{0,9})"">(.*)</a> ." + newReport + ".</td>";
            reportCollection = Regex.Matches(pageSource, pattern);
        }

        public void Process()
        {
            for (int i = 0; i < reportCollection.Count; i++)
            {
                string reportId = reportCollection[i].Groups[1].Value.Trim();
                string reportText = reportCollection[i].Groups[2].Value.Trim();
                ReadAttackReport(reportText, reportId);
            }
        }

        private void ReadAttackReport(string reportText,
                                      string reportId)
        {
            string attackString = Misc.GetConfigValue("attackReportString");
            if (reportText.Contains(attackString))
            {
                string troopLostValue = " ";
                string attackVillage = "";
                string attackedVillage = "";
                Regex pattern = new Regex(@"(.*)(" + attackString + ")(.*)");
                if (pattern.IsMatch(reportText))
                {
                    Match Mc = pattern.Matches(reportText)[0];
                    attackVillage = Mc.Groups[1].Value;
                    attackedVillage = Mc.Groups[3].Value;
                }
                string url = String.Format(CultureInfo.InvariantCulture, "{0}?id={1}", serverInfo.ReportsUrl, reportId);
                string pageSource = Http.SendData(url, null, serverInfo.CookieContainer, serverInfo.CookieCollection);
                string troopLostString = Misc.GetConfigValue("reportTroopLostString");
                Regex troopLost =
                    new Regex(
                        @"<td>" + troopLostString + @"</td>(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)");
                if (troopLost.IsMatch(pageSource))
                {
                    Match Mc = troopLost.Matches(pageSource)[0];
                    for (int j = 0; j < Mc.Groups.Count; j++)
                    {
                        string match = Mc.Groups[j].Value;
                        if (Misc.IsNumber(match) && match.Length > 0)
                        {
                            troopLostValue += match + " ";
                        }
                    }
                }
                string loot = "";
                int lootTotal = 0;
                const string lootPattern = @"<img class=""res"" src=""img/un/r/[1234].gif"">([0-9]{0,7})";
                MatchCollection lootMatchCollection = Regex.Matches(pageSource, lootPattern);
                for (int j = 0; j < lootMatchCollection.Count; j++)
                {
                    int amount = Int32.Parse(lootMatchCollection[j].Groups[1].Value.Trim());
                    lootTotal += amount;
                    loot += amount + " ";
                }
                String fileContent = String.Format(CultureInfo.InvariantCulture, 
                    "{0} {1,20} <-> {2,-20}, Troop Lost [{3,-25}], Raid [{5} = {6}]{4}"
                    , url, attackVillage, attackedVillage, troopLostValue, Environment.NewLine, loot, lootTotal);
                Misc.WriteData("AttackReport.txt", fileContent, true);
                String consoleContent = String.Format(CultureInfo.InvariantCulture,
                    "{0} {1} <-> {2}, Troop Lost [{3}], Raid [{4} = {5}]"
                    , reportId, attackVillage, attackedVillage, troopLostValue, loot, lootTotal);
                Console.WriteLine(consoleContent);
            }
        }

        public MatchCollection ReportCollection
        {
            get { return reportCollection; }
            set { reportCollection = value; }
        }

        private readonly ServerInfo serverInfo;

        private MatchCollection reportCollection;
    }
}