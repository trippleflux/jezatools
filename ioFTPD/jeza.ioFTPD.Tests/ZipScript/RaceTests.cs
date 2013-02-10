#region
using System;
using System.Collections.Generic;
using jeza.ioFTPD.Framework;
using NUnit.Framework;

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
            race.ParseUpload();
            Assert.IsFalse(race.VirtualPathMatch(Config.SkipPath), "race.SkipPath");
        }

        [Test]
        public void SpeedTest()
        {
            Race race = new Race(ArgsRarPart1);
            race.ParseUpload();
            race.CurrentRaceData.UploadVirtualPath = Config.SpeedTestFolder + "asdfsdfsdf";
            Assert.IsTrue(race.SpeedTest(), "race.SpeedTest");
        }

        [Test]
        public void ParseRaceData ()
        {
            Race race = new Race(ArgsRarPart1);
            race.ParseUpload ();
            race.RaceFile = @"..\..\TestFiles\Race\.ioFTPD.race";
            DataParser dataParser = new DataParser (race);
            dataParser.Parse ();
            Assert.AreEqual (4, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual (4, race.TotalFilesUploaded, "TotalFilesUploaded");
        }

        [Test]
        public void CurrentUploadData()
        {
            Race race = new Race(ArgsRarPart1);
            race.ParseUpload();
            Assert.AreEqual("Rar", race.CurrentRaceData.DirectoryName, "DirectoryName");
            Assert.That(race.CurrentRaceData.DirectoryPath.EndsWith(@"\TestFiles\Rar"), "DirectoryPath");
            Assert.That(race.CurrentRaceData.DirectoryParent.EndsWith(@"\TestFiles"), "DirectoryParent");
            Assert.AreEqual(".rar", race.CurrentRaceData.FileExtension, "FileExtension");
            Assert.AreEqual("infected.part1.rar", race.CurrentRaceData.FileName, "FileName");
            Assert.AreEqual(5000, race.CurrentRaceData.FileSize, "FileSize");
            Assert.AreEqual("NoGroup", race.CurrentRaceData.GroupName, "GroupName");
            Assert.AreEqual(1, race.CurrentRaceData.Speed, "Speed");
            Assert.AreEqual("2e04944c", race.CurrentRaceData.UploadCrc, "UploadCrc");
            Assert.AreEqual(@"..\..\TestFiles\Rar\infected.part1.rar", race.CurrentRaceData.UploadFile, "UploadFile");
            Assert.AreEqual("/TestFiles/Rar/infected.part1.rar", race.CurrentRaceData.UploadVirtualFile, "UploadVirtualFile");
            Assert.AreEqual("NoUser", race.CurrentRaceData.UserName, "UserName");
            Assert.AreEqual(0, race.CurrentRaceData.Uid, "UID");
            Assert.AreEqual(0, race.CurrentRaceData.Gid, "GID");
            Assert.AreEqual("/NoPath", race.CurrentRaceData.UploadVirtualPath, "UploadVirtualPath");
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
            Assert.That(statsUsers, Is.Ordered.Descending);
            //Assert.Sorted(statsUsers, SortOrder.Decreasing);
            List<RaceStatsGroups> statsGroups = race.GetGroupStats ();
            Assert.That(statsGroups, Is.Ordered.Descending);
            //Assert.Sorted(statsGroups, SortOrder.Decreasing);
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