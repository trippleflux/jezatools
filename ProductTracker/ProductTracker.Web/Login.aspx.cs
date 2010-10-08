using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ProductTracker.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (FormsAuthentication.Authenticate(LoginControl.UserName, LoginControl.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(LoginControl.UserName, LoginControl.RememberMeSet);
            }
            else
            {
                Response.Write("Invalid credentials");
            }
        }
    }
}
