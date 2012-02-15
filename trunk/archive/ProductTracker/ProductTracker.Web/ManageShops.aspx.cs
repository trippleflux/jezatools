#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using log4net;

#endregion

namespace ProductTracker.Web
{
    public partial class ManageShops : System.Web.UI.Page
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ManageShops));

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
            Log.Debug("ClearFields");
            textBoxManageShopsInputBodyName.Text = "";
            textBoxManageShopsInputBodyOwner.Text = "";
            textBoxManageShopsInputBodyAddress.Text = "";
            textBoxManageShopsInputBodyCity.Text = "";
            textBoxManageShopsInputBodyPostalCode.Text = "";
            EnableAdd();
        }

        private void PopulateShops()
        {
            Log.Debug("PopulateShops");
            DataBase dataBase = new DataBase();
            DataSet shops = dataBase.GetShops();
            dropDownListManageShopsListBody.DataSource = shops;
            dropDownListManageShopsListBody.DataBind();
            ClearFields();
        }

        private void EnableAdd()
        {
            Log.Debug("EnableAdd");
            linkButtonManageShopsInputBodySubmit.Visible = true;
            linkButtonManageShopsInputBodyDelete.Visible = false;
            linkButtonManageShopsInputBodyUpdate.Visible = false;
        }

        private void EnableUpdate()
        {
            Log.Debug("EnableUpdate");
            linkButtonManageShopsInputBodySubmit.Visible = false;
            linkButtonManageShopsInputBodyDelete.Visible = true;
            linkButtonManageShopsInputBodyUpdate.Visible = true;
        }

        private void SetElementValues()
        {
            Log.Debug("SetElementValues");
            SettingsManager settingsManager = new SettingsManager();
            Settings settings = settingsManager.DeserializeFromXml();
            foreach (Page page in settings.Page)
            {
                if (page.Id == "ManageShops")
                {
                    List<Setting> setting = page.Setting;
                    hyperLinkMangeShopsHeadMain.Text = settingsManager.GetSettingValue("hyperLinkMangeShopsHeadMain", setting);
                    labelManageShopsInputBodyName.Text = settingsManager.GetSettingValue("labelManageShopsInputBodyName", setting);
                    labelManageShopsInputBodyAddress.Text = settingsManager.GetSettingValue("labelManageShopsInputBodyAddress", setting);
                    labelManageShopsInputBodyOwner.Text = settingsManager.GetSettingValue("labelManageShopsInputBodyOwner", setting);
                    labelManageShopsInputBodyPostalCode.Text = settingsManager.GetSettingValue("labelManageShopsInputBodyPostalCode", setting);
                    labelManageShopsInputBodyCity.Text = settingsManager.GetSettingValue("labelManageShopsInputBodyCity", setting);
                    labelManageShopsInputBodyIsCompany.Text = settingsManager.GetSettingValue("labelManageShopsInputBodyIsCompany", setting);
                    labelManageShopsListBody.Text = settingsManager.GetSettingValue("labelManageShopsListBody", setting);
                    linkButtonManageShopsListBodySelect.Text = settingsManager.GetSettingValue("linkButtonManageShopsListBodySelect", setting);
                    linkButtonManageShopsInputBodySubmit.Text = settingsManager.GetSettingValue("linkButtonManageShopsInputBodySubmit",
                                                                                     setting);
                    linkButtonManageShopsInputBodyDelete.Text = settingsManager.GetSettingValue("linkButtonManageShopsInputBodyDelete",
                                                                                     setting);
                    linkButtonManageShopsInputBodyUpdate.Text = settingsManager.GetSettingValue("linkButtonManageShopsInputBodyUpdate",
                                                                                     setting);
                    linkButtonManageShopsListBodyAdd.Text = settingsManager.GetSettingValue("linkButtonManageShopsListBodyAdd", setting);
                }
            }
        }

        protected void LinkButtonShopList_Click(object sender, EventArgs e)
        {
            Log.Debug("Select shop");
            string selectedValue = dropDownListManageShopsListBody.SelectedValue;
            DataBase dataBase = new DataBase();
            Shop shop = dataBase.GetShopByName(selectedValue);
            if (shop != null)
            {
                textBoxManageShopsInputBodyName.Text = shop.Name;
                textBoxManageShopsInputBodyOwner.Text = shop.Owner;
                textBoxManageShopsInputBodyAddress.Text = shop.Address;
                textBoxManageShopsInputBodyCity.Text = shop.City;
                textBoxManageShopsInputBodyPostalCode.Text = shop.PostalCode.ToString();
                HttpCookie cookie = Request.Cookies[CookieName];
                if (cookie == null)
                {
                    cookie = new HttpCookie(CookieName);
                }
                cookie["Name"] = shop.Id.ToString();
                cookie.Expires = DateTime.Now.AddMinutes(15);
                Response.Cookies.Add(cookie);
                Log.DebugFormat("Added new cookie='{0}'", cookie["Name"]);
                EnableUpdate();
            }
            else
            {
                PopulateShops();
            }
        }

        protected void LinkButtonBodyShopsSubmit_Click(object sender, EventArgs e)
        {
            Log.Debug("Submit shop");
            string name = textBoxManageShopsInputBodyName.Text.Trim();
            if(name.Length < 1)
            {
                Log.Warn("Name not set!");
                return;
            }
            Shop shop = new Shop
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Address = textBoxManageShopsInputBodyAddress.Text.Trim(),
                    City = textBoxManageShopsInputBodyCity.Text.Trim(),
                    Owner = textBoxManageShopsInputBodyOwner.Text.Trim(),
                    PostalCode = Misc.String2Number(textBoxManageShopsInputBodyPostalCode.Text.Trim()),
                    IsCompany = checkBoxManageShopsInputBodyIsCompany.Checked,
                };
            DataBase dataBase = new DataBase();
            dataBase.InsertShop(shop);
            PopulateShops();
            ClearFields();
        }

        protected void LinkButtonBodyShopsDelete_Click(object sender, EventArgs e)
        {
            Log.Debug("Delete shop");
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
            Log.Debug("Update shop");
            HttpCookie cookie = Request.Cookies[CookieName];
            if (cookie == null)
            {
                Log.Warn("Cookie with shop info has expired!");
                return;
            }
            DataBase dataBase = new DataBase();
            Shop shop = new Shop
                {
                    Name = textBoxManageShopsInputBodyName.Text.Trim(),
                    Address = textBoxManageShopsInputBodyAddress.Text.Trim(),
                    City = textBoxManageShopsInputBodyCity.Text.Trim(),
                    Owner = textBoxManageShopsInputBodyOwner.Text.Trim(),
                    PostalCode = Misc.String2Number(textBoxManageShopsInputBodyPostalCode.Text.Trim()),
                    IsCompany = checkBoxManageShopsInputBodyIsCompany.Checked,
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