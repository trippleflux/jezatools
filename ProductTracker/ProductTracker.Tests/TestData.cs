using NUnit.Framework;

namespace ProductTracker.Tests
{
    public class TestData
    {
        public static Overview PrepareTestData()
        {
            ShopItem shopItem = new ShopItem(new Item("ID0001", "Cestitka 1"),
                                               new Shop("trgovina 1"),
                                               new Price(4, 3.2));
            Assert.IsNotNull(shopItem, "Items not added to shop!");
            shopItem.SetNumberOfItems(3);
            Assert.AreEqual(3, shopItem.NumberOfItems, "ShopItem missmatch!");
            Overview overview = new Overview();
            overview.AddShopItem(shopItem);
            return overview;
        }
    }
}