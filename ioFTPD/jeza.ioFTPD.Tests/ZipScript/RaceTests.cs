#region
using System;
using System.Collections.Generic;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;

#endregion

namespace jeza.ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class RaceTests : ZipScriptBase
    {
        [Test]
        public void SkipPath()
        {
            Race race = new Race(ArgsRarPart1);
            race.Parse();
            Assert.IsFalse(race.SkipPath, "race.SkipPath");
        }

        [Test]
        public void ParseRaceData ()
        {
            Race race = new Race (ArgsRarPart1);
            race.Parse ();
            DataParser dataParser = new DataParser (race) {RaceFile = @"..\..\TestFiles\Race\.ioFTPD.race"};
            dataParser.Parse ();
            Assert.AreEqual (4, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual (0, race.TotalFilesUploaded, "TotalFilesUploaded");
        }

        [Test]
        public void CurrentUploadData()
        {
            Race race = new Race(ArgsRarPart1);
            race.Parse();
            Assert.AreEqual("Rar", race.CurrentUploadData.DirectoryName, "DirectoryName");
            Assert.EndsWith(race.CurrentUploadData.DirectoryPath, @"\TestFiles\Rar", "DirectoryPath");
            Assert.EndsWith(race.CurrentUploadData.DirectoryParent, @"\TestFiles", "DirectoryParent");
            Assert.AreEqual(".rar", race.CurrentUploadData.FileExtension, "FileExtension");
            Assert.AreEqual("infected.part1.rar", race.CurrentUploadData.FileName, "FileName");
            Assert.AreEqual(5000, race.CurrentUploadData.FileSize, "FileSize");
            Assert.AreEqual("NoGroup", race.CurrentUploadData.GroupName, "GroupName");
            Assert.AreEqual(1, race.CurrentUploadData.Speed, "Speed");
            Assert.AreEqual("2e04944c", race.CurrentUploadData.UploadCrc, "UploadCrc");
            Assert.AreEqual(@"..\..\TestFiles\Rar\infected.part1.rar", race.CurrentUploadData.UploadFile, "UploadFile");
            Assert.AreEqual("/TestFiles/Rar/infected.part1.rar", race.CurrentUploadData.UploadVirtualFile, "UploadVirtualFile");
            Assert.AreEqual("NoUser", race.CurrentUploadData.UserName, "UserName");
            Assert.AreEqual("0", race.CurrentUploadData.Uid, "UID");
            Assert.AreEqual("0", race.CurrentUploadData.Gid, "GID");
            Assert.AreEqual("/NoPath", race.CurrentUploadData.UploadVirtualPath, "UploadVirtualPath");
        }

        [Test]
        public void AddRaceStats ()
        {
            Race race = new Race (ArgsRarPart1);
            RaceStats raceStats = new RaceStats ();
            raceStats
                .AddFileName ("a.txt")
                .AddCrc32 ("aabbccdd")
                .AddFileUploaded (true)
                .AddFileSpeed (1000)
                .AddFileSize (1000000)
                .AddUserName ("user1")
                .AddGroupName ("group1");
            race.AddRaceStats (raceStats);
            Assert.AreEqual(1, race.TotalFilesUploaded, "TotalFilesUploaded");
            Assert.AreEqual((UInt64)1000000, race.TotalBytesUploaded, "TotalBytesUploaded");
            // Ignored because file was not uploaded
            raceStats = new RaceStats();
            raceStats
                .AddFileName("d.txt")
                .AddCrc32("33bbccdd")
                .AddFileUploaded(false)
                .AddFileSpeed(400)
                .AddFileSize(4000000)
                .AddUserName("user4")
                .AddGroupName("group3");
            race.AddRaceStats(raceStats);
            Assert.AreEqual(1, race.TotalFilesUploaded, "TotalFilesUploaded");
            Assert.AreEqual((UInt64)1000000, race.TotalBytesUploaded, "TotalBytesUploaded");
            raceStats = new RaceStats();
            raceStats
                .AddFileName ("c.txt")
                .AddCrc32 ("22bbccdd")
                .AddFileUploaded (true)
                .AddFileSpeed (300)
                .AddFileSize (3000000)
                .AddUserName ("user3")
                .AddGroupName ("group1");
            race.AddRaceStats (raceStats);
            Assert.AreEqual(2, race.TotalFilesUploaded, "TotalFilesUploaded");
            Assert.AreEqual((UInt64)4000000, race.TotalBytesUploaded, "TotalBytesUploaded");
            raceStats = new RaceStats();
            raceStats
                .AddFileName("b.txt")
                .AddCrc32("11bbccdd")
                .AddFileUploaded(true)
                .AddFileSpeed(200)
                .AddFileSize(2000000)
                .AddUserName("user2")
                .AddGroupName("group2");
            race.AddRaceStats(raceStats);
            Assert.AreEqual(3, race.TotalFilesUploaded, "TotalFilesUploaded");
            Assert.AreEqual ((UInt64) 6000000, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual ((UInt64) 5, race.TotalMegaBytesUploaded, "TotalMegaBytesUploaded");
            Assert.AreEqual (2, race.TotalGroupsRacing, "TotalGroupsRacing");
            Assert.AreEqual (3, race.TotalUsersRacing, "TotalUsersRacing");
            Assert.AreEqual (3, race.GetUserStats ().Count, "GetUserStats");
            Assert.AreEqual(2, race.GetGroupStats().Count, "GetGroupStats");
            List<RaceStatsUsers> statsUsers = race.GetUserStats();
            Assert.Sorted(statsUsers, SortOrder.Decreasing);
            List<RaceStatsGroups> statsGroups = race.GetGroupStats ();
            Assert.Sorted(statsGroups, SortOrder.Decreasing);
            //Console
            foreach (RaceStatsUsers raceStatsUser in statsUsers)
            {
                Console.WriteLine(raceStatsUser);
            }
            foreach (RaceStatsGroups raceStatsGroups in statsGroups)
            {
                Console.WriteLine(raceStatsGroups);
            }
        }
    }
}