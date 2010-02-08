using System.IO;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests
{
    [TestFixture]
    public class FileFolderTests : ZipScript.ZipScriptBase
    {
        [Test]
        public void CreateLink()
        {
            Race race = new Race (ArgsRarPart1);
            race.Parse ();
            TagManager tagManager = new TagManager (race);
            const string testlink = "[iNCOMPLETE]-testLink";
            tagManager.CreateSymLink (".", testlink);
            Assert.IsTrue(Directory.Exists(testlink));
            Directory.Delete (testlink);
        }
    }
}