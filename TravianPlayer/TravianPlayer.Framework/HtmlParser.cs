using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace TravianPlayer.Framework
{
    public class HtmlParser : IParser
    {
        public void Parse(string source)
        {
            throw new NotImplementedException();
        }

        public bool IsLogedIn
            (string pageSource,
             UserInfo userInfo)
        {
            userInfo.UserId = -1;
            Regex regPlayerID = new Regex(@"<a href=""spieler.php.uid=([0-9]{0,6})"">");
            if (regPlayerID.IsMatch(pageSource))
            {
                Match Mc = regPlayerID.Matches(pageSource)[0];
                userInfo.UserId = Int32.Parse(Mc.Groups[1].Value.Trim());
            }
            return userInfo.UserId > -1 ? true : false;
        }


        public void ParseLoginPage(string pageSource, UserInfo userInfo)
        {
            Regex regHiddenLoginValue = new Regex("<input type=\"hidden\" name=\"login\" value=\"(.*)\">");
            if (regHiddenLoginValue.IsMatch(pageSource))
            {
                Match Mc = regHiddenLoginValue.Matches(pageSource)[0];
                userInfo.HiddenLoginValue = Mc.Groups[1].Value;
            }

            Regex regLoginName = new Regex("<input class=\"fm fm110\" type=\"text\" name=\"(.*)\" value=");
            if (regLoginName.IsMatch(pageSource))
            {
                Match Mc = regLoginName.Matches(pageSource)[0];
                userInfo.TextBoxUserame = Mc.Groups[1].Value;
            }

            Regex regPasswordName = new Regex("<input class=\"fm fm110\" type=\"password\" name=\"(.*)\" value=");
            if (regPasswordName.IsMatch(pageSource))
            {
                Match Mc = regPasswordName.Matches(pageSource)[0];
                userInfo.TextBoxPassword = Mc.Groups[1].Value;
            }

            Regex regHiddenName = new Regex("<p align=\"center\"><input type=\"hidden\" name=\"(.*)\" value=\"(.*)\">");
            if (regHiddenName.IsMatch(pageSource))
            {
                Match Mc = regHiddenName.Matches(pageSource)[0];
                userInfo.HiddenName = Mc.Groups[1].Value;
                userInfo.HiddenValue = Mc.Groups[2].Value;
            }
        }

        public static string GetPageSource(WebResponse httpWebResponse)
        {
            StreamReader loginReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
            return loginReader.ReadToEnd();
        }
    }
}