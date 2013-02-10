using NUnit.Framework;

namespace jeza.ioFTPD.Tests.Rescan
{
    [TestFixture]
    internal class RescanTests
    {
        [Test]
        public void Folder()
        {
            const string sourceFolder = @"..\..\TestFiles\Rar";
            string[] args = new[] {"rescan"};
            Framework.Rescan rescan = new Framework.Rescan(args)
                                      {
                                          SourceFolder = sourceFolder,
                                      };
            rescan.Parse();
            Assert.IsNotNull(rescan.DataParserSfv, "DataParserSfv");
            rescan.Process();
            //Console.WriteLine(rescan.RescanStats.ToString());
            Assert.AreEqual(4, rescan.RescanStats.TotalFiles, "TotalFiles");
            Assert.AreEqual(4, rescan.RescanStats.OkFiles, "OkFiles");
            Assert.AreEqual(0, rescan.RescanStats.MissingFiles, "MissingFiles");
            Assert.AreEqual(0, rescan.RescanStats.FailedFiles, "FailedFiles");
        }

        [Test]
        public void File()
        {
            const string sourceFolder = @"..\..\TestFiles\Rar";
            string[] args = new[] { "rescan", "infected.part1.rar" };
            Framework.Rescan rescan = new Framework.Rescan(args)
            {
                SourceFolder = sourceFolder,
            };
            rescan.Parse();
            Assert.IsNotNull(rescan.DataParserSfv, "DataParserSfv");
            rescan.Process();
            //Console.WriteLine(rescan.RescanStats.ToString());
            Assert.AreEqual(4, rescan.RescanStats.TotalFiles, "TotalFiles");
            Assert.AreEqual(1, rescan.RescanStats.OkFiles, "OkFiles");
            Assert.AreEqual(0, rescan.RescanStats.MissingFiles, "MissingFiles");
            Assert.AreEqual(0, rescan.RescanStats.FailedFiles, "FailedFiles");
        }
    }
}