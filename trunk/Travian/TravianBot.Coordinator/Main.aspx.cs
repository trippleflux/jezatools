using System;
using System.Web.Security;
using System.Web.UI;

public partial class Main : Page
{
    protected void Page_Load
        (object sender,
         EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void LinkButtonLogout_Click
        (object sender,
         EventArgs e)
    {
        FormsAuthentication.SignOut ();
        FormsAuthentication.RedirectToLoginPage ();
    }

    protected void LinkButtonFarms_Click
        (object sender,
         EventArgs e)
    {
    }

    protected void LinkButtonGetFarms_Click
        (object sender,
         EventArgs e)
    {
    }
}