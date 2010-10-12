using MbUnit.Framework;

namespace TW.Tests
{
    [TestFixture]
    public class DataBase
    {
        [Test]
        public void UpdateGoods()
        {
            Helper.DataBase dataBase = new Helper.DataBase();
            dataBase.UpdateGoodsInfo("Goods");
        }
    }
}