#region

using System;
using System.Web.Security;
using System.Web.UI;

#endregion

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
        if ((textBoxUsername.Text.Equals("jeza") && textBoxPassword.Text.Equals("asdqweasd"))
            || (textBoxUsername.Text.Equals("bb") && textBoxPassword.Text.Equals("krtek13")))
        {
            FormsAuthentication.RedirectFromLoginPage(textBoxUsername.Text, true);
        }
        else
        {
            labelStatus.Text = "Fuck You!";
        }
    }
}