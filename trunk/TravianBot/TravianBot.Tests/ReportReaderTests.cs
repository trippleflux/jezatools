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
            IReader reportReader = new ReportReader(serverInfo);
            string pageSource = Misc.ReadContent(@"C:\svn\jezaTools\trunk\TravianBot\TravianBot.Tests\TestFiles\berichte.php");
            reportReader.Parse(pageSource);
            reportReader.Process();
        }
    }
}