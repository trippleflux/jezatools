#region

using System;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

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

        private void ReadAttackReport
            (string reportText,
             string reportId)
        {
            if (!GetAttackVillages(reportText))
            {
                return;
            }

            string url = String.Format(CultureInfo.InvariantCulture, "{0}?id={1}", serverInfo.ReportsUrl, reportId);
            string pageSource = Http.SendData(url, null, serverInfo.CookieContainer, serverInfo.CookieCollection);

            if (!GetTroopLost(pageSource))
            {
                return;
            }

            if (!GetLoot(pageSource))
            {
                return;
            }
            String fileContent = String.Format(CultureInfo.InvariantCulture,
                                               "{0} {1,20} <-> {2,-20}, Troop Lost [{3,-25}], Raid [ {5}= {6,8}]{4}"
                                               , url, attackVillage, attackedVillage, troopLostCollection,
                                               Environment.NewLine, loot, loot.Total);
            DateTime now = new DateTime(DateTime.Now.Ticks);
            string fileName = String.Format(CultureInfo.InvariantCulture, "{0}\\{1}AttackReport.txt",
                                            Misc.GetConfigValue("reportsDirectory"), now.ToString("yyyy-MM-dd"));
            Misc.WriteData(fileName, fileContent, true);
            String consoleContent = String.Format(CultureInfo.InvariantCulture,
                                                  "{0} {1} <-> {2}, Troop Lost [{3}], Raid [{4}= {5}]"
                                                  , reportId, attackVillage, attackedVillage, troopLostCollection, loot,
                                                  loot.Total);
            Console.WriteLine(consoleContent);
            //Misc.SaveData2SQL(loot);
        }

        private bool GetLoot(string pageSource)
        {
            const string lootPattern = @"<img class=""res"" src=""img/un/r/[1234].gif"">([0-9]{0,7})";
            MatchCollection lootMatchCollection = Regex.Matches(pageSource, lootPattern);
            if (lootMatchCollection.Count != 4)
            {
                return false;
            }
            loot = new Loot
                             {
                                 Wood = Int32.Parse(lootMatchCollection[0].Groups[1].Value.Trim()),
                                 Clay = Int32.Parse(lootMatchCollection[1].Groups[1].Value.Trim()),
                                 Iron = Int32.Parse(lootMatchCollection[2].Groups[1].Value.Trim()),
                                 Crop = Int32.Parse(lootMatchCollection[3].Groups[1].Value.Trim())
                             };
            loot.Total = loot.Sum();
            return true;
        }

        private bool GetTroopLost(string pageSource)
        {
            string troopLostString = Misc.GetConfigValue("reportTroopLostString");
            Regex troopLost =
                new Regex(
                    @"<td>" + troopLostString +
                    @"</td>(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)");
            if (troopLost.IsMatch(pageSource))
            {
                troopLostCollection = "";
                Match Mc = troopLost.Matches(pageSource)[0];
                for (int j = 0; j < Mc.Groups.Count; j++)
                {
                    string match = Mc.Groups[j].Value;
                    if (Misc.IsNumber(match) && match.Length > 0)
                    {
                        troopLostCollection += match + " ";
                    }
                }
                return true;
            }
            return false;
        }

        private bool GetAttackVillages(string reportText)
        {
            string attackString = Misc.GetConfigValue("attackReportString");
            if (reportText.Contains(attackString))
            {
                attackVillage = "";
                attackedVillage = "";
                Regex pattern = new Regex(@"(.*)(" + attackString + ")(.*)");
                if (pattern.IsMatch(reportText))
                {
                    Match Mc = pattern.Matches(reportText)[0];
                    attackVillage = Mc.Groups[1].Value;
                    attackedVillage = Mc.Groups[3].Value;
                    return true;
                }
            }
            return false;
        }

        public MatchCollection ReportCollection
        {
            get { return reportCollection; }
            set { reportCollection = value; }
        }

        private readonly ServerInfo serverInfo;

        private MatchCollection reportCollection;
        private string attackVillage;
        private string attackedVillage;
        private string troopLostCollection;
        private Loot loot;
    }
}