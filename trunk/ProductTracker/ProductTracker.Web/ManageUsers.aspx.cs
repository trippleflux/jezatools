#region

using System;
using System.Collections.Generic;

#endregion

namespace ProductTracker.Web
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetElementValues();
            LabelStatus.Text = "";
            if (!IsPostBack)
            {
                PopulateUsers();
            }
        }

        private void PopulateUsers()
        {
            DataBase dataBase = new DataBase();
            IList<User> users = dataBase.GetUsers();
            GridViewUsers.DataSource = users;
            GridViewUsers.DataBind();
        }

        private void SetElementValues()
        {
            SettingsManager settingsManager = new SettingsManager();
            Settings settings = settingsManager.DeserializeFromXml();
            foreach (Page page in settings.Page)
            {
                if (page.Id == "ManageUsers")
                {
                    List<Setting> setting = page.Setting;
                    HyperLinkMain.Text = settingsManager.GetSettingValue("HyperLinkMain", setting);
                    LabelUserName.Text = settingsManager.GetSettingValue("LabelUsername", setting);
                    LabelPassword.Text = settingsManager.GetSettingValue("LabelPassword", setting);
                    LabelLevel.Text = settingsManager.GetSettingValue("LabelLevel", setting);
                    LinkButtonAddUser.Text = settingsManager.GetSettingValue("LabelLevel", setting);
                    statusWrongUsername = settingsManager.GetSettingValue("StatusWrongUsername", setting);
                    statusWrongPassword = settingsManager.GetSettingValue("StatusWrongPassword", setting);
                    statusFailedToAddUser = settingsManager.GetSettingValue("StatusFailedToAddUser", setting);
                }
            }
        }

        protected void LinkButtonAddUser_Click(object sender, EventArgs e)
        {
            LabelStatus.Text = "";
            string username = TextBoxUserName.Text.Trim();
            if (username.Length < 3)
            {
                LabelStatus.Text = statusWrongUsername;
                return;
            }
            string password = TextBoxPassword.Text.Trim();
            if (password.Length < 3)
            {
                LabelStatus.Text = statusWrongPassword;
                return;
            }
            User user = new User {Name = username, Password = Misc.ConvertToSha1(password), Level = 2};
            DataBase dataBase = new DataBase();
            if (dataBase.InsertUser(user))
            {
                PopulateUsers();
                LabelStatus.Text = "";
            }
            else
            {
                LabelStatus.Text = statusFailedToAddUser;
            }
        }

        private string statusWrongUsername = "Username must be at least 3 chars long and can not contain spaces!";
        private string statusWrongPassword = "Password must be at least 3 chars long and can not contain spaces!";
        private string statusFailedToAddUser = "Failed to add user!";
    }
}