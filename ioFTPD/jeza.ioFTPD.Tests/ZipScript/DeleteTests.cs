using System;
using jeza.ioFTPD.Framework;
using NUnit.Framework;

namespace jeza.ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class DeleteTests : ZipScriptBase
    {
        /// <summary>
        /// Delete a file when race file does not exists.
        /// </summary>
        [Test]
        public void NoRaceFileZipCorrect()
        {
            CleanTestFilesOutput();
            string[] args = ArgsCorrectZipDeleteFile1;
            Race race = new Race(args)
                        {
                            SourceFolder = @"..\..\TestFiles\ZipCorrect",
                        };
            race.ParseDelete();
            Assert.IsNotNull(race.CurrentRaceData);
            Assert.IsTrue(race.CurrentRaceData.RaceType == RaceType.Delete);
            Assert.AreEqual(race.CurrentRaceData.FileName, args[2], "FileName missmatch!");
            race.ProcessDelete();
        }

        /// <summary>
        /// Delete a file when race was complete.
        /// </summary>
        [Test]
        public void ZipCorrect()
        {
            ZipTests zipTests = new ZipTests();
            zipTests.ZipRace();

            string[] args = ArgsCorrectZipDeleteFile1;
            Race race = new Race(args)
            {
                SourceFolder = @"..\..\TestFiles\ZipCorrect",
            };
            race.ParseDelete();
            Assert.IsNotNull(race.CurrentRaceData);
            Assert.IsTrue(race.CurrentRaceData.RaceType == RaceType.Delete);
            Assert.AreEqual(race.CurrentRaceData.FileName, args[2], "FileName missmatch!");
            race.ProcessDelete();
            const int fileSize = 24683;
            Assert.AreEqual((UInt64)fileSize * 4, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(4, race.TotalFilesUploaded, "TotalFilesUploaded");
        }
    }
}