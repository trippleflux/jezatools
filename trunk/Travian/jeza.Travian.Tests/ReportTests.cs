using HtmlAgilityPack;
using jeza.Travian.Framework;
using MbUnit.Framework;

namespace jeza.Travian.Tests
{
    [TestFixture]
    public class ReportTests
    {
        [Test]
        public void Attacks()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load("..\\..\\Test Files\\berichte.attack.php.html");
            HtmlParser htmlParser = new HtmlParser(htmlDocument);
            Report reportDetails = htmlParser.GetReportDetails();
            Assert.AreEqual("kepek", reportDetails.AttackerName, "AttackerName");
            Assert.AreEqual("00", reportDetails.AttackerVillage, "AttackerVillage");
            Assert.AreEqual("karte.php?d=340795&amp;c=99", reportDetails.AttackerUrl, "AttackerUrl");
            Assert.AreEqual("16/240", reportDetails.CarryText, "CarryText");
            Assert.AreEqual(240, reportDetails.CarryTotal, "CarryTotal");
            Assert.AreEqual(16, reportDetails.CarryAmount, "CarryAmount");
            Assert.AreEqual("21 | 62 | 23 | 64", reportDetails.ResourcesText, "ResourcesText");
            Assert.AreEqual(21, reportDetails.ResourcesWood, "ResourcesWood");
            Assert.AreEqual(62, reportDetails.ResourcesClay, "ResourcesClay");
            Assert.AreEqual(23, reportDetails.ResourcesIron, "ResourcesIron");
            Assert.AreEqual(64, reportDetails.ResourcesCrop, "ResourcesCrop");
        }
    }
}