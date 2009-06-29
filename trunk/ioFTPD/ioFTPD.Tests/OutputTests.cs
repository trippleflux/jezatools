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
            Race race = new Race(new[] {"asdfasdf"});
            race.TotalFilesExpected = 5;
            Output output = new Output(race);
            Assert.AreEqual("=[   0/5   ]=", output.Format("=[   0/{0,-3:B3} ]=¤TotalFilesExpected"));
        }
    }
}