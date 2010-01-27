#region
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using ioFTPD.Framework;
using ioFTPD.ZipScript;
using MbUnit.Framework;
using FileInfo=ioFTPD.Framework.FileInfo;

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
            FileInfo fileInfo = new FileInfo ();
            fileInfo.DeleteFiles (@"..\..\TestFiles\Rar", Config.FileExtensionMissing);
            Thread.Sleep (5000);
            AssertIsFalse (
                File.Exists (@"..\..\TestFiles\Rar\infected.part1.rar" + Config.FileExtensionMissing),
                String.Format (CultureInfo.InvariantCulture, "Unexpected '{0}' files!", Config.FileExtensionMissing));

            ConsoleApp consoleApp = new ConsoleApp (ArgsSfv);
            consoleApp.Parse ();
            AssertIsTrue (consoleApp.Process (), "consoleApp.Process ()");

            string expectedFile = String.Format (CultureInfo.InvariantCulture,
                                                 @"..\..\TestFiles\Rar\infected.part1.rar{0}",
                                                 Config.FileExtensionMissing);
            AssertIsTrue (File.Exists (expectedFile), expectedFile);
            expectedFile = String.Format (CultureInfo.InvariantCulture,
                                          @"..\..\TestFiles\Rar\infected.part2.rar{0}",
                                          Config.FileExtensionMissing);
            AssertIsTrue (File.Exists (expectedFile), expectedFile);
            expectedFile = String.Format (CultureInfo.InvariantCulture,
                                          @"..\..\TestFiles\Rar\infected.part3.rar{0}",
                                          Config.FileExtensionMissing);
            AssertIsTrue (File.Exists (expectedFile), expectedFile);
            expectedFile = String.Format (CultureInfo.InvariantCulture,
                                          @"..\..\TestFiles\Rar\infected.part4.rar{0}",
                                          Config.FileExtensionMissing);
            AssertIsTrue (File.Exists (expectedFile), expectedFile);
            fileInfo.DeleteFiles (@"..\..\TestFiles\Rar", Config.FileExtensionMissing);
            Thread.Sleep(5000);
        }

        /// <summary>
        /// Uploads SFV file, create missing files, check that file with RACE data was created.
        /// </summary>
        [Test]
        public void RaceSfv ()
        {
            Race race = new Race (ArgsSfv);
            race.Parse ();
            AssertAreEqual (".sfv", race.FileExtension, "FileExtension");
            AssertAreEqual ("infected.sfv", race.FileName, "FileName");
            AssertAreEqual (432, race.FileSize, "FileSize");
            AssertAreEqual ("Rar", race.DirectoryName, "DirectoryName");
            race.Process ();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo (Path.Combine (race.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.OpenOrCreate,
                                                       FileAccess.ReadWrite,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader (stream))
                {
                    stream.Seek (0, SeekOrigin.Begin);
                    AssertAreEqual (4, reader.ReadInt32 (), "Expected integer value (4)");
                    stream.Seek (256 * 3, SeekOrigin.Begin);
                    AssertAreEqual ("infected.part3.rar", reader.ReadString (), "infected.part3.rar");
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
            FileInfo fileInfo = new FileInfo ();
            fileInfo.ParseSfv (fileName);
            Dictionary<string, string> sfvData = fileInfo.SfvData;
            AssertIsNotNull (sfvData, "sfvData");
            AssertAreEqual (4, sfvData.Count, "SFV count");
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