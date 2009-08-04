#region

using System.Collections.Generic;
using System.IO;
using ioFTPD.Framework;
using ioFTPD.ZipScript;
using MbUnit.Framework;
using FileInfo=ioFTPD.Framework.FileInfo;

#endregion

namespace ioFTPD.Tests
{
    [TestFixture]
    public class ZipScriptTests
    {
        /// <summary>
        /// Uploads the SFV File and check if all missing files are created.
        /// </summary>
        [Test]
        public void UploadSfv()
        {
            FileInfo fileInfo = new FileInfo();
            fileInfo.DeleteFiles(@"..\..\TestFiles\Rar", Config.FileExtensionMissing);
            Assert.IsFalse(File.Exists(@"..\..\TestFiles\Rar\infected.part1.rar" + Config.FileExtensionMissing));

            ConsoleApp consoleApp = new ConsoleApp(argsSfv);
            consoleApp.Parse();
            Assert.IsTrue(consoleApp.Process());

            Assert.IsTrue(File.Exists(@"..\..\TestFiles\Rar\infected.part1.rar" + Config.FileExtensionMissing));
            Assert.IsTrue(File.Exists(@"..\..\TestFiles\Rar\infected.part2.rar" + Config.FileExtensionMissing));
            Assert.IsTrue(File.Exists(@"..\..\TestFiles\Rar\infected.part3.rar" + Config.FileExtensionMissing));
            Assert.IsTrue(File.Exists(@"..\..\TestFiles\Rar\infected.part4.rar" + Config.FileExtensionMissing));
            fileInfo.DeleteFiles(@"..\..\TestFiles\Rar", Config.FileExtensionMissing);
        }

        /// <summary>
        /// Uploads the first file. Delete file with missing extension, update RACE file.
        /// </summary>
        [Test]
        public void RaceRar()
        {
            Race race = new Race(argsRar);
            race.Parse();
            race.Process();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(Path.Combine(race.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                      FileMode.Open,
                                                      FileAccess.Read,
                                                      FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(4, reader.ReadInt32());
                    stream.Seek(256*1, SeekOrigin.Begin);
                    Assert.AreEqual("infected.part1.rar", reader.ReadString());
                    Assert.AreEqual("2e04944c", reader.ReadString());
                    Assert.AreEqual(true, reader.ReadBoolean());
                }
            }
        }

        /// <summary>
        /// Uploads SFV file, create missing files, check that file with RACE data was created.
        /// </summary>
        [Test]
        public void RaceSfv()
        {
            Race race = new Race(argsSfv);
            race.Parse();
            Assert.AreEqual(".sfv", race.FileExtension, "FileExtension");
            Assert.AreEqual("infected.sfv", race.FileName, "FileName");
            Assert.AreEqual(432, race.FileSize, "FileSize");
            Assert.AreEqual("Rar", race.DirectoryName, "DirectoryName");
            race.Process();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(Path.Combine(race.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                      FileMode.OpenOrCreate,
                                                      FileAccess.ReadWrite,
                                                      FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(4, reader.ReadInt32());
                    stream.Seek(256*3, SeekOrigin.Begin);
                    Assert.AreEqual("infected.part3.rar", reader.ReadString());
                }
            }
        }

        /// <summary>
        /// Parse SFV file.
        /// </summary>
        [Test]
        public void SfvData()
        {
            const string fileName = @"..\..\TestFiles\Rar\infected.sfv";
            FileInfo fileInfo = new FileInfo();
            fileInfo.ParseSfv(fileName);
            Dictionary<string, string> sfvData = fileInfo.SfvData;
            Assert.IsNotNull(sfvData);
            Assert.AreEqual(4, sfvData.Count);
            Dictionary<string, string> expectedSfvData = new Dictionary<string, string>
                                                         {
                                                             {"infected.part1.rar", "2e04944c"},
                                                             {"infected.part2.rar", "1c7c24a5"},
                                                             {"infected.part3.rar", "d5d617e3"},
                                                             {"infected.part4.rar", "0edb20ea"}
                                                         };
            Assert.AreEqual(expectedSfvData, sfvData);
        }

        private readonly string[] argsRar = new[]
                                            {
                                                "upload"
                                                , @"..\..\TestFiles\Rar\infected.part1.rar"
                                                , "2e04944c"
                                                , "/TestFiles/Rar/infected.part1.rar"
                                            };

        private readonly string[] argsSfv = new[]
                                            {
                                                "upload"
                                                , @"..\..\TestFiles\Rar\infected.sfv"
                                                , "aabbccdd"
                                                , "/TestFiles/Rar/infected.sfv"
                                            };
    }
}