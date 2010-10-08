using NUnit.Framework;

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
            TestData.PrepareTestData();
        }
    }
}