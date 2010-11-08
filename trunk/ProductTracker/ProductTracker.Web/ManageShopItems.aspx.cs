using System;
using System.Collections.Generic;
using System.Data;

namespace ProductTracker.Web
{
    public partial class ManageShopItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetElementValues();
            if(!IsPostBack)
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
            Item item = dataBase.GetItem(selectedItem);
            if (item == null)
            {
                return;
            }
            string selectedShop = DropDownListShops.SelectedValue;
            Shop shop = dataBase.GetShopByName(selectedShop);
            if (shop == null)
            {
                return;
            }
            Double priceGross = Double.Parse(TextBoxPriceGross.Text.Trim());
            Double priceNet = Double.Parse(TextBoxPriceNet.Text.Trim());
            int numberOfItems = Int32.Parse(TextBoxNumberOfItems.Text.Trim());
            Price price = new Price(priceGross, priceNet);
            ShopItem shopItem = new ShopItem
                {
                    Price = price,
                    ItemId = item.UniqueId,
                    ShopId = shop.Id,
                    PriceId = price.Id,
                }.SetNumberOfItems(numberOfItems);
            dataBase.InsertShopItem(shopItem);
            Populate();
        }
    }
}