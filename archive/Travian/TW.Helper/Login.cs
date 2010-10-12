#region

using log4net;
using WatiN.Core;

#endregion

namespace TW.Helper
{
    public class Login : DefaultPage
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Login));

        public Login(Browser browser)
            : base(browser)
        {
            this.browser = browser;
        }

        #region Page Elements

        private Table Table
        {
            get { return browser.Table("login_form"); }
        }

        //<input type="text" maxlength="15" value="james" name="ed4040d" class="text"/>
        private TextField UsernameField
        {
            get { return Table.TableRow(Find.ByClass("top")).TextField(Find.By("type", "text").And(Find.ByClass("text"))); }
        }

        //<input type="password" maxlength="20" value="******" name="e5fc08f" class="text"/>
        private TextField PasswordField
        {
            get { return Table.TableRow(Find.ByClass("btm")).TextField(Find.By("type", "password")); }
        }

        //<input type="image" alt="login button" src="img/x.gif" class="dynamic_img " id="btn_login" onclick="xy();" name="s1" value="login"/>
        private Image LoginButton
        {
            get { return browser.Image("btn_login"); }
        }

        #endregion

        public void LoginToGame()
        {
            Log.InfoFormat("Login to {0} as '{1}' with password '{2}'", Server, Username, Password);
            browser.GoTo(Server + "login.php");
            UsernameField.TypeText(Username);
            PasswordField.TypeText(Password);
            LoginButton.Click();
        }

        private readonly Browser browser;
    }
}