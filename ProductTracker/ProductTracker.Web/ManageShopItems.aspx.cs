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
            TextBoxPriceGross.Text = "";
            TextBoxPriceNet.Text = "";
            TextBoxNumberOfItems.Text = "";
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
                    HyperLinkMain.Text = settingsManager.GetSettingValue("HyperLinkMain", setting);
                    LabelItems.Text = settingsManager.GetSettingValue("LabelItems", setting);
                    LabelShops.Text = settingsManager.GetSettingValue("LabelShops", setting);
                    LabelPriceGross.Text = settingsManager.GetSettingValue("LabelPriceGross", setting);
                    LabelPriceNet.Text = settingsManager.GetSettingValue("LabelPriceNet", setting);
                    LabelNumberOfItems.Text = settingsManager.GetSettingValue("LabelNumberOfItems", setting);
                    LinkButtonAddItemToShop.Text = settingsManager.GetSettingValue("LinkButtonAddItemToShop", setting);
                }
            }
        }

        private void PopulateItems()
        {
            DataBase dataBase = new DataBase();
            DataSet items = dataBase.GetItems();
            DropDownListItems.DataSource = items;
            DropDownListItems.DataBind();
        }

        private void PopulateShops()
        {
            DataBase dataBase = new DataBase();
            DataSet shops = dataBase.GetShops();
            DropDownListShops.DataSource = shops;
            DropDownListShops.DataBind();
        }

        private void PopulateShopItems()
        {
            DataBase dataBase = new DataBase();
            DataSet shopItems = dataBase.GetShopItems();
            GridViewShopItems.DataSource = shopItems;
            GridViewShopItems.DataBind();
        }

        protected void LinkButtonAddItemToShopClick(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            string selectedItem = DropDownListItems.SelectedValue;
            Item item = dataBase.GetItem(new Guid(selectedItem));
            if (item == null)
            {
                return;
            }
            string selectedShop = DropDownListShops.SelectedValue;
            Shop shop = dataBase.GetShop(selectedShop);
            if (shop == null)
            {
                return;
            }
            Double priceGross = Double.Parse(TextBoxPriceGross.Text.Trim());
            Double priceNet = Double.Parse(TextBoxPriceNet.Text.Trim());
            int numberOfItems = Int32.Parse(TextBoxNumberOfItems.Text.Trim());
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
            ListItemCollection items = DropDownListItems.Items;
            ListItemCollection shops = DropDownListShops.Items;
            TableCell tableCellItemCount = GridViewShopItems.Rows[e.RowIndex].Cells[1];
            TableCell tableCellPriceGross = GridViewShopItems.Rows[e.RowIndex].Cells[2];
            TableCell tableCellPriceNet = GridViewShopItems.Rows[e.RowIndex].Cells[3];
            TableCell tableCellItem = GridViewShopItems.Rows[e.RowIndex].Cells[4];
            TableCell tableCellShop = GridViewShopItems.Rows[e.RowIndex].Cells[5];
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
                LabelStatus.Text = "Failed to delete row!";
            }
        }
    }
}