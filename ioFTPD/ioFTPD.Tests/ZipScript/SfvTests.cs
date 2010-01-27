#region
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ioFTPD.Framework;
using MbUnit.Framework;
using FileInfo=System.IO.FileInfo;

#endregion

namespace ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class SfvTests : ZipScriptBase
    {
        /// <summary>
        /// Uploads the SFV File and check if all missing files are created.
        /// </summary>
        [Test]
        public void UploadSfv ()
        {
            PrepareCleanRarRace ();
            UploadSfvFile ();

            string expectedFile = String.Format (CultureInfo.InvariantCulture,
                                                 @"..\..\TestFiles\Rar\infected.part1.rar{0}",
                                                 Config.FileExtensionMissing);
            Assert.IsTrue (File.Exists (expectedFile), expectedFile);
            expectedFile = String.Format (CultureInfo.InvariantCulture,
                                          @"..\..\TestFiles\Rar\infected.part2.rar{0}",
                                          Config.FileExtensionMissing);
            Assert.IsTrue (File.Exists (expectedFile), expectedFile);
            expectedFile = String.Format (CultureInfo.InvariantCulture,
                                          @"..\..\TestFiles\Rar\infected.part3.rar{0}",
                                          Config.FileExtensionMissing);
            Assert.IsTrue (File.Exists (expectedFile), expectedFile);
            expectedFile = String.Format (CultureInfo.InvariantCulture,
                                          @"..\..\TestFiles\Rar\infected.part4.rar{0}",
                                          Config.FileExtensionMissing);
            Assert.IsTrue (File.Exists (expectedFile), expectedFile);
        }

        /// <summary>
        /// Uploads SFV file, create missing files, check that file with RACE data was created.
        /// </summary>
        [Test]
        public void RaceSfv ()
        {
            Race race = UploadSfvFile ();
            FileInfo fileInfo = new FileInfo (Path.Combine (race.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.OpenOrCreate,
                                                       FileAccess.ReadWrite,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader (stream))
                {
                    stream.Seek (0, SeekOrigin.Begin);
                    Assert.AreEqual (4, reader.ReadInt32 (), "Expected integer value (4)");
                    stream.Seek (256 * 3, SeekOrigin.Begin);
                    Assert.AreEqual ("infected.part3.rar", reader.ReadString (), "infected.part3.rar");
                }
            }
        }

        /// <summary>
        /// Parse SFV file.
        /// </summary>
        [Test]
        public void SfvData ()
        {
            const string fileName = @"..\..\TestFiles\Rar\infected.sfv";
            Framework.FileInfo fileInfo = new Framework.FileInfo ();
            fileInfo.ParseSfv (fileName);
            Dictionary<string, string> sfvData = fileInfo.SfvData;
            Assert.IsNotNull (sfvData, "sfvData");
            Assert.AreEqual (4, sfvData.Count, "sfvData.Count");
            Dictionary<string, string> expectedSfvData = new Dictionary<string, string>
                {
                    {"infected.part1.rar", "2e04944c"},
                    {"infected.part2.rar", "1c7c24a5"},
                    {"infected.part3.rar", "d5d617e3"},
                    {"infected.part4.rar", "0edb20ea"}
                };
            Assert.AreEqual (expectedSfvData, sfvData);
        }
    }
}