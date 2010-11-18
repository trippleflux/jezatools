using NUnit.Framework;

namespace ProductTracker.Tests
{
    public class TestData
    {
        public static Overview PrepareTestData()
        {
            Item item = new Item("ID0001", "Cestitka 1");
            Shop shop = new Shop("trgovina 1");
            Price price = new Price(4, 3.2) {ItemId = item.UniqueId, ShopId = shop.Id};
            ShopItem shopItem = new ShopItem() {ItemId = item.UniqueId, ShopId = shop.Id, PriceId = price.Id};
            Assert.IsNotNull(shopItem, "Items not added to shop!");
            shopItem.SetNumberOfItems(3);
            Assert.AreEqual(3, shopItem.NumberOfItems, "ShopItem missmatch!");
            Overview overview = new Overview();
            overview.AddShopItem(shopItem);
            return overview;
        }
    }
}