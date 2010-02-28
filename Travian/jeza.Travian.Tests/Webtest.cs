#region

using System;
using System.Collections.Specialized;
using System.Globalization;
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
            NameValueCollection postData = new NameValueCollection(1);
            postData.Add("w", "1680%3A1050");
            postData.Add("login", loginValue);
            postData.Add("name", "asd");
            postData.Add("password", "asd");
            postData.Add("s1.x", "35");
            postData.Add("s1.y", "9");
            postData.Add("s1", "login");
            HtmlDocument load = htmlDocument.SubmitFormValues(postData, "http://s1.travian.com/dorf1.php");
            string innerText = load.DocumentNode.InnerText;
        }
    }
}