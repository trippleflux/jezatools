using System;
using System.IO;
using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Tests.ZipScript;
using NUnit.Framework;

namespace jeza.ioFTPD.Tests
{
    [TestFixture]
    public class FileFolderTests : ZipScriptBase
    {
        [Test]
        public void CreateLink()
        {
            Race race = new Race(ArgsRarPart1);
            race.ParseUpload();
            TagManager tagManager = new TagManager(race);
            const string testlink = "[iNCOMPLETE]-testLink";
            tagManager.CreateSymLink(".", testlink);
            Assert.IsTrue(Directory.Exists(testlink));
            Directory.Delete(testlink);
        }

        [Test]
        public void DiskInfo()
        {
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in driveInfos)
            {
                DriveInformation driveInformation = new DriveInformation(driveInfo);
                Console.WriteLine(driveInformation.ToString());
            }
        }
    }
}