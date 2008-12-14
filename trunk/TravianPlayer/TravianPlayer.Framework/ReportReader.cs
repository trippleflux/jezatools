#region

using System;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

namespace TravianPlayer.Framework
{
    public class ReportReader : IReader
    {
        public ReportReader(Game gameInfo)
        {
            this.gameInfo = gameInfo;
        }

        public void Parse()
        {
            string url = String.Format(CultureInfo.InvariantCulture, "{0}", gameInfo.GetUrl("messagesUrl"));
            string pageSource = Http.SendData(url, null, gameInfo.CookieContainer, gameInfo.CookieCollection);

            //Console.WriteLine(pageSource);
            //<a href="berichte.php?id=5626213">01 je napadel paradajz</a> (novo)</td>
            const string pattern = @"<a href=""berichte.php.id=([0-9]{0,9})"">(.*)</a> .novo.</td>";
            MatchCollection matchCollection = Regex.Matches(pageSource, pattern);
            for (int i = 0; i < matchCollection.Count; i++)
            {
                //Console.WriteLine(i + "::" + matchCollection[i].Groups.Count);
                string reportId = matchCollection[i].Groups[1].Value.Trim();
                string reportText = matchCollection[i].Groups[2].Value.Trim();
                if (reportText.Contains("je napadel"))
                {
                    string troopLostValue = "-";
                    url = String.Format(CultureInfo.InvariantCulture, "{0}?id={1}", gameInfo.GetUrl("messagesUrl"),
                                        reportId);
                    //url = "http://s6.travian.si/berichte.php?id=6042298";
                    pageSource = Http.SendData(url, null, gameInfo.CookieContainer, gameInfo.CookieCollection);
                    Regex troopLost =
                        new Regex(
                            @"<td>Žrtve</td>(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)(<td(.class=""c"")*>([0-9]{0,7})</td>)");
                    if (troopLost.IsMatch(pageSource))
                    {
                        Match Mc = troopLost.Matches(pageSource)[0];
                        for (int j = 0; j < Mc.Groups.Count; j++)
                        {
                            string match = Mc.Groups[j].Value;
                            if (Misc.IsNumber(match))
                            {
                                troopLostValue += match + "-";
                            }
                        }
                    }
                    string loot = "-";
                    int lootTotal = 0;
                    const string lootPattern = @"<img class=""res"" src=""img/un/r/[1234].gif"">([0-9]{0,7})";
                    MatchCollection lootMatchCollection = Regex.Matches(pageSource, lootPattern);
                    for (int j = 0; j < lootMatchCollection.Count; j++)
                    {
                        int amount = Int32.Parse(lootMatchCollection[j].Groups[1].Value.Trim());
                        lootTotal += amount;
                        loot += amount + "-";
                    }
                    String content = String.Format(CultureInfo.InvariantCulture, "{0} :: {1} [{2}] :: [{4}={5}]{3}", url, reportText,
                                                   troopLostValue, Environment.NewLine, loot, lootTotal);
                    AttackExecutor.WriteData("Report.txt", content, true);
                    Console.WriteLine(content);
                }
            }
        }

        private readonly Game gameInfo;
    }
}