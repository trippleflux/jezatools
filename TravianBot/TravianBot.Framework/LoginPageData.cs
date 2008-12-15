using System.Text.RegularExpressions;

namespace TravianBot.Framework
{
    public class LoginPageData
    {
        public LoginPageData(ServerInfo serverInfo)
        {
            string pageSource = Http.SendData(serverInfo.LoginUrl, null, serverInfo.CookieContainer, serverInfo.CookieCollection);
            GetLoginPageData(pageSource);
        }

        public void GetLoginPageData(string pageSource)
        {
            Regex regHiddenLoginValue = new Regex("<input type=\"hidden\" name=\"login\" value=\"(.*)\">");
            if (regHiddenLoginValue.IsMatch(pageSource))
            {
                Match Mc = regHiddenLoginValue.Matches(pageSource)[0];
                HiddenLoginValue = Mc.Groups[1].Value;
            }

            Regex regLoginName = new Regex("<input class=\"fm fm110\" type=\"text\" name=\"(.*)\" value=");
            if (regLoginName.IsMatch(pageSource))
            {
                Match Mc = regLoginName.Matches(pageSource)[0];
                TextBoxUserame = Mc.Groups[1].Value;
            }

            Regex regPasswordName = new Regex("<input class=\"fm fm110\" type=\"password\" name=\"(.*)\" value=");
            if (regPasswordName.IsMatch(pageSource))
            {
                Match Mc = regPasswordName.Matches(pageSource)[0];
                TextBoxPassword = Mc.Groups[1].Value;
            }

            Regex regHiddenName = new Regex("<p align=\"center\"><input type=\"hidden\" name=\"(.*)\" value=\"(.*)\">");
            if (regHiddenName.IsMatch(pageSource))
            {
                Match Mc = regHiddenName.Matches(pageSource)[0];
                HiddenName = Mc.Groups[1].Value;
                HiddenValue = Mc.Groups[2].Value;
            }
        }

        /*
        <input type="hidden" name="w" value="">
        */
        public string HiddenWValue { get; set; }

        /*
        <input type="hidden" name="login" value="1226249860">
         */
        public string HiddenLoginValue { get; set; }

        /*
        <p align="center"><input type="hidden" name="ebb412a" value="e697604783">
         */
        public string HiddenName { get; set; }

        /*
        <p align="center"><input type="hidden" name="ebb412a" value="e697604783">
         */
        public string HiddenValue { get; set; }

        /*
        <input class="fm fm110" type="text" name="eb4b613" value="jeza1" maxlength="15"> <span class="e f7"></span>
         */
        public string TextBoxUserame { get; set; }

        /*
        <input class="fm fm110" type="password" name="eb77f54" value="*****" maxlength="20"> <span class="e f7"></span>
         */
        public string TextBoxPassword { get; set; }
    }
}