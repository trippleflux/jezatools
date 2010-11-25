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
                    linkButtonShops.Text = settingsManager.GetSettingValue("linkButtonShops", setting);
                    linkButtonItems.Text = settingsManager.GetSettingValue("linkButtonItems", setting);
                    hyperLinkDefaultManageItems.Text = settingsManager.GetSettingValue("hyperLinkDefaultManageItems", setting);
                    hyperLinkDefaultManageShops.Text = settingsManager.GetSettingValue("hyperLinkDefaultManageShops", setting);
                    hyperLinkDefaultManageShopItems.Text = settingsManager.GetSettingValue("hyperLinkDefaultManageShopItems", setting);
                }
            }
        }

        private void PopulateItems()
        {
            ShowItems();
            DataBase dataBase = new DataBase();
            DataSet items = dataBase.GetItems();
            gridViewDefaultBodyItems.DataSource = items;
            gridViewDefaultBodyItems.DataBind();
        }

        private void PopulateShops()
        {
            ShowShops();
            DataBase dataBase = new DataBase();
            DataSet shops = dataBase.GetShops();
            gridViewDefaultBodyShops.DataSource = shops;
            gridViewDefaultBodyShops.DataBind();
        }

        private void ShowItems()
        {
            gridViewDefaultBodyItems.Visible = true;
            gridViewDefaultBodyShops.Visible = false;
        }

        private void ShowShops()
        {
            gridViewDefaultBodyItems.Visible = false;
            gridViewDefaultBodyShops.Visible = true;
        }

        protected void LinkButtonShops_Click(object sender, EventArgs e)
        {
            PopulateShops();
        }

        protected void LinkButtonItems_Click(object sender, EventArgs e)
        {
            PopulateItems();
        }

        protected void GridViewItems_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gridViewDefaultBodyItems.PageIndex = e.NewPageIndex;
            PopulateItems();
        }

        protected void GridViewShops_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gridViewDefaultBodyShops.PageIndex = e.NewPageIndex;
            PopulateShops();
        }
    }
}