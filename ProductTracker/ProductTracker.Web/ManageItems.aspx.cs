#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

#endregion

namespace ProductTracker.Web
{
    public partial class ManageItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetElementValues();
            if (!IsPostBack)
            {
                PopulateItems();
                PopulateItemTypes();
            }
        }

        private void SetElementValues()
        {
            SettingsManager settingsManager = new SettingsManager();
            Settings settings = settingsManager.DeserializeFromXml();
            foreach (Page page in settings.Page)
            {
                if (page.Id == "ManageItems")
                {
                    List<Setting> setting = page.Setting;
                    hyperLinkManageItemsHeadMain.Text = settingsManager.GetSettingValue("hyperLinkManageItemsHeadMain", setting);
                    labelManageItemsBodyItemTypes.Text = settingsManager.GetSettingValue("labelManageItemsBodyItemTypes", setting);
                    linkButtonManageItemsBodyItemTypesSubmit.Text = settingsManager.GetSettingValue("linkButtonManageItemsBodyItemTypesSubmit",
                                                                                     setting);
                    labelManageItemsBodyItemsSelect.Text = settingsManager.GetSettingValue("labelManageItemsBodyItemsSelect", setting);
                    linkButtonManageItemsBodyItemsSelect.Text = settingsManager.GetSettingValue("linkButtonManageItemsBodyItemsSelect", setting);
                    linkButtonManageItemsBodyItemsAddNew.Text = settingsManager.GetSettingValue("linkButtonManageItemsBodyItemsAddNew", setting);
                    labelManageItemsBodyItemsSubmitItemName.Text = settingsManager.GetSettingValue("labelManageItemsBodyItemsSubmitItemName", setting);
                    labelManageItemsBodyItemsSubmitItemNote.Text = settingsManager.GetSettingValue("labelManageItemsBodyItemsSubmitItemNote", setting);
                    labelManageItemsBodyItemsSubmitItemType.Text = settingsManager.GetSettingValue("labelManageItemsBodyItemsSubmitItemType", setting);
                    linkButtonManageItemsBodyItemsSubmit.Text = settingsManager.GetSettingValue("linkButtonManageItemsBodyItemsSubmit",
                                                                                      setting);
                    linkButtonManageItemsBodyItemsUpdate.Text = settingsManager.GetSettingValue("linkButtonManageItemsBodyItemsUpdate",
                                                                                      setting);
                    linkButtonManageItemsBodyItemsDelete.Text =
                        settingsManager.GetSettingValue("linkButtonManageItemsBodyItemsDelete", setting);
                }
            }
            EnableNew();
        }

        private void EnableNew()
        {
            linkButtonManageItemsBodyItemsSubmit.Visible = true;
            linkButtonManageItemsBodyItemsUpdate.Visible = false;
            linkButtonManageItemsBodyItemsDelete.Visible = false;
            //dropDownListManageItemsBodyItemsSelect.Enabled = true;
        }

        private void EnableUpdate()
        {
            linkButtonManageItemsBodyItemsSubmit.Visible = false;
            linkButtonManageItemsBodyItemsUpdate.Visible = true;
            linkButtonManageItemsBodyItemsDelete.Visible = true;
            //dropDownListManageItemsBodyItemsSelect.Enabled = false;
        }

        private void PopulateItems()
        {
            DataBase dataBase = new DataBase();
            DataSet items = dataBase.GetItems();
            dropDownListManageItemsBodyItemsSelect.DataSource = items;
            dropDownListManageItemsBodyItemsSelect.DataBind();
        }

        private void PopulateItemTypes()
        {
            DataBase dataBase = new DataBase();
            IList<ItemType> itemTypes = dataBase.GetItemTypes();
            dropDownListManageItemsBodyItemsSubmitItemType.DataSource = itemTypes;
            dropDownListManageItemsBodyItemsSubmitItemType.DataBind();
        }

        protected void LinkButtonItemsSelect_Click(object sender, EventArgs e)
        {
            string selectedValue = dropDownListManageItemsBodyItemsSelect.SelectedValue;
            DataBase dataBase = new DataBase();
            Item item = dataBase.GetItem(selectedValue);
            if (item == null)
            {
                return;
            }
            PopulateItemTypes();
            textBoxManageItemsBodyItemsSubmitItemId.Text = item.Id;
            textBoxManageItemsBodyItemsSubmitItemName.Text = item.Name;
            textBoxManageItemsBodyItemsSubmitNote.Text = item.Notes;
            dropDownListManageItemsBodyItemsSubmitItemType.SelectedValue = item.ItemType.ToString();
            EnableUpdate();
            HttpCookie cookie = Request.Cookies[CookieItemuniqueid];
            if (cookie == null)
            {
                cookie = new HttpCookie(CookieItemuniqueid);
            }
            cookie["Name"] = item.UniqueId.ToString();
            cookie.Expires = DateTime.Now.AddMinutes(15);
            Response.Cookies.Add(cookie);
        }

        protected void LinkButtonMiddleBodySubmit_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            string id = textBoxManageItemsBodyItemsSubmitItemId.Text;
            string name = textBoxManageItemsBodyItemsSubmitItemName.Text;
            string notes = textBoxManageItemsBodyItemsSubmitNote.Text;
            string itemType = dropDownListManageItemsBodyItemsSubmitItemType.SelectedValue;
            Item item = new Item(id, name) {Notes = notes, ItemType = Int32.Parse(itemType)};
            dataBase.InsertItem(item);
            PopulateItems();
        }

        protected void LinkButtonItemTypesSubmit_Click(object sender, EventArgs e)
        {
            string itemTypeName = textBoxManageItemsBodyItemTypes.Text.Trim();
            if (itemTypeName.Length > 0)
            {
                DataBase dataBase = new DataBase();
                dataBase.InsertItemType(new ItemType {Name = itemTypeName});
            }
            PopulateItemTypes();
        }

        protected void LinkButtonMiddleItemTypesDelete_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies[CookieItemuniqueid];
            if (cookie == null)
            {
                return;
            }
            string id = cookie["Name"];
            DataBase dataBase = new DataBase();
            dataBase.DeleteItem(id);
            PopulateItems();
        }

        protected void LinkButtonItemsAddNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            textBoxManageItemsBodyItemsSubmitItemId.Text = "";
            textBoxManageItemsBodyItemsSubmitItemName.Text = "";
            textBoxManageItemsBodyItemsSubmitNote.Text = "";
            EnableNew();
        }

        protected void LinkButtonMiddleBodyUpdate_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies[CookieItemuniqueid];
            if (cookie == null)
            {
                return;
            }
            DataBase dataBase = new DataBase();
            string id = textBoxManageItemsBodyItemsSubmitItemId.Text;
            string name = textBoxManageItemsBodyItemsSubmitItemName.Text;
            string notes = textBoxManageItemsBodyItemsSubmitNote.Text;
            string itemType = dropDownListManageItemsBodyItemsSubmitItemType.SelectedValue;
            Item item = new Item(id, name)
                {
                    Notes = notes, 
                    ItemType = Int32.Parse(itemType), 
                    UniqueId = new Guid(cookie["Name"]),
                };
            dataBase.UpdateItem(item);
            ClearFields();
            PopulateItems();

        }

        private const string CookieItemuniqueid = "ItemUniqueId";
    }
}