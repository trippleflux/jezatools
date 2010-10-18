#region

using System;
using System.Collections.Generic;

#endregion

namespace ProductTracker.Web
{
    public partial class ManageShops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetElementValues();
        }

        private void SetElementValues()
        {
            SettingsManager settingsManager = new SettingsManager();
            Settings settings = settingsManager.DeserializeFromXml();
            foreach (Page page in settings.Page)
            {
                if (page.Id == "ManageShops")
                {
                    List<Setting> setting = page.Setting;
                    HyperLinkMain.Text = settingsManager.GetSettingValue("HyperLinkMain", setting);
                    LabelBodyShopsId.Text = settingsManager.GetSettingValue("LabelBodyShopsId", setting);
                    LabelBodyShopsName.Text = settingsManager.GetSettingValue("LabelBodyShopsName", setting);
                    LabelBodyShopsAddress.Text = settingsManager.GetSettingValue("LabelBodyShopsAddress", setting);
                    LabelBodyShopsOwner.Text = settingsManager.GetSettingValue("LabelBodyShopsOwner", setting);
                    LabelBodyShopsPostalCode.Text = settingsManager.GetSettingValue("LabelBodyShopsPostalCode", setting);
                    LabelBodyShopsCity.Text = settingsManager.GetSettingValue("LabelBodyShopsCity", setting);
                    LabelBodyShopsIsCompany.Text = settingsManager.GetSettingValue("LabelBodyShopsIsCompany", setting);
                    LabelShopList.Text = settingsManager.GetSettingValue("LabelShopList", setting);
                    LinkButtonShopList.Text = settingsManager.GetSettingValue("LinkButtonShopList", setting);
                    LinkButtonBodyShopsSubmit.Text = settingsManager.GetSettingValue("LinkButtonBodyShopsSubmit", setting);
                    LinkButtonBodyShopsDelete.Text = settingsManager.GetSettingValue("LinkButtonBodyShopsDelete", setting);
                }
            }
        }

        protected void LinkButtonShopList_Click(object sender, EventArgs e)
        {

        }
    }
}