#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using log4net;

#endregion

namespace ProductTracker.Web
{
    public partial class ManageShopItems : System.Web.UI.Page
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ManageShopItems));

        protected void Page_Load(object sender, EventArgs e)
        {
            SetElementValues();
            Populate();
            //if (!IsPostBack)
            //{
            //}
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
            Log.Debug("ClearFields");
            textBoxManageShopItemsBodyInputPriceGross.Text = "";
            textBoxManageShopItemsBodyInputPriceNet.Text = "";
            textBoxManageShopItemsBodyInputNumberOfItems.Text = "";
        }

        private void SetElementValues()
        {
            Log.Debug("SetElementValues");
            SettingsManager settingsManager = new SettingsManager();
            Settings settings = settingsManager.DeserializeFromXml();
            foreach (Page page in settings.Page)
            {
                if (page.Id == "ManageShopItems")
                {
                    List<Setting> setting = page.Setting;
                    hyperLinkManageShopItemsMain.Text = settingsManager.GetSettingValue("hyperLinkManageShopItemsMain",
                                                                                        setting);
                    labelManageShopItemsBodyInputItems.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyInputItems", setting);
                    labelManageShopItemsBodyInputShops.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyInputShops", setting);
                    labelManageShopItemsBodyInputPriceGross.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyInputPriceGross", setting);
                    labelManageShopItemsBodyInputPriceNet.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyInputPriceNet", setting);
                    labelManageShopItemsBodyInputNumberOfItems.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyInputNumberOfItems", setting);
                    linkButtonManageShopItemsBodyInputAdd.Text =
                        settingsManager.GetSettingValue("linkButtonManageShopItemsBodyInputAdd", setting);
                }
            }
        }

        private void PopulateItems()
        {
            Log.Debug("PopulateItems");
            DataBase dataBase = new DataBase();
            DataSet items = dataBase.GetItems();
            dropDownListManageShopItemsBodyInputItems.DataSource = items;
            dropDownListManageShopItemsBodyInputItems.DataBind();
        }

        private void PopulateShops()
        {
            Log.Debug("PopulateShops");
            DataBase dataBase = new DataBase();
            DataSet shops = dataBase.GetShops();
            dropDownListManageShopItemsBodyInputShops.DataSource = shops;
            dropDownListManageShopItemsBodyInputShops.DataBind();
        }

        private void PopulateShopItems()
        {
            Log.Debug("PopulateShopItems");
            DataBase dataBase = new DataBase();
            DataSet dataSet = dataBase.GetShopItems();
            gridViewManageShopItemsBodyList.DataSource = dataSet;
            gridViewManageShopItemsBodyList.DataBind();
            DataRowCollection dataRowCollection = dataSet.Tables[Misc.DataTableNameOfShopItems].Rows;
            shopItems.Clear();
            shopItems.ParseShopItems(dataRowCollection);
        }

        protected void LinkButtonAddItemToShopClick(object sender, EventArgs e)
        {
            Log.Debug("Add Item To Shop");
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
            string gross = textBoxManageShopItemsBodyInputPriceGross.Text.Trim();
            string net = textBoxManageShopItemsBodyInputPriceNet.Text.Trim();
            if(gross.Length < 1 || net.Length < 1)
            {
                Log.WarnFormat("{irce not in correct format! Gross='{0}', Net='{1}'", gross, net);
                return;
            }
            Double priceGross = Double.Parse(gross);
            Double priceNet = Double.Parse(net);
            int numberOfItems = Misc.String2Number(textBoxManageShopItemsBodyInputNumberOfItems.Text.Trim());
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
            Log.Debug("Delete shop item");
            ListItemCollection items = dropDownListManageShopItemsBodyInputItems.Items;
            ListItemCollection shops = dropDownListManageShopItemsBodyInputShops.Items;
            TableCell tableCellDateTime = gridViewManageShopItemsBodyList.Rows[e.RowIndex].Cells[0];
            TableCell tableCellItemCount = gridViewManageShopItemsBodyList.Rows[e.RowIndex].Cells[1];
            //TableCell tableCellPriceGross = gridViewManageShopItemsBodyList.Rows[e.RowIndex].Cells[2];
            //TableCell tableCellPriceNet = gridViewManageShopItemsBodyList.Rows[e.RowIndex].Cells[3];
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
            if (itemId == Guid.Empty)
            {
                Log.Warn("Failed to get item id!");
                return;
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
            if (shopId == Guid.Empty)
            {
                Log.Warn("Failed to get shop id!");
                return;
            }
            //Double priceGross = Double.Parse(tableCellPriceGross.Text.Trim());
            //Double priceNet = Double.Parse(tableCellPriceNet.Text.Trim());
            int numberOfItems = Misc.String2Number(tableCellItemCount.Text.Trim());
            DateTime dateTime = DateTime.Parse(tableCellDateTime.Text.Trim());
            DataBase dataBase = new DataBase();
            //Guid priceId = dataBase.GetPriceId(itemId, shopId, priceGross, priceNet);
            Guid shopItemId = shopItems.GetShopItemId(dateTime, itemId, shopId, numberOfItems);
            dataBase.DeleteShopItem(shopItemId);
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

        private readonly List<ShopItem> shopItems = new List<ShopItem>();
    }
}