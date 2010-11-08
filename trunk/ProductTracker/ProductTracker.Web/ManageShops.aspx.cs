#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

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
            TextBoxBodyShopsName.Text = "";
            TextBoxBodyShopsOwner.Text = "";
            TextBoxBodyShopsAddress.Text = "";
            TextBoxBodyShopsCity.Text = "";
            TextBoxBodyShopsPostalCode.Text = "";
            EnableAdd();
        }

        private void PopulateShops()
        {
            DataBase dataBase = new DataBase();
            DataSet shops = dataBase.GetShops();
            DropDownListShopList.DataSource = shops;
            DropDownListShopList.DataBind();
            ClearFields();
        }

        private void EnableAdd()
        {
            LinkButtonBodyShopsSubmit.Visible = true;
            LinkButtonBodyShopsDelete.Visible = false;
            LinkButtonBodyShopsUpdate.Visible = false;
        }

        private void EnableUpdate()
        {
            LinkButtonBodyShopsSubmit.Visible = false;
            LinkButtonBodyShopsDelete.Visible = true;
            LinkButtonBodyShopsUpdate.Visible = true;
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
                    LabelBodyShopsName.Text = settingsManager.GetSettingValue("LabelBodyShopsName", setting);
                    LabelBodyShopsAddress.Text = settingsManager.GetSettingValue("LabelBodyShopsAddress", setting);
                    LabelBodyShopsOwner.Text = settingsManager.GetSettingValue("LabelBodyShopsOwner", setting);
                    LabelBodyShopsPostalCode.Text = settingsManager.GetSettingValue("LabelBodyShopsPostalCode", setting);
                    LabelBodyShopsCity.Text = settingsManager.GetSettingValue("LabelBodyShopsCity", setting);
                    LabelBodyShopsIsCompany.Text = settingsManager.GetSettingValue("LabelBodyShopsIsCompany", setting);
                    LabelShopList.Text = settingsManager.GetSettingValue("LabelShopList", setting);
                    LinkButtonShopList.Text = settingsManager.GetSettingValue("LinkButtonShopList", setting);
                    LinkButtonBodyShopsSubmit.Text = settingsManager.GetSettingValue("LinkButtonBodyShopsSubmit",
                                                                                     setting);
                    LinkButtonBodyShopsDelete.Text = settingsManager.GetSettingValue("LinkButtonBodyShopsDelete",
                                                                                     setting);
                    LinkButtonBodyShopsUpdate.Text = settingsManager.GetSettingValue("LinkButtonBodyShopsUpdate",
                                                                                     setting);
                    LinkButtonAdd.Text = settingsManager.GetSettingValue("LinkButtonAdd", setting);
                }
            }
        }

        protected void LinkButtonShopList_Click(object sender, EventArgs e)
        {
            string selectedValue = DropDownListShopList.SelectedValue;
            DataBase dataBase = new DataBase();
            Shop shop = dataBase.GetShopByName(selectedValue);
            if (shop != null)
            {
                TextBoxBodyShopsName.Text = shop.Name;
                TextBoxBodyShopsOwner.Text = shop.Owner;
                TextBoxBodyShopsAddress.Text = shop.Address;
                TextBoxBodyShopsCity.Text = shop.City;
                TextBoxBodyShopsPostalCode.Text = shop.PostalCode.ToString();
                HttpCookie cookie = Request.Cookies[CookieName];
                if (cookie == null)
                {
                    cookie = new HttpCookie(CookieName);
                }
                cookie["Name"] = shop.Id.ToString();
                cookie.Expires = DateTime.Now.AddMinutes(15);
                Response.Cookies.Add(cookie);
                EnableUpdate();
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
            dataBase.InsertShop(shop);
            PopulateShops();
            ClearFields();
        }

        protected void LinkButtonBodyShopsDelete_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies[CookieName];
            if (cookie == null)
            {
                return;
            }
            DataBase dataBase = new DataBase();
            string id = cookie["Name"];
            dataBase.DeleteShop(id);
            PopulateShops();
        }

        protected void LinkButtonBodyShopsUpdate_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies[CookieName];
            if (cookie == null)
            {
                return;
            }
            DataBase dataBase = new DataBase();
            Shop shop = new Shop
                {
                    Name = TextBoxBodyShopsName.Text.Trim(),
                    Address = TextBoxBodyShopsAddress.Text.Trim(),
                    City = TextBoxBodyShopsCity.Text.Trim(),
                    Owner = TextBoxBodyShopsOwner.Text.Trim(),
                    PostalCode = Int32.Parse(TextBoxBodyShopsPostalCode.Text.Trim()),
                    IsCompany = CheckBoxBodyShopsIsCompany.Checked,
                    Id = new Guid(cookie["Name"]),
                };
            dataBase.UpdateShop(shop);
            PopulateShops();
            ClearFields();
        }

        protected void LinkButtonAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //private string statusShopNotFound = "Shop not found!";

        private const string CookieName = "CookieShopId";
    }
}