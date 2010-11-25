#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

#endregion

namespace ProductTracker.Web
{
    public partial class ManageShopItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetElementValues();
            if (!IsPostBack)
            {
                Populate();
            }
        }

        private void Populate()
        {
            PopulateItems();
            PopulateShops();
            PopulateShopItems();
            ClearFields();
        }

        private void ClearFields()
        {
            textBoxManageShopItemsBodyInputPriceGross.Text = "";
            textBoxManageShopItemsBodyInputPriceNet.Text = "";
            textBoxManageShopItemsBodyInputNumberOfItems.Text = "";
        }

        private void SetElementValues()
        {
            SettingsManager settingsManager = new SettingsManager();
            Settings settings = settingsManager.DeserializeFromXml();
            foreach (Page page in settings.Page)
            {
                if (page.Id == "ManageShopItems")
                {
                    List<Setting> setting = page.Setting;
                    hyperLinkManageShopItemsMain.Text = settingsManager.GetSettingValue("hyperLinkManageShopItemsMain", setting);
                    labelManageShopItemsBodyInputItems.Text = settingsManager.GetSettingValue("labelManageShopItemsBodyInputItems", setting);
                    labelManageShopItemsBodyInputShops.Text = settingsManager.GetSettingValue("labelManageShopItemsBodyInputShops", setting);
                    labelManageShopItemsBodyInputPriceGross.Text = settingsManager.GetSettingValue("labelManageShopItemsBodyInputPriceGross", setting);
                    labelManageShopItemsBodyInputPriceNet.Text = settingsManager.GetSettingValue("labelManageShopItemsBodyInputPriceNet", setting);
                    labelManageShopItemsBodyInputNumberOfItems.Text = settingsManager.GetSettingValue("labelManageShopItemsBodyInputNumberOfItems", setting);
                    linkButtonManageShopItemsBodyInputAdd.Text = settingsManager.GetSettingValue("linkButtonManageShopItemsBodyInputAdd", setting);
                }
            }
        }

        private void PopulateItems()
        {
            DataBase dataBase = new DataBase();
            DataSet items = dataBase.GetItems();
            dropDownListManageShopItemsBodyInputItems.DataSource = items;
            dropDownListManageShopItemsBodyInputItems.DataBind();
        }

        private void PopulateShops()
        {
            DataBase dataBase = new DataBase();
            DataSet shops = dataBase.GetShops();
            dropDownListManageShopItemsBodyInputShops.DataSource = shops;
            dropDownListManageShopItemsBodyInputShops.DataBind();
        }

        private void PopulateShopItems()
        {
            DataBase dataBase = new DataBase();
            DataSet shopItems = dataBase.GetShopItems();
            gridViewManageShopItemsBodyList.DataSource = shopItems;
            gridViewManageShopItemsBodyList.DataBind();
        }

        protected void LinkButtonAddItemToShopClick(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            string selectedItem = dropDownListManageShopItemsBodyInputItems.SelectedValue;
            Item item = dataBase.GetItem(new Guid(selectedItem));
            if (item == null)
            {
                return;
            }
            string selectedShop = dropDownListManageShopItemsBodyInputShops.SelectedValue;
            Shop shop = dataBase.GetShop(selectedShop);
            if (shop == null)
            {
                return;
            }
            Double priceGross = Double.Parse(textBoxManageShopItemsBodyInputPriceGross.Text.Trim());
            Double priceNet = Double.Parse(textBoxManageShopItemsBodyInputPriceNet.Text.Trim());
            int numberOfItems = Int32.Parse(textBoxManageShopItemsBodyInputNumberOfItems.Text.Trim());
            Price price = new Price(priceGross, priceNet) {ItemId = item.UniqueId, ShopId = shop.Id};
            if (!dataBase.InsertPrice(price))
            {
                return;
            }
            ShopItem shopItem = new ShopItem
                {
                    ItemId = item.UniqueId,
                    ShopId = shop.Id,
                    PriceId = price.Id,
                    DateTime = new DateTime(DateTime.Now.Ticks),
                }.SetNumberOfItems(numberOfItems);
            dataBase.InsertShopItem(shopItem);
            Populate();
        }

        protected void GridViewShopItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ListItemCollection items = dropDownListManageShopItemsBodyInputItems.Items;
            ListItemCollection shops = dropDownListManageShopItemsBodyInputShops.Items;
            TableCell tableCellItemCount = gridViewManageShopItemsBodyList.Rows[e.RowIndex].Cells[1];
            TableCell tableCellPriceGross = gridViewManageShopItemsBodyList.Rows[e.RowIndex].Cells[2];
            TableCell tableCellPriceNet = gridViewManageShopItemsBodyList.Rows[e.RowIndex].Cells[3];
            TableCell tableCellItem = gridViewManageShopItemsBodyList.Rows[e.RowIndex].Cells[4];
            TableCell tableCellShop = gridViewManageShopItemsBodyList.Rows[e.RowIndex].Cells[5];
            Guid itemId = Guid.Empty;
            Guid shopId = Guid.Empty;
            foreach (var item in items)
            {
                string text = ((ListItem) (item)).Text;
                if (text.Equals(tableCellItem.Text.Trim()))
                {
                    itemId = new Guid(((ListItem) (item)).Value);
                    break;
                }
            }
            foreach (var shop in shops)
            {
                string text = ((ListItem) (shop)).Text;
                if (text.Equals(tableCellShop.Text.Trim()))
                {
                    shopId = new Guid(((ListItem) (shop)).Value);
                    break;
                }
            }
            Double priceGross = Double.Parse(tableCellPriceGross.Text.Trim());
            Double priceNet = Double.Parse(tableCellPriceNet.Text.Trim());
            int numberOfItems = Int32.Parse(tableCellItemCount.Text.Trim());
            DataBase dataBase = new DataBase();
            Guid priceId = dataBase.GetPriceId(itemId, shopId, priceGross, priceNet);
            dataBase.DeleteShopItem(itemId, shopId, priceId, numberOfItems);
            PopulateShopItems();
        }

        protected void GridViewShopItems_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                //OK
            }
            else
            {
                labelManageShopItemsStatus.Text = "Failed to delete row!";
            }
        }
    }
}