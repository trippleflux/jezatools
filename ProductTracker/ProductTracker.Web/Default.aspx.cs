#region

using System;
using System.Collections.Generic;
using System.Data;

#endregion

namespace ProductTracker.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetElementValues();
            ShowItems();
            if (!IsPostBack)
            {
                PopulateItems();
            }
        }

        private void SetElementValues()
        {
            SettingsManager settingsManager = new SettingsManager();
            Settings settings = settingsManager.DeserializeFromXml();
            foreach (Page page in settings.Page)
            {
                if (page.Id == "DefaultPage")
                {
                    List<Setting> setting = page.Setting;
                    LinkButtonShops.Text = settingsManager.GetSettingValue("LinkButtonShops", setting);
                    LinkButtonItems.Text = settingsManager.GetSettingValue("LinkButtonItems", setting);
                    HyperLinkManageItems.Text = settingsManager.GetSettingValue("HyperLinkManageItems", setting);
                    HyperLinkManageShops.Text = settingsManager.GetSettingValue("HyperLinkManageShops", setting);
                    HyperLinkManageShopItems.Text = settingsManager.GetSettingValue("HyperLinkManageShopItems", setting);
                }
            }
        }

        private void PopulateItems()
        {
            ShowItems();
            DataBase dataBase = new DataBase();
            DataSet items = dataBase.GetItems();
            GridViewItems.DataSource = items;
            GridViewItems.DataBind();
        }

        private void PopulateShops()
        {
            ShowShops();
            DataBase dataBase = new DataBase();
            DataSet shops = dataBase.GetShops();
            GridViewShops.DataSource = shops;
            GridViewShops.DataBind();
        }

        private void ShowItems()
        {
            GridViewItems.Visible = true;
            GridViewShops.Visible = false;
        }

        private void ShowShops()
        {
            GridViewItems.Visible = false;
            GridViewShops.Visible = true;
        }

        protected void LinkButtonShops_Click(object sender, EventArgs e)
        {
            PopulateShops();
        }

        protected void LinkButtonItems_Click(object sender, EventArgs e)
        {
            PopulateItems();
        }
    }
}