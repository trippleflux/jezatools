#region
using System;
using System.Globalization;
using System.IO;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;
using FileInfo=jeza.ioFTPD.Framework.FileInfo;

#endregion

namespace jeza.ioFTPD.Tests.ZipScript
{
    public class ZipScriptBase
    {
        protected readonly string[] ArgsCorrectZipFile1 = new[]
            {
                "upload"
                , @"..\..\TestFiles\ZipCorrect\file-000.zip"
                , "00000000"
                , "/TestFiles/ZipCorrect/file-000.zip"
            };

        protected readonly string[] ArgsCorrectZipFile2 = new[]
            {
                "upload"
                , @"..\..\TestFiles\ZipCorrect\file-001.zip"
                , "00000000"
                , "/TestFiles/ZipCorrect/file-001.zip"
            };

        protected readonly string[] ArgsCorrectZipFile3 = new[]
            {
                "upload"
                , @"..\..\TestFiles\ZipCorrect\file-002.zip"
                , "00000000"
                , "/TestFiles/ZipCorrect/file-002.zip"
            };

        protected readonly string[] ArgsCorrectZipFile4 = new[]
            {
                "upload"
                , @"..\..\TestFiles\ZipCorrect\file-003.zip"
                , "00000000"
                , "/TestFiles/ZipCorrect/file-003.zip"
            };

        protected readonly string[] ArgsCorrectZipFile5 = new[]
            {
                "upload"
                , @"..\..\TestFiles\ZipCorrect\file-004.zip"
                , "00000000"
                , "/TestFiles/ZipCorrect/file-004.zip"
            };

        protected readonly string[] ArgsZipFile1 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Zip\file-000.zip"
                , "00000000"
                , "/TestFiles/Zip/file-000.zip"
            };

