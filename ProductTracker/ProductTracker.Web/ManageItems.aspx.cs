using System;
using System.Collections.Generic;

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
                    HyperLinkMain.Text = settingsManager.GetSettingValue("HyperLinkMain", setting);
                    LabelItemTypes.Text = settingsManager.GetSettingValue("LabelItemTypes", setting);
                    LinkButtonItemTypesSubmit.Text = settingsManager.GetSettingValue("LinkButtonItemTypesSubmit", setting);
                    LabelItemsSelect.Text = settingsManager.GetSettingValue("LabelItemsSelect", setting);
                    LinkButtonItemsSelect.Text = settingsManager.GetSettingValue("LinkButtonItemsSelect", setting);
                    LinkButtonItemsAddNew.Text = settingsManager.GetSettingValue("LinkButtonItemsAddNew", setting);
                    LabelItemId.Text = settingsManager.GetSettingValue("LabelItemId", setting);
                    LabelItemName.Text = settingsManager.GetSettingValue("LabelItemName", setting);
                    LabelItemNote.Text = settingsManager.GetSettingValue("LabelItemNote", setting);
                    LabelItemItemType.Text = settingsManager.GetSettingValue("LabelItemItemType", setting);
                    LinkButtonMiddleBodySubmit.Text = settingsManager.GetSettingValue("LinkButtonMiddleBodySubmit", setting);
                    LinkButtonMiddleItemTypesDelete.Text = settingsManager.GetSettingValue("LinkButtonMiddleItemTypesDelete", setting);
                }
            }
        }

        private void PopulateItems()
        {
            DataBase dataBase = new DataBase();
            IList<Item> items = dataBase.GetItems();
            DropDownListItemsSelect.DataSource = items;
            DropDownListItemsSelect.DataBind();
        }

        private void PopulateItemTypes()
        {
            DataBase dataBase = new DataBase();
            IList<ItemType> itemTypes = dataBase.GetItemTypes();
            DropDownListMiddleBodyItemType.DataSource = itemTypes;
            DropDownListMiddleBodyItemType.DataBind();
        }

        protected void LinkButtonItemsSelect_Click(object sender, EventArgs e)
        {
            string selectedValue = DropDownListItemsSelect.SelectedValue;
            DataBase dataBase = new DataBase();
            Item item = dataBase.GetItem(new Guid(selectedValue));
            PopulateItemTypes();
            TextBoxMiddleBodyId.Text = item.Id;
            TextBoxMiddleBodyName.Text = item.Name;
            TextBoxMiddleBodyNotes.Text = item.Notes;
            DropDownListMiddleBodyItemType.SelectedValue = item.ItemType.ToString();
            TextBoxMiddleBodyUniqueId.Text = item.UniqueId.ToString();
        }

        protected void LinkButtonMiddleBodySubmit_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            string id = TextBoxMiddleBodyId.Text;
            string name = TextBoxMiddleBodyName.Text;
            string notes = TextBoxMiddleBodyNotes.Text;
            string itemType = DropDownListMiddleBodyItemType.SelectedValue;
            Item item = new Item(id, name) {Notes = notes, ItemType = Int32.Parse(itemType)};
            if (TextBoxMiddleBodyUniqueId.Text.Length > 8)
            {
                item.UniqueId = new Guid(TextBoxMiddleBodyUniqueId.Text.Trim());
                dataBase.UpdateItem(item);
            }
            else
            {
                dataBase.InsertItem(item);
            }
            PopulateItems();
        }

        protected void LinkButtonItemTypesSubmit_Click(object sender, EventArgs e)
        {
            string itemTypeName = TextBoxItemTypes.Text.Trim();
            if (itemTypeName.Length > 0)
            {
                DataBase dataBase = new DataBase();
                dataBase.InsertItemType(new ItemType() {Name = itemTypeName});
            }
            PopulateItemTypes();
        }

        protected void LinkButtonMiddleItemTypesDelete_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            string id = TextBoxMiddleBodyUniqueId.Text;
            dataBase.DeleteItem(id);
            PopulateItems();
        }

        protected void LinkButtonItemsAddNew_Click(object sender, EventArgs e)
        {
            TextBoxMiddleBodyId.Text = "";
            TextBoxMiddleBodyName.Text = "";
            TextBoxMiddleBodyNotes.Text = "";
            TextBoxMiddleBodyUniqueId.Text = "";
        }
    }
}
