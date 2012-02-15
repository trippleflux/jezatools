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
        private static readonly ILog Log = LogManager.GetLogger(typeof (ManageShopItems));

        protected void Page_Load(object sender, EventArgs e)
        {
            SetElementValues();
            LoadShopItems();
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
                    labelManageShopItemsBodyTrackersInputShopItem.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyTrackersInputShopItem", setting);
                    labelManageShopItemsBodyTrackersInputDateTime.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyTrackersInputDateTime", setting);
                    labelManageShopItemsBodyTrackersInputSoldCount.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyTrackersInputSoldCount", setting);
                    labelManageShopItemsBodyTrackersStatsTotal.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyTrackersStatsTotal", setting);
                    labelManageShopItemsBodyTrackersStatsSold.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyTrackersStatsSold", setting);
                    labelManageShopItemsBodyTrackersStatsGrossReceived.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyTrackersStatsGrossReceived", setting);
                    labelManageShopItemsBodyTrackersStatsNetReceived.Text =
                        settingsManager.GetSettingValue("labelManageShopItemsBodyTrackersStatsNetReceived", setting);
                    linkButtonManageShopItemsBodyInputAdd.Text =
                        settingsManager.GetSettingValue("linkButtonManageShopItemsBodyInputAdd", setting);
                    linkButtonManageShopItemsBodyTrackersInputAdd.Text =
                        settingsManager.GetSettingValue("linkButtonManageShopItemsBodyTrackersInputAdd", setting);
                    gridViewManageShopItemsBodyList.Columns[0].HeaderText =
                        settingsManager.GetSettingValue("tableManageShopItemsBodyListDateTimeText", setting);
                    gridViewManageShopItemsBodyList.Columns[1].HeaderText =
                        settingsManager.GetSettingValue("tableManageShopItemsBodyListNumberOfItemsText", setting);
                    gridViewManageShopItemsBodyList.Columns[2].HeaderText =
                        settingsManager.GetSettingValue("tableManageShopItemsBodyListPriceGrossText", setting);
                    gridViewManageShopItemsBodyList.Columns[3].HeaderText =
                        settingsManager.GetSettingValue("tableManageShopItemsBodyListPriceNetText", setting);
                    gridViewManageShopItemsBodyList.Columns[4].HeaderText =
                        settingsManager.GetSettingValue("tableManageShopItemsBodyListItemText", setting);
                    gridViewManageShopItemsBodyList.Columns[5].HeaderText =
                        settingsManager.GetSettingValue("tableManageShopItemsBodyListShopText", setting);
                    gridViewManageShopItemsBodyTrackersList.Columns[0].HeaderText =
                        settingsManager.GetSettingValue("ManageShopItemsBodyTrackersListDateTime", setting);
                    gridViewManageShopItemsBodyTrackersList.Columns[1].HeaderText =
                        settingsManager.GetSettingValue("ManageShopItemsBodyTrackersListCount", setting);
                    CommandField commandFieldDelete = new CommandField
                        {
                            ShowDeleteButton = true,
                            DeleteText = settingsManager.GetSettingValue("tableManageShopItemsBodyListDeleteText", setting)
                        };
                    CommandField commandFieldSelect = new CommandField
                    {
                        ShowDeleteButton = false,
                        ShowSelectButton = true,
                        SelectText = settingsManager.GetSettingValue("tableManageShopItemsBodyListSelectText", setting)
                    };
                    if (gridViewManageShopItemsBodyList.Columns.Count < 7)
                    {
                        gridViewManageShopItemsBodyList.Columns.Add(commandFieldDelete);
                        gridViewManageShopItemsBodyList.Columns.Add(commandFieldSelect);
                    }
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
        }

        private void PopulateTrackers(DataSet dataSet)
        {
            Log.Debug("PopulateTrackers");
            gridViewManageShopItemsBodyTrackersList.Visible = true;
            gridViewManageShopItemsBodyTrackersList.DataSource = dataSet;
            gridViewManageShopItemsBodyTrackersList.DataBind();
        }

        private void LoadShopItems()
        {
            Log.Debug("LoadShopItems");
            DataBase dataBase = new DataBase();
            DataSet dataSet = dataBase.GetShopItems();
            DataRowCollection dataRowCollection = dataSet.Tables[Misc.DataTableNameOfShopItems].Rows;
            shopItems.Clear();
            shopItems.ParseShopItems(dataRowCollection);
            gridViewManageShopItemsBodyTrackersList.Visible = false;
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
            if (gross.Length < 1 || net.Length < 1)
            {
                Log.WarnFormat("Price not in correct format! Gross='{0}', Net='{1}'", gross, net);
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

        protected void gridViewManageShopItemsBodyList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Log.Debug("Select shop item");
            ListItemCollection items = dropDownListManageShopItemsBodyInputItems.Items;
            ListItemCollection shops = dropDownListManageShopItemsBodyInputShops.Items;
            TableCell tableCellDateTime = gridViewManageShopItemsBodyList.Rows[e.NewSelectedIndex].Cells[0];
            TableCell tableCellItemCount = gridViewManageShopItemsBodyList.Rows[e.NewSelectedIndex].Cells[1];
            TableCell tableCellItem = gridViewManageShopItemsBodyList.Rows[e.NewSelectedIndex].Cells[4];
            TableCell tableCellShop = gridViewManageShopItemsBodyList.Rows[e.NewSelectedIndex].Cells[5];
            Guid itemId = Guid.Empty;
            Guid shopId = Guid.Empty;
            foreach (var item in items)
            {
                string text = ((ListItem)(item)).Text;
                if (text.Equals(tableCellItem.Text.Trim()))
                {
                    itemId = new Guid(((ListItem)(item)).Value);
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
                string text = ((ListItem)(shop)).Text;
                if (text.Equals(tableCellShop.Text.Trim()))
                {
                    shopId = new Guid(((ListItem)(shop)).Value);
                    break;
                }
            }
            if (shopId == Guid.Empty)
            {
                Log.Warn("Failed to get shop id!");
                return;
            }
            int numberOfItems = Misc.String2Number(tableCellItemCount.Text.Trim());
            string dateTimeOfShopItem = tableCellDateTime.Text.Trim();
            DateTime dateTime = DateTime.Parse(dateTimeOfShopItem);
            Guid shopItemId = shopItems.GetShopItemId(dateTime, itemId, shopId, numberOfItems);
            textBoxManageShopItemsBodyTrackersInputShopItem.Text = shopItemId.ToString();
            textBoxManageShopItemsBodyTrackersInputDateTime.Text = dateTimeOfShopItem;
            textBoxManageShopItemsBodyTrackersInputSoldCount.Text = "0";
            DataBase dataBase = new DataBase();
            DataSet dataSet = dataBase.GetTrackers(shopItemId);
            PopulateTrackers(dataSet);
            int soldCount = 0;
            foreach (DataRow row in dataSet.Tables[Misc.DataTableNameOfTrackers].Rows)
            {
                soldCount+=Misc.String2Number(row.ItemArray.GetValue(1).ToString());
            }
            labelManageShopItemsBodyTrackersStatsTotalNumber.Text = numberOfItems.ToString();
            labelManageShopItemsBodyTrackersStatsSoldNumber.Text = soldCount.ToString();
            TableCell tableCellGross = gridViewManageShopItemsBodyList.Rows[e.NewSelectedIndex].Cells[2];
            TableCell tableCellNet = gridViewManageShopItemsBodyList.Rows[e.NewSelectedIndex].Cells[3];
            labelManageShopItemsBodyTrackersStatsGrossReceivedNumber.Text =
                (soldCount*Double.Parse(tableCellGross.Text.Trim())).ToString();
            labelManageShopItemsBodyTrackersStatsNetReceivedNumber.Text =
                (soldCount*Double.Parse(tableCellNet.Text.Trim())).ToString();
        }

        protected void LinkButtonManageShopItemsBodyTrackersInputAddClick(object sender, EventArgs e)
        {
            string shopItem = textBoxManageShopItemsBodyTrackersInputShopItem.Text;
            string soldCount = textBoxManageShopItemsBodyTrackersInputSoldCount.Text;
            if (String.IsNullOrEmpty(shopItem) ||
                String.IsNullOrEmpty(textBoxManageShopItemsBodyTrackersInputDateTime.Text) ||
                String.IsNullOrEmpty(soldCount))
            {
                labelManageShopItemsStatus.Text = "Select shop item first!";
                return;
            }
            Guid shopItemId = new Guid(shopItem);
            Tracker tracker = new Tracker() {ShopItemId = shopItemId, SoldCount = Misc.String2Number(soldCount)};
            DataBase dataBase = new DataBase();
            dataBase.InsertTracker(tracker);
            DataSet dataSet = dataBase.GetTrackers(shopItemId);
            PopulateTrackers(dataSet);
        }

        private readonly List<ShopItem> shopItems = new List<ShopItem>();
    }
}