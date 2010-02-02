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
        public void Client()
        {
            Race race = new Race(new[] { "asdfasdf" }) {TotalFilesExpected = 5 };
            Output output = new Output(race);
            Assert.AreEqual("=[   0/5   ]=", output.Format("=[   0/{0,-3:B3} ]=¤TotalFilesExpected"));
            Assert.AreEqual("=[   0/asd ]=", output.Format("=[   0/{0,-3:B3} ]=¤asd"));
            RaceStats raceStats = new RaceStats();
            raceStats
                .AddFileName("a.txt")
                .AddCrc32("aabbccdd")
                .AddFileUploaded(true)
                .AddFileSpeed(100)
                .AddFileSize(123456789)
                .AddUserName("user1")
                .AddGroupName("group1");
            race.AddRaceStats(raceStats); 
            Assert.AreEqual("]-[Complete 123456789MB - 1/5F]-[", output.Format("]-[Complete {0}MB - {1}/{2}F]-[¤TotalBytesUploaded TotalFilesUploaded TotalFilesExpected"));
            Assert.AreEqual("]-[Complete 123MB - 1/5F]-[", output.Format("]-[Complete {0}MB - {1}/{2}F]-[¤TotalMegaBytesUploaded TotalFilesUploaded TotalFilesExpected"));
        }
    }
}