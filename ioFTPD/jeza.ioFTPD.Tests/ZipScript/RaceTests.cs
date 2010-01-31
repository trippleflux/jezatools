#region
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
            Assert.AreEqual(4, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(0, race.TotalFilesUploaded, "TotalFilesUploaded");
        }
    }
}