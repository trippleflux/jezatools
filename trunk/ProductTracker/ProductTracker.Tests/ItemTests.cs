#region

using NUnit.Framework;

#endregion

namespace ProductTracker.Tests
{
    [TestFixture]
    public class ItemTests
    {
        /// <summary>
        /// Adds the new item.
        /// </summary>
        [Test]
        public void AddNewItem()
        {
            const string name = "Cestitka 1";
            const string id = "ID0001";
            Item item = new Item(id, name);
            Assert.AreEqual(name, item.Name, "Name missmatch!");
            Assert.AreEqual(id, item.Id, "Id missmatch!");
        }

        /// <summary>
        /// Makes sure the id associated with the item is unique.
        /// </summary>
        [Test]
        public void UniqueId()
        {
            const string name = "Cestitka 1";
            const string id = "ID0001";
            Item item1 = new Item(id, name);
            Item item2 = new Item(id, name);
            Assert.AreNotEqual(item1.UniqueId, item2.UniqueId, "UniqueId missmatch!");
        }

        /// <summary>
        /// Adds the item to shop.
        /// </summary>
        [Test]
        public void AddItemToShop()
        {
            Item item = new Item("ID0001", "Cestitka 1");
            Shop shop = new Shop("trgovina 1");
            Price price = new Price(4, 3.2) {ItemId = item.UniqueId, ShopId = shop.Id};
            ShopItem shopItem = new ShopItem {ItemId = item.UniqueId, ShopId = shop.Id, PriceId = price.Id};
            Assert.IsNotNull(shopItem, "Items not added to shop!");
            shopItem.SetNumberOfItems(3);
            Assert.AreEqual(3, shopItem.NumberOfItems, "ShopItem missmatch!");
            Overview overview = new Overview();
            overview.AddShopItem(shopItem);
            Overview temp = overview;
        }
    }
}