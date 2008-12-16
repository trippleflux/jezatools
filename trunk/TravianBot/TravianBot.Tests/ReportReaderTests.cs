using System.Text.RegularExpressions;
using NUnit.Framework;
using TravianBot.Framework;

namespace TravianBot.Tests
{
    [TestFixture]
    public class ReportReaderTests
    {
        [Test]
        public void ParseReports()
        {
            ServerInfo serverInfo = new ServerInfo();
            ReportReader reportReader = new ReportReader(serverInfo);
            string pageSource = Misc.ReadContent(@"..\..\..\Samples\TestFiles\berichte.php");
            reportReader.Parse(pageSource);
            MatchCollection reportCollection = reportReader.ReportCollection;
            Assert.AreEqual(4, reportCollection.Count);
        }
    }
}