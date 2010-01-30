#region

using ioFTPD.Framework;
using MbUnit.Framework;

#endregion

namespace ioFTPD.Tests
{
    [TestFixture]
    public class OutputTests
    {
        [Test]
        public void Client()
        {
            Race race = new Race(new[] { "asdfasdf" }) {RaceData = new RaceData { TotalFilesExpected = 5 }};
            Output output = new Output(race);
            Assert.AreEqual("=[   0/5   ]=", output.Format("=[   0/{0,-3:B3} ]=¤TotalFilesExpected"));
            Assert.AreEqual("=[   0/asd ]=", output.Format("=[   0/{0,-3:B3} ]=¤asd"));
            race.RaceData.TotalBytesUploaded = 5000;
            Assert.AreEqual("]-[Complete 5MB - 0/5F]-[", output.Format("]-[Complete {0}MB - {1}/{2}F]-[¤TotalMBytesUploaded TotalFilesUploaded TotalFilesExpected"));
            race.RaceData.TotalBytesUploaded = 123456789;
            Assert.AreEqual("]-[Complete 123456MB - 0/5F]-[", output.Format("]-[Complete {0}MB - {1}/{2}F]-[¤TotalMBytesUploaded TotalFilesUploaded TotalFilesExpected"));
        }
    }
}