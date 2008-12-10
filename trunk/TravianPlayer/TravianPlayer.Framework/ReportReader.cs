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
                Console.WriteLine(i + "::" + matchCollection[i].Groups.Count);
                string reportId = matchCollection[i].Groups[1].Value.Trim();
                string reportText = matchCollection[i].Groups[2].Value.Trim();
                string troopLostValue = "0";
                url = String.Format(CultureInfo.InvariantCulture, "{0}?id={1}", gameInfo.GetUrl("messagesUrl"), reportId);
                pageSource = Http.SendData(url, null, gameInfo.CookieContainer, gameInfo.CookieCollection);
                Regex troopLost =
                    new Regex(
                        @"<td>Žrtve</td><td class=""c"">0</td><td class=""c"">0</td><td class=""c"">([0-9]{0,3})</td>");
                if (troopLost.IsMatch(pageSource))
                {
                    Match Mc = troopLost.Matches(pageSource)[0];
                    troopLostValue = Mc.Groups[1].Value;
                }
                String content = String.Format(CultureInfo.InvariantCulture, "{0} :: {1} [{2}]{3}", url, reportText,
                                               troopLostValue, Environment.NewLine);
                AttackExecutor.WriteData("Report.txt", content, true);
                Console.WriteLine(content);
            }
        }

        private readonly Game gameInfo;
    }
}