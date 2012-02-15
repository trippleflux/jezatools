#region

using System;
using System.Collections.Generic;
using log4net;

#endregion

namespace ProductTracker.Web
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ManageUsers));

        protected void Page_Load(object sender, EventArgs e)
        {
            SetElementValues();
            labelManageUsersBodyInputStatus.Text = "";
            if (!IsPostBack)
            {
                PopulateUsers();
            }
        }

        private void PopulateUsers()
        {
            Log.Debug("PopulateUsers");
            DataBase dataBase = new DataBase();
            IList<User> users = dataBase.GetUsers();
            gridViewManageUsersBodyList.DataSource = users;
            gridViewManageUsersBodyList.DataBind();
        }

        private void SetElementValues()
        {
            Log.Debug("SetElementValues");
            SettingsManager settingsManager = new SettingsManager();
            Settings settings = settingsManager.DeserializeFromXml();
            foreach (Page page in settings.Page)
            {
                if (page.Id == "ManageUsers")
                {
                    List<Setting> setting = page.Setting;
                    hyperManageUsersHeadMain.Text = settingsManager.GetSettingValue("hyperManageUsersHeadMain", setting);
                    labelManageUsersBodyInputUserName.Text = settingsManager.GetSettingValue("labelManageUsersBodyInputUserName", setting);
                    labelManageUsersBodyInputPassword.Text = settingsManager.GetSettingValue("labelManageUsersBodyInputPassword", setting);
                    labelManageUsersBodyInputLevel.Text = settingsManager.GetSettingValue("labelManageUsersBodyInputLevel", setting);
                    linkButtonManageUsersBodyInputAddUser.Text = settingsManager.GetSettingValue("linkButtonManageUsersBodyInputAddUser", setting);
                    statusWrongUsername = settingsManager.GetSettingValue("statusWrongUsername", setting);
                    statusWrongPassword = settingsManager.GetSettingValue("statusWrongPassword", setting);
                    statusFailedToAddUser = settingsManager.GetSettingValue("statusFailedToAddUser", setting);
                }
            }
        }

        protected void LinkButtonAddUser_Click(object sender, EventArgs e)
        {
            Log.Debug("Add user");
            labelManageUsersBodyInputStatus.Text = "";
            string username = textBoxManageUsersBodyInputUserName.Text.Trim();
            if (username.Length < 3)
            {
                labelManageUsersBodyInputStatus.Text = statusWrongUsername;
                Log.Warn(statusWrongUsername);
                return;
            }
            string password = textBoxManageUsersBodyInputPassword.Text.Trim();
            if (password.Length < 3)
            {
                labelManageUsersBodyInputStatus.Text = statusWrongPassword;
                Log.Warn(statusWrongPassword);
                return;
            }
            User user = new User {Name = username, Password = Misc.ConvertToSha1(password), Level = 2};
            DataBase dataBase = new DataBase();
            if (dataBase.InsertUser(user))
            {
                PopulateUsers();
                labelManageUsersBodyInputStatus.Text = "";
            }
            else
            {
                labelManageUsersBodyInputStatus.Text = statusFailedToAddUser;
                Log.Warn(statusFailedToAddUser);
            }
        }

        private string statusWrongUsername = "Username must be at least 3 chars long and can not contain spaces!";
        private string statusWrongPassword = "Password must be at least 3 chars long and can not contain spaces!";
        private string statusFailedToAddUser = "Failed to add user!";
    }
}