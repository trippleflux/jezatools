#region

using System;
using System.Collections.Generic;
using System.Data;
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
            DataSet shops = dataBase.GetShops();
            Assert.IsNotNull(shops, "dataBase.GetShops() is NULL!");
            object[] itemArray = shops.Tables[Misc.DataTableNameOfShops].Rows[0].ItemArray;
            Assert.AreEqual(shop.Name, itemArray.GetValue(0), "{0} was not found!", shop.Name);
            Assert.AreEqual(shop.Address, itemArray.GetValue(1), "{0} was not found!", shop.Address);
            Assert.AreEqual(shop.Owner, itemArray.GetValue(2), "{0} was not found!", shop.Owner);
            Assert.AreEqual(shop.PostalCode, itemArray.GetValue(3), "{0} was not found!", shop.PostalCode);
            Assert.AreEqual(shop.City, itemArray.GetValue(4), "{0} was not found!", shop.City);
            Assert.AreEqual(shop.IsCompany, itemArray.GetValue(5), "{0} was not found!", shop.IsCompany);
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
            DataSet items = dataBase.GetItems();
            Assert.IsNotNull(items, "dataBase.GetItems() is NULL!");
            object[] itemArray = items.Tables[Misc.DataTableNameOfItems].Rows[0].ItemArray;
            Assert.AreEqual(item.Id, itemArray.GetValue(0), "{0} was not found!", item.Id);
            Assert.AreEqual(item.Name, itemArray.GetValue(1), "{0} was not found!", item.Name);
            Assert.AreEqual(item.Notes, itemArray.GetValue(2), "{0} was not found!", item.Notes);
            Assert.AreEqual(ItemTypeName, itemArray.GetValue(3), "{0} was not found!", item.ItemTypeName);
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

        /// <summary>
        /// Gets the shop.
        /// </summary>
        [Test]
        public void GetShop()
        {
            CheckShop(shop);
        }

        private void CheckShop(Shop shopToCheck)
        {
            Shop actualShop = dataBase.GetShop(shopToCheck.Id.ToString());
            Assert.AreEqual(shopToCheck.Id, actualShop.Id, "Shop.Id missmatch!");
            Assert.AreEqual(shopToCheck.Name, actualShop.Name, "Shop.Name missmatch!");
            Assert.AreEqual(shopToCheck.Address, actualShop.Address, "Shop.Address missmatch!");
            Assert.AreEqual(shopToCheck.Owner, actualShop.Owner, "Shop.Owner missmatch!");
            Assert.AreEqual(shopToCheck.PostalCode, actualShop.PostalCode, "Shop.PostalCode missmatch!");
            Assert.AreEqual(shopToCheck.City, actualShop.City, "Shop.City missmatch!");
            Assert.AreEqual(shopToCheck.IsCompany, actualShop.IsCompany, "Shop.IsCompany missmatch!");
        }

        /// <summary>
        /// When shop was not found, method should return <c>null</c>.
        /// </summary>
        [Test]
        public void ShopNotFound()
        {
            Shop actualShop = dataBase.GetShop(Guid.NewGuid().ToString());
            Assert.IsNull(actualShop, "Shop was nmot expected!");
        }

        [Test]
        public void UpdateShop()
        {
            Shop newShop = new Shop("trgovina 2")
                {
                    Id = shop.Id,
                    Address = "trgovina 2 address",
                    City = "trgovina 2 city",
                    Owner = "trgovina 2 owner",
                    PostalCode = 9999,
                    IsCompany = false
                };
            dataBase.UpdateShop(newShop);
            CheckShop(newShop);
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
            itemType = new ItemType() {Name = ItemTypeName};
            Assert.IsTrue(dataBase.InsertItemType(itemType));
            IList<ItemType> itemTypes = dataBase.GetItemTypes();
            const string shopName = "trgovina 1";
            shop = new Shop(shopName)
                {Address = "asdasd", City = "assdf fs", IsCompany = true, Owner = "asdfaf safwefase", PostalCode = 1234};
            Assert.IsTrue(dataBase.InsertShop(shop));
            item = new Item("ID00001", "item 1")
                {
                    ItemType = itemTypes[0].Id,
                    Notes = "bla bla bal...",
                };
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
        const string ItemTypeName = "cestitka";
    }
}