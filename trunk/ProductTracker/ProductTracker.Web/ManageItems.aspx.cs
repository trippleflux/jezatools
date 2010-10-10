using System;
using System.Collections.Generic;

namespace ProductTracker.Web
{
    public partial class ManageItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateItems();
                PopulateItemTypes();
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
            TextBoxMiddleBodyUniqueId.Text = item.UniqueId.ToString();
            DropDownListMiddleBodyItemType.SelectedValue = item.ItemType.ToString();
        }

        protected void LinkButtonMiddleBodySubmit_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            string id = TextBoxMiddleBodyId.Text;
            string name = TextBoxMiddleBodyName.Text;
            string notes = TextBoxMiddleBodyNotes.Text;
            string itemType = DropDownListMiddleBodyItemType.SelectedValue;
            Item item = new Item(id, name) {Notes = notes, ItemType = Int32.Parse(itemType)};
            dataBase.InsertItem(item);
            PopulateItems();
        }

        protected void LinkButtonItemTypesSubmit_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            dataBase.InsertItemType(new ItemType(){Name = TextBoxItemTypes.Text.Trim()});
            PopulateItemTypes();
        }

        protected void LinkButtonMiddleItemTypesDelete_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            string id = TextBoxMiddleBodyUniqueId.Text;
            dataBase.DeleteItem(id);
            PopulateItems();
        }
    }
}
