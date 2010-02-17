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
            Regex regHiddenLoginValue = new Regex("<input type=\"hidden\" name=\"login\" value=\"(.*)\" />");
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

            //Regex regHiddenName = new Regex("<input type=\"hidden\" name=\"(.*)\" value=\"(.*)\" />");
            //if (regHiddenName.IsMatch(pageSource))
            //{
            //    Match Mc = regHiddenName.Matches(pageSource)[0];
            //    HiddenName = Mc.Groups[1].Value;
            //    HiddenValue = Mc.Groups[2].Value;
            //}

            MatchCollection matchCollection =
                Regex.Matches(pageSource, @"<input type=""hidden"" name=""(.*)"" value=""(.*)"" />");
            int count = matchCollection.Count;
            for (int i = 0; i < count; i++)
            {
                string name = matchCollection[i].Groups[1].Value.Trim();
                if (name == "w")
                {
                    continue;
                }
                HiddenName = name;
                HiddenValue = matchCollection[i].Groups[2].Value.Trim();
            }
        }

        /*
         w=1680%3A1050&login=1242744256&ec852d4=jeza&e4b7736=*********&edcf8e3=9082b30900&edcf8e3=9082b30900&s1.x=83&s1.y=7&s1=login
         w=resolution&login=
         w=1680%3A1050&login=1266431960&name=jezonsky&password=******&s1.x=20&s1.y=4&s1=login
         */
        /*
        <input type="hidden" name="w" value="">
      	<input type="hidden" name="w" value="" />   -=> 3.5
        */
        public string HiddenWValue { get; set; }

        /*
        <input type="hidden" name="login" value="1226249860">
        <input type="hidden" name="login" value="1242745805" />   -=> 3.5
         */
        public string HiddenLoginValue { get; set; }

        /*
        <input type="hidden" name="ebb412a" value="e697604783">
        <input type="hidden" name="edcf8e3" value="9082b30900" />   -=> 3.5
         */
        public string HiddenName { get; set; }

        /*
        <input type="hidden" name="ebb412a" value="e697604783">
        <input type="hidden" name="edcf8e3" value="9082b30900" />   -=> 3.5
         */
        public string HiddenValue { get; set; }

        /*
        <input class="fm fm110" type="text" name="eb4b613" value="jeza1" maxlength="15">
        <input class="fm fm110" type="text" name="ec852d4" value="jeza" maxlength="15" />   -=> 3.5
         */
        public string TextBoxUserame { get; set; }

        /*
        <input class="fm fm110" type="password" name="eb77f54" value="*****" maxlength="20">
        <input class="fm fm110" type="password" name="e4b7736" value="*********" maxlength="20" />   -=> 3.5
         */
        public string TextBoxPassword { get; set; }
    }
}