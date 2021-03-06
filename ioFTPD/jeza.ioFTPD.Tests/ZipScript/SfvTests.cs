﻿#region
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using jeza.ioFTPD.Framework;
using NUnit.Framework;
using FileInfo=System.IO.FileInfo;

#endregion

namespace jeza.ioFTPD.Tests.ZipScript
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
            CleanTestFilesOutput ();
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
            CleanTestFilesOutput();
            Race race = UploadSfvFile ();
            FileInfo fileInfo = new FileInfo (Misc.PathCombine (race.CurrentRaceData.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.OpenOrCreate,
                                                       FileAccess.ReadWrite,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader (stream))
                {
                    stream.Seek (0, SeekOrigin.Begin);
                    Assert.AreEqual (4, reader.ReadInt32 (), "Expected integer value (4)");
                    stream.Seek(256 * 1, SeekOrigin.Begin);
                    Assert.AreEqual("infected.part1.rar", reader.ReadString(), "infected.part1.rar");
                    Assert.AreEqual("2e04944c", reader.ReadString(), "2e04944c");
                    Assert.AreEqual(false, reader.ReadBoolean(), "FileUploaded");
                    stream.Seek(256 * 2, SeekOrigin.Begin);
                    Assert.AreEqual("infected.part2.rar", reader.ReadString(), "infected.part2.rar");
                    Assert.AreEqual("1c7c24a5", reader.ReadString(), "1c7c24a5");
                    Assert.AreEqual(false, reader.ReadBoolean(), "FileUploaded");
                    stream.Seek(256 * 3, SeekOrigin.Begin);
                    Assert.AreEqual("infected.part3.rar", reader.ReadString(), "infected.part3.rar");
                    Assert.AreEqual("d5d617e3", reader.ReadString(), "d5d617e3");
                    Assert.AreEqual(false, reader.ReadBoolean(), "FileUploaded");
                    stream.Seek(256 * 4, SeekOrigin.Begin);
                    Assert.AreEqual("infected.part4.rar", reader.ReadString(), "infected.part4.rar");
                    Assert.AreEqual("0edb20ea", reader.ReadString(), "0edb20ea");
                    Assert.AreEqual(false, reader.ReadBoolean(), "FileUploaded");
                }
            }
        }

        /// <summary>
        /// Parse SFV file.
        /// </summary>
        [Test]
        public void SfvData ()
        {
            Race race = new Race (ArgsSfv);
            race.ParseUpload ();
            DataParserSfv sfvParser = new DataParserSfv (race);
            sfvParser.Parse ();
            sfvParser.Process ();
            Assert.AreEqual (4, race.TotalFilesExpected, "TotalFilesExpected");
            Dictionary<string, string> sfvData = sfvParser.SfvData;
            Assert.IsNotNull (sfvData, "sfvData");
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