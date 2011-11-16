using System;
using System.IO;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;
using FileInfo = System.IO.FileInfo;

namespace jeza.ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class ZipTests : ZipScriptBase
    {
        /// <summary>
        /// Refuse file because of its extension.
        /// </summary>
        [Test]
        public void RefuseExtension()
        {
            CleanTestFilesOutput();
            Race race = new Race(ArgsBat);
            race.ParseUpload();
            Assert.AreEqual(".bat", race.CurrentRaceData.FileExtension, "FileExtension");
            Assert.AreEqual("file_bat.bat", race.CurrentRaceData.FileName, "FileName");
            Assert.AreEqual("Zip", race.CurrentRaceData.DirectoryName, "DirectoryName");
            race.Process();
            Assert.IsFalse(race.IsValid);
        }

        /// <summary>
        /// DIZ file can't be uploaded.
        /// </summary>
        [Test]
        public void UploadDiz()
        {
            CleanTestFilesOutput();
            Race race = UploadDizFile();
            Assert.IsFalse(race.IsValid);
        }

        /// <summary>
        /// When ZIP file contains no DIZ, race is not valid.
        /// </summary>
        [Test]
        public void ZipRaceNoDiz()
        {
            CleanTestFilesOutput();

            Race race = new Race(ArgsZipFile1);
            race.ParseUpload();
            race.Process();
            Assert.IsFalse(race.IsValid);
        }

        /// <summary>
        /// Uploads some ZIP files and simulates race.
        /// </summary>
        [Test]
        public void ZipRace()
        {
            CleanTestFilesOutput();

            Race race = new Race(ArgsCorrectZipFile1);
            race.ParseUpload();
            race.Process();
            Assert.IsTrue(race.IsValid);
            FileInfo fileInfo = new FileInfo(Path.Combine(race.CurrentRaceData.DirectoryPath, Config.FileNameRace));
            const int fileSize = 24683;
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(5, reader.ReadInt32(), "Total files count");
                    stream.Seek(256 * 5, SeekOrigin.Begin);
                    Assert.AreEqual("file-000.zip", reader.ReadString(), "FileName");
                    Assert.AreEqual("00000000", reader.ReadString(), "CRC32");
                    Assert.AreEqual(true, reader.ReadBoolean(), "File was uploaded");
                    Assert.AreEqual((UInt64)fileSize, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)fileSize, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(1, race.TotalFilesUploaded, "TotalFilesUploaded");

            race = new Race(ArgsCorrectZipFile2);
            race.ParseUpload();
            race.Process();
            fileInfo = new FileInfo(Path.Combine(race.CurrentRaceData.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(5, reader.ReadInt32(), "Total files count");
                    stream.Seek(256 * 4, SeekOrigin.Begin);
                    Assert.AreEqual("file-001.zip", reader.ReadString(), "FileName");
                    Assert.AreEqual("00000000", reader.ReadString(), "CRC32");
                    Assert.AreEqual(true, reader.ReadBoolean(), "File was uploaded");
                    Assert.AreEqual((UInt64)fileSize, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)fileSize * 2, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(2, race.TotalFilesUploaded, "TotalFilesUploaded");

            race = new Race(ArgsCorrectZipFile3);
            race.ParseUpload();
            race.Process();
            fileInfo = new FileInfo(Path.Combine(race.CurrentRaceData.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(5, reader.ReadInt32(), "Total files count");
                    stream.Seek(256 * 3, SeekOrigin.Begin);
                    Assert.AreEqual("file-002.zip", reader.ReadString(), "FileName");
                    Assert.AreEqual("00000000", reader.ReadString(), "CRC32");
                    Assert.AreEqual(true, reader.ReadBoolean(), "File was uploaded");
                    Assert.AreEqual((UInt64)fileSize, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)fileSize * 3, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(3, race.TotalFilesUploaded, "TotalFilesUploaded");

            race = new Race(ArgsCorrectZipFile4);
            race.ParseUpload();
            race.Process();
            fileInfo = new FileInfo(Path.Combine(race.CurrentRaceData.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(5, reader.ReadInt32(), "Total files count");
                    stream.Seek(256 * 2, SeekOrigin.Begin);
                    Assert.AreEqual("file-003.zip", reader.ReadString(), "FileName");
                    Assert.AreEqual("00000000", reader.ReadString(), "CRC32");
                    Assert.AreEqual(true, reader.ReadBoolean(), "File was uploaded");
                    Assert.AreEqual((UInt64)fileSize, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)fileSize * 4, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(4, race.TotalFilesUploaded, "TotalFilesUploaded");

            race = new Race(ArgsCorrectZipFile5);
            race.ParseUpload();
            race.Process();
            fileInfo = new FileInfo(Path.Combine(race.CurrentRaceData.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(5, reader.ReadInt32(), "Total files count");
                    stream.Seek(256 * 1, SeekOrigin.Begin);
                    Assert.AreEqual("file-004.zip", reader.ReadString(), "FileName");
                    Assert.AreEqual("00000000", reader.ReadString(), "CRC32");
                    Assert.AreEqual(true, reader.ReadBoolean(), "File was uploaded");
                    Assert.AreEqual((UInt64)fileSize, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)fileSize * 5, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(5, race.TotalFilesUploaded, "TotalFilesUploaded");
        }
    }
}
