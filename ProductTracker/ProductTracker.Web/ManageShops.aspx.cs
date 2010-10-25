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
            if (!IsPostBack)
            {
                PopulateShops();
            }
        }

        private void ClearFields()
        {
            TextBoxBodyShopsId.Text = "";
            TextBoxBodyShopsName.Text = "";
            TextBoxBodyShopsOwner.Text = "";
            TextBoxBodyShopsAddress.Text = "";
            TextBoxBodyShopsCity.Text = "";
            TextBoxBodyShopsPostalCode.Text = "";
        }

        private void PopulateShops()
        {
            DataBase dataBase = new DataBase();
            IList<Shop> shops = dataBase.GetShops();
            DropDownListShopList.DataSource = shops;
            DropDownListShopList.DataBind();
            ClearFields();
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
                    LinkButtonAdd.Text = settingsManager.GetSettingValue("LinkButtonAdd", setting);
                }
            }
        }

        protected void LinkButtonShopList_Click(object sender, EventArgs e)
        {
            string selectedValue = DropDownListShopList.SelectedValue;
            DataBase dataBase = new DataBase();
            Shop shop = dataBase.GetShop(selectedValue);
            if (shop != null)
            {
                TextBoxBodyShopsId.Text = shop.Id.ToString();
                TextBoxBodyShopsName.Text = shop.Name;
                TextBoxBodyShopsOwner.Text = shop.Owner;
                TextBoxBodyShopsAddress.Text = shop.Address;
                TextBoxBodyShopsCity.Text = shop.City;
                TextBoxBodyShopsPostalCode.Text = shop.PostalCode.ToString();
            }
            else
            {
                PopulateShops();
            }
        }

        protected void LinkButtonBodyShopsSubmit_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            Shop shop = new Shop
            {
                Id = Guid.NewGuid(),
                Name = TextBoxBodyShopsName.Text.Trim(),
                Address = TextBoxBodyShopsAddress.Text.Trim(),
                City = TextBoxBodyShopsCity.Text.Trim(),
                Owner = TextBoxBodyShopsOwner.Text.Trim(),
                PostalCode = Int32.Parse(TextBoxBodyShopsPostalCode.Text.Trim()),
                IsCompany = CheckBoxBodyShopsIsCompany.Checked,
            };
            if (TextBoxBodyShopsId.Text.Length > 8)
            {
                shop.Id = new Guid(TextBoxBodyShopsId.ToString());
                dataBase.UpdateShop(shop);
            }
            else
            {
                dataBase.InsertShop(shop);
            }
            PopulateShops();
        }

        protected void LinkButtonBodyShopsDelete_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            string id = TextBoxBodyShopsId.Text;
            dataBase.DeleteShop(id);
            PopulateShops();
        }

        protected void LinkButtonAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //private string statusShopNotFound = "Shop not found!";
    }
}