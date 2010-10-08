using NUnit.Framework;

namespace ProductTracker.Tests
{
    [TestFixture]
    public class ShopTests
    {
        public void AddNew()
        {
            Shop shop = new Shop("asf asdfasd ");
            Assert.IsNotNull(shop, "Shop was not added!");
        }
    }
}