#region
using jeza.ioFTPD.Framework;
using MbUnit.Framework;

#endregion

namespace jeza.ioFTPD.Tests
{
    [TestFixture]
    public class OutputTests
    {
        [Test]
        public void Log()
        {
            Framework.Log.Debug("test line");
            Framework.Log.Debug("test linewith arguments {0} {1}", 1, 2);
        }

        [Test]
        public void Client ()
        {
            Race race = new Race (new[] {"asdfasdf"}) {TotalFilesExpected = 5};
            Output output = new Output (race);
            Assert.AreEqual ("=[   0/5   ]=", output.Format ("=[   0/{0,-3:B3} ]=¤TotalFilesExpected"));
            Assert.AreEqual ("=[   0/asd ]=", output.Format ("=[   0/{0,-3:B3} ]=¤asd"));
            RaceStats raceStats = new RaceStats ();
            const ulong bytes = 123456789;
            raceStats
                .AddFileName ("a.txt")
                .AddCrc32 ("aabbccdd")
                .AddFileUploaded (true)
                .AddFileSpeed (100)
                .AddFileSize (bytes)
                .AddUserName ("user1")
                .AddGroupName ("group1");
            race.AddRaceStats (raceStats);
            Assert.AreEqual ("]-[Complete 123456789MB - 1/5F]-[",
                             output.Format (
                                 "]-[Complete {0}MB - {1}/{2}F]-[¤TotalBytesUploaded TotalFilesUploaded TotalFilesExpected"));
            Assert.AreEqual ("]-[Complete 117MB - 1/5F]-[",
                             output.Format (
                                 "]-[Complete {0}MB - {1}/{2}F]-[¤TotalMegaBytesUploaded TotalFilesUploaded TotalFilesExpected"));
            Assert.AreEqual ("|  1.           user1/group1           117MB   100kBit/s   1F |",
                             output.FormatUserStats (1,
                                                     race.GetUserStats () [0],
                                                     "| {0,2:B2}. {1,15:B15}/{2,-15:B15} {3,6:B6} {4,5:B5}kBit/s {5,3:B3}F |¤Possition UserName GroupName FormatBytesUploaded AverageSpeed FilesUploaded"));
            Assert.AreEqual ("|  1. group1           117MB   100kBit/s   1F |",
                             output.FormatGroupStats (1,
                                                      race.GetGroupStats () [0],
                                                      "| {0,2:B2}. {1,-15:B15} {2,6:B6} {3,5:B5}kBit/s {4,3:B3}F |¤Possition GroupName FormatBytesUploaded AverageSpeed FilesUploaded"));
            Assert.AreEqual ("###--------------", output.Format ("{0}¤ProgressBar"), "ProgressBar");
            Assert.AreEqual ("117MB", output.FormatSize (bytes), "FormatBytesUploaded");
        }
    }
}