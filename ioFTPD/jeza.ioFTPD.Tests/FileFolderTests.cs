using System;
using System.IO;
using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Tests.ZipScript;
using MbUnit.Framework;

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

        [Test]
        public void SerializeArchiveSettings()
        {
            ArchiveTask archiveTask = new ArchiveTask
                                      {
                                          ArchiveStatus = ArchiveStatus.Enabled,
                                          ArchiveType = ArchiveType.Move,
                                          Source = "C:\\temp",
                                          Destination = "D:\\temp",
                                          Action = new ArchiveAction()
                                                   {
                                                       Id = ArchiveActionAttribute.TotalUsedSpace,
                                                       Value = 120*1024*1024,
                                                       MinFolderAction = 10,
                                                   },
                                      };
            ArchiveConfiguration archiveConfiguration = new ArchiveConfiguration();
            archiveConfiguration.ArchiveTasks = new ArchiveTask[] {archiveTask};
            Extensions.Serialize(archiveConfiguration, "archiveConfiguration.xml", "http://jeza.ioFTPD.Tools/XMLSchema.xsd");
        }
    }
}