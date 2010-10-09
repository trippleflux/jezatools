using System.Collections.Generic;
using NUnit.Framework;

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
            DataBase dataBase = new DataBase();
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
            DataBase dataBase = new DataBase();
            dataBase.DeleteAllShops();
            const string shopName = "trgovina 1";
            Shop shop = new Shop(shopName);
            Assert.IsTrue(dataBase.InsertShop(shop));
            IList<Shop> shops = dataBase.GetShops();
            Assert.IsNotNull(shops, "dataBase.GetShops() is NULL!");
            Assert.AreEqual(shop.Id, shops[0].Id, "{0} was not found!", shopName);
        }

        /// <summary>
        /// Gets the available items.
        /// </summary>
        [Test]
        public void GetAvailableItems()
        {
            DataBase dataBase = new DataBase();
            dataBase.DeleteAllItems();
            Item item = new Item("ID00001", "item 1");
            Assert.IsTrue(dataBase.InsertItem(item));
            IList<Item> items = dataBase.GetItems();
            Assert.IsNotNull(items, "dataBase.GetItems() is NULL!");
            Assert.AreEqual(item.Id, items[0].Id, "{0} was not found!", item.Name);
            Assert.AreEqual(item.UniqueId, items[0].UniqueId, "{0} was not found!", item.Name);
        }
    }
}
