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
        [Test]
        public void UploadDiz()
        {
            CleanTestFilesOutput();
            Race race = UploadDizFile();

            FileInfo fileInfo = new FileInfo(Path.Combine(race.CurrentUploadData.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                      FileMode.Open,
                                                      FileAccess.Read,
                                                      FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(5, reader.ReadInt32(), "Total files count");
                }
            }
            Assert.AreEqual((UInt64)0, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(0, race.TotalFilesUploaded, "TotalFilesUploaded");
        }

        [Test]
        public void ZipRace()
        {
            CleanTestFilesOutput();
            UploadDizFile();

            Race race = new Race(ArgsZipFile1);
            race.Parse();
            race.Process();
            FileInfo fileInfo = new FileInfo(Path.Combine(race.CurrentUploadData.DirectoryPath, Config.FileNameRace));
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
                    Assert.AreEqual((UInt64)26567, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)26567, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(1, race.TotalFilesUploaded, "TotalFilesUploaded");

            race = new Race(ArgsZipFile2);
            race.Parse();
            race.Process();
            fileInfo = new FileInfo(Path.Combine(race.CurrentUploadData.DirectoryPath, Config.FileNameRace));
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
                    Assert.AreEqual((UInt64)26567, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)26567*2, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(2, race.TotalFilesUploaded, "TotalFilesUploaded");

            race = new Race(ArgsZipFile3);
            race.Parse();
            race.Process();
            fileInfo = new FileInfo(Path.Combine(race.CurrentUploadData.DirectoryPath, Config.FileNameRace));
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
                    Assert.AreEqual((UInt64)26567, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)26567 * 3, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(3, race.TotalFilesUploaded, "TotalFilesUploaded");

            race = new Race(ArgsZipFile4);
            race.Parse();
            race.Process();
            fileInfo = new FileInfo(Path.Combine(race.CurrentUploadData.DirectoryPath, Config.FileNameRace));
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
                    Assert.AreEqual((UInt64)26567, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)26567 * 4, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(4, race.TotalFilesUploaded, "TotalFilesUploaded");

            race = new Race(ArgsZipFile5);
            race.Parse();
            race.Process();
            fileInfo = new FileInfo(Path.Combine(race.CurrentUploadData.DirectoryPath, Config.FileNameRace));
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
                    Assert.AreEqual((UInt64)26567, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)26567 * 5, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(5, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(5, race.TotalFilesUploaded, "TotalFilesUploaded");
        }
    }
}
