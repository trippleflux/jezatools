#region

using HtmlAgilityPack;
using MbUnit.Framework;

#endregion

namespace jeza.Travian.Tests
{
    public class WebTest
    {
        [Test]
        public void Login()
        {
            HtmlWeb htmlDocument = new HtmlWeb();
            HtmlDocument document = htmlDocument.Load("http://s1.travian.com/login.php");
            htmlDocument.UseCookies = true;
            //<input type="hidden" name="login" value="1267389391" />
            HtmlNode node = document.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='login']");
            string loginValue = node.Attributes["value"].Value;
            Assert.IsNotNull(loginValue, "Login value!");
        }
    }
}