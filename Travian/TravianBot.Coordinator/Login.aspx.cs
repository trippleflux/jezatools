using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : Page
{
    protected void Page_Load
        (object sender,
         EventArgs e)
    {
        if (!IsPostBack)
        {
            labelStatus.Text = "";
        }
    }

    protected void LinkLogin_Click
        (object sender,
         EventArgs e)
    {
        if (textBoxUsername.Text.Equals ("jeza") && textBoxPassword.Text.Equals ("asdqweasd"))
        {
            FormsAuthentication.RedirectFromLoginPage(textBoxUsername.Text, true);
        }
        else
        {
            labelStatus.Text = "Fuck You!";
        }
    }
}