using System.Text.RegularExpressions;

namespace TravianPlayer.Framework
{
    public class HtmlParser : IPageParser
    {
        public Game Parse()
        {
            throw new System.NotImplementedException();
        }

        public HtmlParser(string pageSource)
        {
            this.pageSource = pageSource;
        }

        public Game ParseLoginData()
        {
            LoginInfo loginInfo = new LoginInfo();
            Game gameInfo = new Game(loginInfo);
            //Regex regHiddenLoginValue = new Regex("<input type=\"hidden\" name=\"login\" value=\"(.*)\">");
            //if (regHiddenLoginValue.IsMatch(pageSource))
            //{
            //    Match Mc = regHiddenLoginValue.Matches(pageSource)[0];
            //    userInfo.HiddenLoginValue = Mc.Groups[1].Value;
            //}

            //Regex regLoginName = new Regex("<input class=\"fm fm110\" type=\"text\" name=\"(.*)\" value=");
            //if (regLoginName.IsMatch(pageSource))
            //{
            //    Match Mc = regLoginName.Matches(pageSource)[0];
            //    userInfo.TextBoxUserame = Mc.Groups[1].Value;
            //}

            //Regex regPasswordName = new Regex("<input class=\"fm fm110\" type=\"password\" name=\"(.*)\" value=");
            //if (regPasswordName.IsMatch(pageSource))
            //{
            //    Match Mc = regPasswordName.Matches(pageSource)[0];
            //    userInfo.TextBoxPassword = Mc.Groups[1].Value;
            //}

            //Regex regHiddenName = new Regex("<p align=\"center\"><input type=\"hidden\" name=\"(.*)\" value=\"(.*)\">");
            //if (regHiddenName.IsMatch(pageSource))
            //{
            //    Match Mc = regHiddenName.Matches(pageSource)[0];
            //    userInfo.HiddenName = Mc.Groups[1].Value;
            //    userInfo.HiddenValue = Mc.Groups[2].Value;
            //}
            return gameInfo;
        }

        private string pageSource;
    }
}