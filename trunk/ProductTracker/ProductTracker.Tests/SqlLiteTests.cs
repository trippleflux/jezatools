﻿#region

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
            ShopItem shopItem = new ShopItem(item, shop, price);
            shopItem.SetNumberOfItems(5);
            Assert.IsTrue(dataBase.InsertShopItem(shopItem));
            ShopItem actualShopItem = dataBase.GetShopItem(item, shop);
            Assert.AreEqual(item.UniqueId, actualShopItem.ItemId, "ItemId missmatch!");
            Assert.AreEqual(shop.Id, actualShopItem.ShopId, "ShopId missmatch!");
            Assert.AreEqual(price.Id, actualShopItem.PriceId, "PriceId missmatch!");
            Assert.AreEqual(5, actualShopItem.NumberOfItems, "NumberOfItems missmatch!");
        }

        [SetUp]
        public void Setup()
        {
            dataBase.DeleteAllItems();
            dataBase.DeleteAllShops();
            const string shopName = "trgovina 1";
            shop = new Shop(shopName);
            Assert.IsTrue(dataBase.InsertShop(shop));
            item = new Item("ID00001", "item 1");
            Assert.IsTrue(dataBase.InsertItem(item));
            price = new Price(1.2, 1.1);
            Assert.IsTrue(dataBase.InsertPrice(item, shop, price));
        }

        private readonly DataBase dataBase = new DataBase();
        private Shop shop = new Shop();
        private Item item = new Item();
        private Price price = new Price();
    }
}