#region

using System;
using System.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

namespace TW.Helper.Http
{
    public class Login : Page
    {
        public Login(string url)
        {
            Html html = new Html(url);
            pageSource = html.SendData(null, CookieContainer, CookieCollection);
            ParsePageFields();
        }

        public string PageSource
        {
            get { return pageSource; }
        }

        public string PostData
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture,
                                     "w=1680%3A1050&login={0}&{1}={2}&{3}={4}&{5}={6}&s1.x=66&s1.y=9&s1=login",
                                     hiddenFieldLogin, usernameFieldName, username, passwordFiledName, password,
                                     hiddenFieldButtonName, hiddenFieldButtonValue);
            }
        }

        private void ParsePageFields()
        {
            //<input type="hidden" name="e4bf548" value="832fb24b10" />
            MatchCollection hiddenFieldsButton = Regex.Matches(pageSource,
                                                               @"<input type=""hidden"" name=""(.*)"" value=""(.*)"" />");
            int count = hiddenFieldsButton.Count;
            for (int i = 0; i < count; i++)
            {
                string name = hiddenFieldsButton[i].Groups[1].Value.Trim();
                if (name == "w")
                {
                    continue;
                }
                hiddenFieldButtonName = name;
                hiddenFieldButtonValue = hiddenFieldsButton[i].Groups[2].Value.Trim();
            }
            //<input type="hidden" name="login" value="1261915108" />
            Regex regHiddenFieldLogin = new Regex("<input type=\"hidden\" name=\"login\" value=\"(.*)\" />");
            hiddenFieldLogin = GetMatch(regHiddenFieldLogin);
            //<input class="text" type="text" name="eeb9e98" value="bolek" maxlength="15" />
            Regex regUsernameFieldName = new Regex("<input class=\"text\" type=\"text\" name=\"(.*)\" value=");
            usernameFieldName = GetMatch(regUsernameFieldName);
            //<input class="text" type="password" name="e0db265" value="******" maxlength="20" />
            Regex regPasswordFiledName = new Regex("<input class=\"text\" type=\"password\" name=\"(.*)\" value=");
            passwordFiledName = GetMatch(regPasswordFiledName);
        }

        private string GetMatch(Regex regEx)
        {
            if (regEx.IsMatch(pageSource))
            {
                Match mc = regEx.Matches(pageSource)[0];
                return mc.Groups[1].Value;
            }
            return null;
        }

        private readonly string username = ConfigurationManager.AppSettings["username"];
        private readonly string password = ConfigurationManager.AppSettings["password"];
        private string hiddenFieldLogin;
        private string usernameFieldName;
        private string passwordFiledName;
        private string hiddenFieldButtonName;
        private string hiddenFieldButtonValue;
        private readonly string pageSource;
    }
}