        protected readonly string[] ArgsZipFile2 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Zip\file-001.zip"
                , "00000000"
                , "/TestFiles/Zip/file-001.zip"
            };

        protected readonly string[] ArgsZipFile3 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Zip\file-002.zip"
                , "00000000"
                , "/TestFiles/Zip/file-002.zip"
            };

        protected readonly string[] ArgsZipFile4 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Zip\file-003.zip"
                , "00000000"
                , "/TestFiles/Zip/file-003.zip"
            };

        protected readonly string[] ArgsZipFile5 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Zip\file-004.zip"
                , "00000000"
                , "/TestFiles/Zip/file-004.zip"
            };

        protected readonly string[] ArgsMp3File1 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Mp3\01-jozek.Pepek-2009-asd-Ind.mp3"
                , "2e04944c"
                , "/TestFiles/Mp3/01-jozek.Pepek-2009-asd-Ind.mp3"
            };

        protected readonly string[] ArgsMp3File2 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Mp3\02-jozek.Pepek-2009-asd-Ind.mp3"
                , "1c7c24a5"
                , "/TestFiles/Mp3/02-jozek.Pepek-2009-asd-Ind.mp3"
            };

        protected readonly string[] ArgsMp3File3 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Mp3\03-jozek.Pepek-2009-asd-Ind(2).mp3"
                , "d5d617e3"
                , "/TestFiles/Mp3/03-jozek.Pepek-2009-asd-Ind(2).mp3"
            };

        protected readonly string[] ArgsMp3File4 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Mp3\04-jozek.Pepek-2009-asd-Ind(3).mp3"
                , "0edb20ea"
                , "/TestFiles/Mp3/04-jozek.Pepek-2009-asd-Ind(3).mp3"
            };

        protected readonly string[] ArgsRarPart1 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Rar\infected.part1.rar"
                , "2e04944c"
                , "/TestFiles/Rar/infected.part1.rar"
            };

        protected readonly string[] ArgsRarPart2 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Rar\infected.part2.rar"
                , "1c7c24a5"
                , "/TestFiles/Rar/infected.part2.rar"
            };

        protected readonly string[] ArgsRarPart3 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Rar\infected.part3.rar"
                , "d5d617e3"
                , "/TestFiles/Rar/infected.part3.rar"
            };

        protected readonly string[] ArgsRarPart4 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Rar\infected.part4.rar"
                , "0edb20ea"
                , "/TestFiles/Rar/infected.part4.rar"
            };

        protected readonly string[] ArgsSfv = new[]
            {
                "upload"
                , @"..\..\TestFiles\Rar\infected.sfv"
                , "aabbccdd"
                , "/TestFiles/Rar/infected.sfv"
            };

        protected readonly string[] ArgsSfvMp3 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Mp3\jozek.Pepek-2009-asd-Ind.sfv"
                , "aabbccdd"
                , "/TestFiles/Mp3/jozek.Pepek-2009-asd-Ind.sfv"
            };

        protected readonly string[] ArgsDiz = new[]
            {
                "upload"
                , @"..\..\TestFiles\Zip\file_id.diz"
                , "aabbccdd"
                , "/TestFiles/Zip/file_id.diz"
            };

        protected void CleanTestFilesOutput()
        {
            FileInfo fileInfoRar = new FileInfo ();
            fileInfoRar.DeleteFiles (@"..\..\TestFiles\Rar", Config.FileExtensionMissing);
            fileInfoRar.DeleteFile (@"..\..\TestFiles\Rar", Config.FileNameRace);
            //Thread.Sleep (5000);
            Assert.IsFalse (File.Exists (@"..\..\TestFiles\Rar\infected.part1.rar" + Config.FileExtensionMissing),
                            String.Format (CultureInfo.InvariantCulture,
                                           "Unexpected '{0}' files in RAR folder!",
                                           Config.FileExtensionMissing));

            FileInfo fileInfoMp3 = new FileInfo ();
            fileInfoMp3.DeleteFiles (@"..\..\TestFiles\Mp3", Config.FileExtensionMissing);
            fileInfoMp3.DeleteFile (@"..\..\TestFiles\Mp3", Config.FileNameRace);
            //Thread.Sleep (5000);
            Assert.IsFalse (
                File.Exists (@"..\..\TestFiles\Mp3\01-jozek.Pepek-2009-asd-Ind.mp3" + Config.FileExtensionMissing),
                String.Format (CultureInfo.InvariantCulture,
                               "Unexpected '{0}' files in MP3 folder!",
                               Config.FileExtensionMissing));

            FileInfo fileInfoZip = new FileInfo();
            fileInfoZip.DeleteFiles(@"..\..\TestFiles\Zip", Config.FileExtensionMissing);
            fileInfoZip.DeleteFile(@"..\..\TestFiles\Zip", Config.FileNameRace);
            //Thread.Sleep (5000);
            Assert.IsFalse(
                File.Exists(@"..\..\TestFiles\Zip\file-004.zip" + Config.FileExtensionMissing),
                String.Format(CultureInfo.InvariantCulture,
                               "Unexpected '{0}' files in ZIP folder!",
                               Config.FileExtensionMissing));

            FileInfo fileInfoZipCorrect = new FileInfo();
            fileInfoZipCorrect.DeleteFiles(@"..\..\TestFiles\ZipCorrect", Config.FileExtensionMissing);
            fileInfoZipCorrect.DeleteFile(@"..\..\TestFiles\ZipCorrect", Config.FileNameRace);
            //Thread.Sleep (5000);
            Assert.IsFalse(
                File.Exists(@"..\..\TestFiles\ZipCorrect\file-004.zip" + Config.FileExtensionMissing),
                String.Format(CultureInfo.InvariantCulture,
                               "Unexpected '{0}' files in ZIP folder!",
                               Config.FileExtensionMissing));
        }

        protected Race UploadSfvFile ()
        {
            Race race = new Race (ArgsSfv);
            race.Parse ();
            Assert.AreEqual (".sfv", race.CurrentUploadData.FileExtension, "FileExtension");
            Assert.AreEqual ("infected.sfv", race.CurrentUploadData.FileName, "FileName");
            Assert.AreEqual (432, race.CurrentUploadData.FileSize, "FileSize");
            Assert.AreEqual ("Rar", race.CurrentUploadData.DirectoryName, "DirectoryName");
            race.Process ();
            return race;
        }

        protected Race UploadSfvFileMp3()
        {
            Race race = new Race(ArgsSfvMp3);
            race.Parse();
            Assert.AreEqual(".sfv", race.CurrentUploadData.FileExtension, "FileExtension");
            Assert.AreEqual("jozek.Pepek-2009-asd-Ind.sfv", race.CurrentUploadData.FileName, "FileName");
            //Assert.AreEqual(554, race.CurrentUploadData.FileSize, "FileSize");
            Assert.AreEqual("Mp3", race.CurrentUploadData.DirectoryName, "DirectoryName");
            race.Process();
            return race;
        }

        protected Race UploadDizFile()
        {
            Race race = new Race(ArgsDiz);
            race.Parse();
            Assert.AreEqual(".diz", race.CurrentUploadData.FileExtension, "FileExtension");
            Assert.AreEqual("file_id.diz", race.CurrentUploadData.FileName, "FileName");
            Assert.AreEqual(350, race.CurrentUploadData.FileSize, "FileSize");
            Assert.AreEqual("Zip", race.CurrentUploadData.DirectoryName, "DirectoryName");
            race.Process();
            return race;
        }

    }
}