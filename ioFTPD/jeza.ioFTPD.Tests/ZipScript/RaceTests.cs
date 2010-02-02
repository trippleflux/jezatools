#region
using System;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;

#endregion

namespace jeza.ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class RaceTests : ZipScriptBase
    {
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
        public void AddRaceStats ()
        {
            Race race = new Race (ArgsRarPart1);
            RaceStats raceStats = new RaceStats ();
            raceStats
                .AddFileName ("a.txt")
                .AddCrc32 ("aabbccdd")
                .AddFileUploaded (true)
                .AddFileSpeed (100)
                .AddFileSize (1000000)
                .AddUserName ("user1")
                .AddGroupName ("group1");
            race.AddRaceStats (raceStats);
            raceStats = new RaceStats ();
            raceStats
                .AddFileName ("b.txt")
                .AddCrc32 ("11bbccdd")
                .AddFileUploaded (true)
                .AddFileSpeed (200)
                .AddFileSize (2000000)
                .AddUserName ("user2")
                .AddGroupName ("group2");
            race.AddRaceStats (raceStats);
            raceStats = new RaceStats ();
            raceStats
                .AddFileName ("c.txt")
                .AddCrc32 ("22bbccdd")
                .AddFileUploaded (true)
                .AddFileSpeed (300)
                .AddFileSize (3000000)
                .AddUserName ("user3")
                .AddGroupName ("group1");
            race.AddRaceStats (raceStats);
            // Ignored because file was not uploaded
            raceStats = new RaceStats ();
            raceStats
                .AddFileName ("d.txt")
                .AddCrc32 ("33bbccdd")
                .AddFileUploaded (false)
                .AddFileSpeed (400)
                .AddFileSize (4000000)
                .AddUserName ("user4")
                .AddGroupName ("group3");
            race.AddRaceStats (raceStats);
            Assert.AreEqual (3, race.TotalFilesUploaded, "TotalFilesUploaded");
            Assert.AreEqual ((UInt64) 6000000, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual ((UInt64) 6, race.TotalMegaBytesUploaded, "TotalMegaBytesUploaded");
            Assert.AreEqual (2, race.TotalGroupsRacing, "TotalGroupsRacing");
            Assert.AreEqual (3, race.TotalUsersRacing, "TotalUsersRacing");
            Assert.AreEqual (3, race.GetUserStats ().Count, "GetUserStats");
            Assert.AreEqual(2, race.GetGroupStats().Count, "GetGroupStats");
            foreach (RaceStatsUsers raceStatsUser in race.GetUserStats())
            {
                Console.WriteLine (raceStatsUser);
            }
            foreach (RaceStatsGroups raceStatsGroups in race.GetGroupStats())
            {
                Console.WriteLine(raceStatsGroups);
            }
        }
    }
}