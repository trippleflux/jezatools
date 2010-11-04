using System;
using System.Collections.Generic;

namespace ProductTracker.Web
{
    public partial class ManageShopItems : System.Web.UI.Page
    {
        protected void PageLoad(object sender, EventArgs e)
        {
            SetElementValues();
            if(!IsPostBack)
            {
                PopulateShopItems();
            }
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

        private void PopulateShopItems()
        {
            DataBase dataBase = new DataBase();
            List<ShopItem> shopItems = dataBase.GetShopItems();
            GridViewShopItems.DataSource = shopItems;
            GridViewShopItems.DataBind();
            IList<Shop> shops = dataBase.GetShops();
            DropDownListShops.DataSource = shops;
            DropDownListShops.DataBind();
            IList<Item> items = dataBase.GetItems();
            DropDownListItems.DataSource = items;
            DropDownListItems.DataBind();
        }

        protected void LinkButtonAddItemToShopClick(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            string selectedItem = DropDownListItems.SelectedValue;
            string selectedShop = DropDownListShops.SelectedValue;
            Double priceGross = Double.Parse(TextBoxPriceGross.Text.Trim());
            Double priceNet = Double.Parse(TextBoxPriceNet.Text.Trim());
            int numberOfItems = Int32.Parse(TextBoxNumberOfItems.Text.Trim());
            Price price = new Price(priceGross, priceNet);
            ShopItem shopItem = new ShopItem
                {
                    Price = price,
                    ItemId = new Guid(selectedItem),
                    ShopId = new Guid(selectedShop),
                    PriceId = price.Id,
                }.SetNumberOfItems(numberOfItems);
            dataBase.InsertShopItem(shopItem);
            PopulateShopItems();
        }
    }
}