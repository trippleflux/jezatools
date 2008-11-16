#region

using System.IO;
using MbUnit.Framework;
using TravianPlayer.Framework;

#endregion

namespace TravianPlayer.Tests
{
	[TestFixture]
	public class HtmlParserTests
	{
		[Test]
		public void LoginInfo()
		{
			string pageSource = File.ReadAllText(@"TestFiles\login.php");
			HtmlParser htmlParser = new HtmlParser(pageSource);
			LoginInfo loginInfo = htmlParser.ParseLoginPage();

			Game gameInfo = new Game();
			gameInfo.AddLoginInfo(loginInfo);

			Assert.AreEqual("e96a122", gameInfo.GetLoginInfo().TextBoxUserame);
			Assert.AreEqual("e56e857", gameInfo.GetLoginInfo().TextBoxPassword);
			Assert.AreEqual("1226644107", gameInfo.GetLoginInfo().HiddenLoginValue);
			Assert.AreEqual("e08c288", gameInfo.GetLoginInfo().HiddenName);
			Assert.AreEqual("e697604783", gameInfo.GetLoginInfo().HiddenValue);
			Assert.IsNull(gameInfo.GetLoginInfo().HiddenWValue);
		}

		[Test]
		public void VillagesList()
		{
			string pageSource = File.ReadAllText(@"TestFiles\dorf1.php");
			HtmlParser htmlParser = new HtmlParser(pageSource);
			Game gameInfo = htmlParser.ParseResourcesPage();
			Assert.AreEqual(2, gameInfo.GetVillagesCount);
			Assert.AreEqual("00", gameInfo.GetVillageName(73913));
			Assert.AreEqual("01", gameInfo.GetVillageName(83117));
		}

		[Test]
		public void UserId()
		{
			string pageSource = File.ReadAllText(@"TestFiles\dorf1.php");
			HtmlParser htmlParser = new HtmlParser(pageSource);
			Game gameInfo = htmlParser.ParseResourcesPage();
			Assert.AreEqual(9500, gameInfo.UserId);
		}

		[Test]
		public void ProductionForVillage()
		{
			string pageSource = File.ReadAllText(@"TestFiles\dorf1.php");
			HtmlParser htmlParser = new HtmlParser(pageSource);
			Game gameInfo = htmlParser.ParseResourcesPage();

			Assert.AreEqual(681, gameInfo.GetVillageData(73913).GetVillageProduction().WoodPerHour);
			Assert.AreEqual(625, gameInfo.GetVillageData(73913).GetVillageProduction().ClayPerHour);
			Assert.AreEqual(713, gameInfo.GetVillageData(73913).GetVillageProduction().IronPerHour);
			Assert.AreEqual(553, gameInfo.GetVillageData(73913).GetVillageProduction().CropPerHour);
			Assert.AreEqual(4485, gameInfo.GetVillageData(73913).GetVillageProduction().WoodTotal);
			Assert.AreEqual(5273, gameInfo.GetVillageData(73913).GetVillageProduction().ClayTotal);
			Assert.AreEqual(3809, gameInfo.GetVillageData(73913).GetVillageProduction().IronTotal);
			Assert.AreEqual(4350, gameInfo.GetVillageData(73913).GetVillageProduction().CropTotal);
			Assert.AreEqual(21400, gameInfo.GetVillageData(73913).GetVillageProduction().WarehouseKapacity);
			Assert.AreEqual(14400, gameInfo.GetVillageData(73913).GetVillageProduction().GranaryKapacity);
		}
	}
}