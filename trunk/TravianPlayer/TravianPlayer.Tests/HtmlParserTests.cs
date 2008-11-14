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
			LoginInfo loginInfo = htmlParser.ParseLoginData();

			Game gameInfo = new Game();
			gameInfo.AddLoginInfo(loginInfo);

			Assert.AreEqual("e96a122", gameInfo.GetLoginInfo().TextBoxUserame);
			Assert.AreEqual("e56e857", gameInfo.GetLoginInfo().TextBoxPassword);
			Assert.AreEqual("1226644107", gameInfo.GetLoginInfo().HiddenLoginValue);
			Assert.AreEqual("e08c288", gameInfo.GetLoginInfo().HiddenName);
			Assert.AreEqual("e697604783", gameInfo.GetLoginInfo().HiddenValue);
			Assert.IsNull(gameInfo.GetLoginInfo().HiddenWValue);
		}
	}
}