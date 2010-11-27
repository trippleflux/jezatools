#region

using System;
using System.Collections.Generic;
using System.Data;
using log4net;

#endregion

namespace ProductTracker.Web
{
    public partial class Default : System.Web.UI.Page
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Default));

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
            Log.Debug("SetElementValues");
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
                    gridViewDefaultBodyItems.Columns[0].HeaderText = settingsManager.GetSettingValue("tableDefaultBodyItemsId", setting);
                    gridViewDefaultBodyItems.Columns[1].HeaderText = settingsManager.GetSettingValue("tableDefaultBodyItemsName", setting);
                    gridViewDefaultBodyItems.Columns[2].HeaderText = settingsManager.GetSettingValue("tableDefaultBodyItemsType", setting);
                    gridViewDefaultBodyItems.Columns[3].HeaderText = settingsManager.GetSettingValue("tableDefaultBodyItemsNotes", setting);
                    gridViewDefaultBodyShops.Columns[0].HeaderText = settingsManager.GetSettingValue("tableDefaultBodyShopsName", setting);
                    gridViewDefaultBodyShops.Columns[1].HeaderText = settingsManager.GetSettingValue("tableDefaultBodyShopsAddress", setting);
                    gridViewDefaultBodyShops.Columns[2].HeaderText = settingsManager.GetSettingValue("tableDefaultBodyShopsOwner", setting);
                    gridViewDefaultBodyShops.Columns[3].HeaderText = settingsManager.GetSettingValue("tableDefaultBodyShopsPostalCode", setting);
                    gridViewDefaultBodyShops.Columns[4].HeaderText = settingsManager.GetSettingValue("tableDefaultBodyShopsCity", setting);
                    gridViewDefaultBodyShops.Columns[5].HeaderText = settingsManager.GetSettingValue("tableDefaultBodyShopsIsCompany", setting);
                }
            }
        }

        private void PopulateItems()
        {
            Log.Debug("PopulateItems");
            ShowItems();
            DataBase dataBase = new DataBase();
            DataSet items = dataBase.GetItems();
            gridViewDefaultBodyItems.DataSource = items;
            gridViewDefaultBodyItems.DataBind();
        }

        private void PopulateShops()
        {
            Log.Debug("PopulateShops");
            ShowShops();
            DataBase dataBase = new DataBase();
            DataSet shops = dataBase.GetShops();
            gridViewDefaultBodyShops.DataSource = shops;
            gridViewDefaultBodyShops.DataBind();
        }

        private void ShowItems()
        {
            Log.Debug("ShowItems");
            gridViewDefaultBodyItems.Visible = true;
            gridViewDefaultBodyShops.Visible = false;
        }

        private void ShowShops()
        {
            Log.Debug("ShowShops");
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