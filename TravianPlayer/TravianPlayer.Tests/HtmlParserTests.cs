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
			Assert.AreEqual(73913, gameInfo.GetVillageId("00"));
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

		[Test]
		public void ResourcesLevel()
		{
			string pageSource = File.ReadAllText(@"TestFiles\dorf1.php");
			HtmlParser htmlParser = new HtmlParser(pageSource);
			Game gameInfo = htmlParser.ParseResourcesPage();

			/*
			<area href="build.php?id=1" coords="101,33,28" shape="circle" title="Gozdar Stopnja 10">
			<area href="build.php?id=2" coords="165,32,28" shape="circle" title="Žitno polje Stopnja 10">
			<area href="build.php?id=3" coords="224,46,28" shape="circle" title="Gozdar Stopnja 8">
			<area href="build.php?id=4" coords="46,63,28" shape="circle" title="Rudnik železa Stopnja 10">
			<area href="build.php?id=5" coords="138,74,28" shape="circle" title="Glinokop Stopnja 10">
			<area href="build.php?id=6" coords="203,94,28" shape="circle" title="Glinokop Stopnja 8">
			<area href="build.php?id=7" coords="262,86,28" shape="circle" title="Rudnik železa Stopnja 7">
			<area href="build.php?id=8" coords="31,117,28" shape="circle" title="Žitno polje Stopnja 10">
			<area href="build.php?id=9" coords="83,110,28" shape="circle" title="Žitno polje Stopnja 10">
			<area href="build.php?id=10" coords="214,142,28" shape="circle" title="Rudnik železa Stopnja 8">
			<area href="build.php?id=11" coords="269,146,28" shape="circle" title="Rudnik železa Stopnja 10">
			<area href="build.php?id=12" coords="42,171,28" shape="circle" title="Žitno polje Stopnja 10">
			<area href="build.php?id=13" coords="93,164,28" shape="circle" title="Žitno polje Stopnja 10">
			<area href="build.php?id=14" coords="160,184,28" shape="circle" title="Gozdar Stopnja 8">
			<area href="build.php?id=15" coords="239,199,28" shape="circle" title="Žitno polje Stopnja 10">
			<area href="build.php?id=16" coords="87,217,28" shape="circle" title="Glinokop Stopnja 8">
			<area href="build.php?id=17" coords="140,231,28" shape="circle" title="Gozdar Stopnja 9">
			<area href="build.php?id=18" coords="190,232,28" shape="circle" title="Glinokop Stopnja 8">
			 */
			Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(1));
			Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(2));
			Assert.AreEqual(8, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(3));
			Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(4));
			Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(5));
			Assert.AreEqual(8, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(6));
			Assert.AreEqual(7, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(7));
			Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(8));
			Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(9));
			Assert.AreEqual(8, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(10));
			Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(11));
			Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(12));
			Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(13));
			Assert.AreEqual(8, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(14));
			Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(15));
			Assert.AreEqual(8, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(16));
			Assert.AreEqual(9, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(17));
			Assert.AreEqual(8, gameInfo.GetVillageData(73913).GetVillageBuildingsLevel(18));

			Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetVillageBuildingsData(1).Level);
		}

		[Test]
		public void AvailableUnits()
		{
			string pageSource = File.ReadAllText(@"TestFiles\dorf1.php");
			HtmlParser htmlParser = new HtmlParser(pageSource);
			Game gameInfo = htmlParser.ParseResourcesPage();
			/*
			 * <table class="f10">
			 * <tr>
			 * <td><a href="build.php?gid=16"><img class="unit" src="img/un/u/hero.gif" border="0"></a></td>
			 * <td align="right">&nbsp;<b>1</b></td>
			 * <td>Heroj</td>
			 * </tr>
			 * <tr>
			 * <td><a href="build.php?gid=16"><img class="unit" src="img/un/u/11.gif" border="0"></a></td>
			 * <td align="right">&nbsp;<b>6</b></td>
			 * <td>Gorjačarjev</td>
			 * </tr>
			 * <tr>
			 * <td><a href="build.php?gid=16"><img class="unit" src="img/un/u/12.gif" border="0"></a></td>
			 * <td align="right">&nbsp;<b>470</b></td>
			 * <td>Suličarjev</td></tr>
			 * <tr>
			 * <td><a href="build.php?gid=16"><img class="unit" src="img/un/u/13.gif" border="0"></a></td>
			 * <td align="right">&nbsp;<b>10</b></td>
			 * <td>Metalcev sekir</td>
			 * </tr>
			 * <tr><td><a href="build.php?gid=16"><img class="unit" src="img/un/u/14.gif" border="0"></a></td>
			 * <td align="right">&nbsp;<b>50</b></td>
			 * <td>Skavtov</td>
			 * </tr>
			 * <tr>
			 * <td><a href="build.php?gid=16"><img class="unit" src="img/un/u/15.gif" border="0"></a></td>
			 * <td align="right">&nbsp;<b>12</b></td>
			 * <td>Paladinov</td>
			 * </tr>
			 * </table>
			 */
			//Assert.AreEqual(1, gameInfo.GetVillageData(73913).GetUnitCount("Heroj"));
			//Assert.AreEqual(6, gameInfo.GetVillageData(73913).GetUnitCount("Gorjačarjev"));
			//Assert.AreEqual(470, gameInfo.GetVillageData(73913).GetUnitCount("Suličarjev"));
			//Assert.AreEqual(10, gameInfo.GetVillageData(73913).GetUnitCount("Metalcev sekir"));
			//Assert.AreEqual(50, gameInfo.GetVillageData(73913).GetUnitCount("Skavtov"));
			//Assert.AreEqual(6, gameInfo.GetVillageData(73913).UnitsCount);
			//Assert.AreEqual(12, gameInfo.GetVillageData(73913).GetUnitCount("Paladinov"));
		}
	}
}