#region

using System;
using System.Web.Security;
using System.Web.UI.WebControls;

#endregion

namespace ProductTracker.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string typedPassword = Misc.ConvertToSha1(LoginControl.Password.Trim());
            if (CheckPassword(LoginControl.UserName, typedPassword))
            {
                FormsAuthentication.RedirectFromLoginPage(LoginControl.UserName, LoginControl.RememberMeSet);
            }
                //if (FormsAuthentication.Authenticate(LoginControl.UserName, LoginControl.Password))
                //{
                //    FormsAuthentication.RedirectFromLoginPage(LoginControl.UserName, LoginControl.RememberMeSet);
                //}
            else
            {
                Response.Write("Invalid credentials");
            }
        }

        private static bool CheckPassword(string username, string password)
        {
            DataBase dataBase = new DataBase();
            User user = dataBase.GetUser(username);
            if (user == null)
            {
                return false;
            }
            if (user.Name.Equals(username) && user.Password.Equals(password))
            {
                return true;
            }
            return false;
        }
    }
}