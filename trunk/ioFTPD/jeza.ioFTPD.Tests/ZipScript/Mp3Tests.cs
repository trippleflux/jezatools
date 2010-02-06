using System;
using System.IO;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;
using FileInfo=System.IO.FileInfo;

namespace jeza.ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class Mp3Tests : ZipScriptBase
    {
        [Test]
        public void Race()
        {
            PrepareCleanMp3Race();
            UploadSfvFileMp3();
            Race race = new Race(ArgsMp3File1);
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
                    Assert.AreEqual(4, reader.ReadInt32(), "Total files count");
                    stream.Seek(256 * 1, SeekOrigin.Begin);
                    Assert.AreEqual("01-jozek.Pepek-2009-asd-Ind.mp3", reader.ReadString(), "FileName");
                    Assert.AreEqual("2e04944c", reader.ReadString(), "CRC32");
                    Assert.AreEqual(true, reader.ReadBoolean(), "File was uploaded");
                    Assert.AreEqual((UInt64)5000, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)5000, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(4, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(1, race.TotalFilesUploaded, "TotalFilesUploaded");
        }
    }
}