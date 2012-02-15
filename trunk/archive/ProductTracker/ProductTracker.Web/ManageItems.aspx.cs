#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using log4net;

#endregion

namespace ProductTracker.Web
{
    public partial class ManageItems : System.Web.UI.Page
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ManageItems));

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
            Log.Debug("SetElementValues");
            SettingsManager settingsManager = new SettingsManager();
            Settings settings = settingsManager.DeserializeFromXml();
            foreach (Page page in settings.Page)
            {
                if (page.Id == "ManageItems")
                {
                    List<Setting> setting = page.Setting;
                    hyperLinkManageItemsHeadMain.Text = settingsManager.GetSettingValue("hyperLinkManageItemsHeadMain",
                                                                                        setting);
                    labelManageItemsBodyItemTypes.Text = settingsManager.GetSettingValue(
                        "labelManageItemsBodyItemTypes", setting);
                    linkButtonManageItemsBodyItemTypesSubmit.Text =
                        settingsManager.GetSettingValue("linkButtonManageItemsBodyItemTypesSubmit",
                                                        setting);
                    labelManageItemsBodyItemsSelect.Text =
                        settingsManager.GetSettingValue("labelManageItemsBodyItemsSelect", setting);
                    linkButtonManageItemsBodyItemsSelect.Text =
                        settingsManager.GetSettingValue("linkButtonManageItemsBodyItemsSelect", setting);
                    linkButtonManageItemsBodyItemsAddNew.Text =
                        settingsManager.GetSettingValue("linkButtonManageItemsBodyItemsAddNew", setting);
                    labelManageItemsBodyItemsSubmitItemName.Text =
                        settingsManager.GetSettingValue("labelManageItemsBodyItemsSubmitItemName", setting);
                    labelManageItemsBodyItemsSubmitItemNote.Text =
                        settingsManager.GetSettingValue("labelManageItemsBodyItemsSubmitItemNote", setting);
                    labelManageItemsBodyItemsSubmitItemType.Text =
                        settingsManager.GetSettingValue("labelManageItemsBodyItemsSubmitItemType", setting);
                    linkButtonManageItemsBodyItemsSubmit.Text =
                        settingsManager.GetSettingValue("linkButtonManageItemsBodyItemsSubmit",
                                                        setting);
                    linkButtonManageItemsBodyItemsUpdate.Text =
                        settingsManager.GetSettingValue("linkButtonManageItemsBodyItemsUpdate",
                                                        setting);
                    linkButtonManageItemsBodyItemsDelete.Text =
                        settingsManager.GetSettingValue("linkButtonManageItemsBodyItemsDelete", setting);
                }
            }
            EnableNew();
        }

        private void EnableNew()
        {
            Log.Debug("EnableNew");
            linkButtonManageItemsBodyItemsSubmit.Visible = true;
            linkButtonManageItemsBodyItemsUpdate.Visible = false;
            linkButtonManageItemsBodyItemsDelete.Visible = false;
            //dropDownListManageItemsBodyItemsSelect.Enabled = true;
        }

        private void EnableUpdate()
        {
            Log.Debug("EnableUpdate");
            linkButtonManageItemsBodyItemsSubmit.Visible = false;
            linkButtonManageItemsBodyItemsUpdate.Visible = true;
            linkButtonManageItemsBodyItemsDelete.Visible = true;
            //dropDownListManageItemsBodyItemsSelect.Enabled = false;
        }

        private void PopulateItems()
        {
            Log.Debug("PopulateItems");
            DataBase dataBase = new DataBase();
            DataSet items = dataBase.GetItems();
            dropDownListManageItemsBodyItemsSelect.DataSource = items;
            dropDownListManageItemsBodyItemsSelect.DataBind();
        }

        private void PopulateItemTypes()
        {
            Log.Debug("PopulateItemTypes");
            DataBase dataBase = new DataBase();
            IList<ItemType> itemTypes = dataBase.GetItemTypes();
            dropDownListManageItemsBodyItemsSubmitItemType.DataSource = itemTypes;
            dropDownListManageItemsBodyItemsSubmitItemType.DataBind();
        }

        protected void LinkButtonItemsSelect_Click(object sender, EventArgs e)
        {
            Log.Debug("Select");
            string selectedValue = dropDownListManageItemsBodyItemsSelect.SelectedValue;
            Log.DebugFormat("Selected value is '{0}'", selectedValue);
            DataBase dataBase = new DataBase();
            Item item = dataBase.GetItem(selectedValue);
            if (item == null)
            {
                Log.WarnFormat("Selected item '{0}' not found in DB", selectedValue);
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
            Log.InfoFormat("Adding new cookie '{0}'", cookie["Name"]);
            Response.Cookies.Add(cookie);
        }

        protected void LinkButtonMiddleBodySubmit_Click(object sender, EventArgs e)
        {
            Log.Debug("Submit");
            DataBase dataBase = new DataBase();
            string id = textBoxManageItemsBodyItemsSubmitItemId.Text.Trim();
            string name = textBoxManageItemsBodyItemsSubmitItemName.Text.Trim();
            if (id.Length < 1 || name.Length < 1)
            {
                Log.WarnFormat("Id or Name not set! Id='{0}', Name='{1}'", id, name);
                return;
            }
            string notes = textBoxManageItemsBodyItemsSubmitNote.Text.Trim();
            string itemType = dropDownListManageItemsBodyItemsSubmitItemType.SelectedValue;
            Item item = new Item(id, name) {Notes = notes, ItemType = Int32.Parse(itemType)};
            dataBase.InsertItem(item);
            PopulateItems();
        }

        protected void LinkButtonItemTypesSubmit_Click(object sender, EventArgs e)
        {
            Log.Debug("Submit ItemType");
            string itemTypeName = textBoxManageItemsBodyItemTypes.Text.Trim();
            if (itemTypeName.Length > 0)
            {
                DataBase dataBase = new DataBase();
                dataBase.InsertItemType(new ItemType {Name = itemTypeName});
            }
            Log.WarnFormat("ItemType not set! ItemType='{0}'", itemTypeName);
            PopulateItemTypes();
        }

        protected void LinkButtonMiddleItemTypesDelete_Click(object sender, EventArgs e)
        {
            Log.Debug("ItemTypes Delete");
            HttpCookie cookie = Request.Cookies[CookieItemuniqueid];
            if (cookie == null)
            {
                Log.Warn("Cookie was not found!");
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
            Log.Debug("Clear fields!");
            textBoxManageItemsBodyItemsSubmitItemId.Text = "";
            textBoxManageItemsBodyItemsSubmitItemName.Text = "";
            textBoxManageItemsBodyItemsSubmitNote.Text = "";
            EnableNew();
        }

        protected void LinkButtonMiddleBodyUpdate_Click(object sender, EventArgs e)
        {
            Log.Debug("Update");
            HttpCookie cookie = Request.Cookies[CookieItemuniqueid];
            if (cookie == null)
            {
                Log.Warn("Cookie was not found!");
                return;
            }
            DataBase dataBase = new DataBase();
            string id = textBoxManageItemsBodyItemsSubmitItemId.Text.Trim();
            string name = textBoxManageItemsBodyItemsSubmitItemName.Text.Trim();
            if (id.Length < 1 || name.Length < 1)
            {
                Log.WarnFormat("Id or Name not set! Id='{0}', Name='{1}'", id, name);
                return;
            }
            string notes = textBoxManageItemsBodyItemsSubmitNote.Text.Trim();
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