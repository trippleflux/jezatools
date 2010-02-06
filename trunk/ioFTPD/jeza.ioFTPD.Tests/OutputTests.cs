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
        public void Client ()
        {
            Race race = new Race (new[] {"asdfasdf"}) {TotalFilesExpected = 5};
            Output output = new Output (race);
            Assert.AreEqual ("=[   0/5   ]=", output.Format ("=[   0/{0,-3:B3} ]=¤TotalFilesExpected"));
            Assert.AreEqual ("=[   0/asd ]=", output.Format ("=[   0/{0,-3:B3} ]=¤asd"));
            RaceStats raceStats = new RaceStats ();
            raceStats
                .AddFileName ("a.txt")
                .AddCrc32 ("aabbccdd")
                .AddFileUploaded (true)
                .AddFileSpeed (100)
                .AddFileSize (123456789)
                .AddUserName ("user1")
                .AddGroupName ("group1");
            race.AddRaceStats (raceStats);
            Assert.AreEqual ("]-[Complete 123456789MB - 1/5F]-[",
                             output.Format (
                                 "]-[Complete {0}MB - {1}/{2}F]-[¤TotalBytesUploaded TotalFilesUploaded TotalFilesExpected"));
            Assert.AreEqual ("]-[Complete 123MB - 1/5F]-[",
                             output.Format (
                                 "]-[Complete {0}MB - {1}/{2}F]-[¤TotalMegaBytesUploaded TotalFilesUploaded TotalFilesExpected"));
            Assert.AreEqual ("|  1.           user1/group1           123MB   100kBit/s   1F |",
                             output.FormatUserStats (1,
                                                     race.GetUserStats () [0],
                                                     "| {0,2:B2}. {1,15:B15}/{2,-15:B15} {3,4:B4}MB {4,5:B5}kBit/s {5,3:B3}F |¤Possition UserName GroupName MegaBytesUploaded AverageSpeed FilesUploaded"));
            Assert.AreEqual ("|  1. group1           123MB   100kBit/s   1F |",
                             output.FormatGrouptats (1,
                                                     race.GetGroupStats () [0],
                                                     "| {0,2:B2}. {1,-15:B15} {2,4:B4}MB {3,5:B5}kBit/s {4,3:B3}F |¤Possition GroupName MegaBytesUploaded AverageSpeed FilesUploaded"));
        }
    }
}