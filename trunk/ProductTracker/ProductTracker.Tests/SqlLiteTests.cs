#region

using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace ProductTracker.Tests
{
    [TestFixture]
    public class SqlLiteTests
    {
        /// <summary>
        /// Gets the user admin.
        /// </summary>
        [Test]
        public void GetUserAdmin()
        {
            IList<User> users = dataBase.GetUsers();
            Assert.IsNotNull(users, "dataBase.GetUsers() is NULL!");
            Assert.AreEqual("admin", users[0].Name, "Username 'admin' was expected!");
        }

        /// <summary>
        /// Gets the available shops.
        /// </summary>
        [Test]
        public void GetAvailableShops()
        {
            IList<Shop> shops = dataBase.GetShops();
            Assert.IsNotNull(shops, "dataBase.GetShops() is NULL!");
            Assert.AreEqual(shop.Id, shops[0].Id, "{0} was not found!", shop.Name);
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        [Test]
        public void GetItem()
        {
            Item actualItem = dataBase.GetItem(item.UniqueId);
            Assert.IsNotNull(actualItem, "dataBase.GetItem() is NULL!");
            Assert.AreEqual(item.UniqueId, actualItem.UniqueId, "Item missmatch!");
        }

        /// <summary>
        /// Gets the available items.
        /// </summary>
        [Test]
        public void GetAvailableItems()
        {
            IList<Item> items = dataBase.GetItems();
            Assert.IsNotNull(items, "dataBase.GetItems() is NULL!");
            Assert.AreEqual(item.Id, items[0].Id, "{0} was not found!", item.Name);
            Assert.AreEqual(item.UniqueId, items[0].UniqueId, "{0} was not found!", item.Name);
        }

        /// <summary>
        /// Gets the price for specified item in shop.
        /// </summary>
        [Test]
        public void GetPrice()
        {
            Price priceActual = dataBase.GetPrice(item, shop);
            Assert.AreEqual(price.Gross, priceActual.Gross, "Gross missmatch!");
            Assert.AreEqual(price.Net, priceActual.Net, "Net missmatch!");
        }

        [Test]
        public void GetShopItem()
        {
            ShopItem actualShopItem = dataBase.GetShopItem(item, shop);
            Assert.AreEqual(item.UniqueId, actualShopItem.ItemId, "ItemId missmatch!");
            Assert.AreEqual(shop.Id, actualShopItem.ShopId, "ShopId missmatch!");
            Assert.AreEqual(price.Id, actualShopItem.PriceId, "PriceId missmatch!");
            Assert.AreEqual(5, actualShopItem.NumberOfItems, "NumberOfItems missmatch!");
        }

        [Test]
        public void GetTracker()
        {
            IList<Tracker> actualTrackers = dataBase.GetTrackers(shopItem);
            Assert.AreEqual(shopItem.Id, actualTrackers[0].ShopItemId, "ShopItemId missmatch!");
            Assert.AreEqual(2, actualTrackers[0].SoldCount, "SoldCount missmatch!");
        }

        [SetUp]
        public void Setup()
        {
            dataBase.DeleteAllItems();
            dataBase.DeleteAllItemTypes();
            dataBase.DeleteAllShops();
            const string itemTypeName = "cestitka";
            itemType = new ItemType() {Name = itemTypeName};
            Assert.IsTrue(dataBase.InsertItemType(itemType));
            IList<ItemType> itemTypes = dataBase.GetItemTypes();
            const string shopName = "trgovina 1";
            shop = new Shop(shopName);
            Assert.IsTrue(dataBase.InsertShop(shop));
            item = new Item("ID00001", "item 1"){ItemType = itemTypes[0].Id};
            Assert.IsTrue(dataBase.InsertItem(item));
            price = new Price(1.2, 1.1);
            Assert.IsTrue(dataBase.InsertPrice(item, shop, price));
            shopItem = new ShopItem(item, shop, price);
            shopItem.SetNumberOfItems(5);
            Assert.IsTrue(dataBase.InsertShopItem(shopItem));
            tracker = new Tracker(shopItem) {SoldCount = 2};
            Assert.IsTrue(dataBase.InsertTracker(tracker));
        }

        private readonly DataBase dataBase = new DataBase();
        private Shop shop = new Shop();
        private Item item = new Item();
        private Price price = new Price();
        private ShopItem shopItem = new ShopItem();
        private Tracker tracker = new Tracker();
        private ItemType itemType = new ItemType();
    }
}