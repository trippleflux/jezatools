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
        protected readonly string[] ArgsMp3File1 = new[]
            {
                "upload"
                , @"..\..\TestFiles\Mp3\01-jozek.Pepek-2009-asd-Ind.mp3"
                , "2e04944c"
                , "/TestFiles/Mp3/01-jozek.Pepek-2009-asd-Ind.mp3"
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

        protected void PrepareCleanRarRace()
        {
            FileInfo fileInfo = new FileInfo ();
            fileInfo.DeleteFiles (@"..\..\TestFiles\Rar", Config.FileExtensionMissing);
            fileInfo.DeleteFile (@"..\..\TestFiles\Rar", Config.FileNameRace);
            //Thread.Sleep (5000);
            Assert.IsFalse (File.Exists (@"..\..\TestFiles\Rar\infected.part1.rar" + Config.FileExtensionMissing),
                            String.Format (CultureInfo.InvariantCulture,
                                           "Unexpected '{0}' files!",
                                           Config.FileExtensionMissing));
        }

        protected void PrepareCleanMp3Race ()
        {
            FileInfo fileInfo = new FileInfo ();
            fileInfo.DeleteFiles (@"..\..\TestFiles\Mp3", Config.FileExtensionMissing);
            fileInfo.DeleteFile (@"..\..\TestFiles\Mp3", Config.FileNameRace);
            //Thread.Sleep (5000);
            Assert.IsFalse (
                File.Exists (@"..\..\TestFiles\Mp3\01-jozek.Pepek-2009-asd-Ind.mp3" + Config.FileExtensionMissing),
                String.Format (CultureInfo.InvariantCulture,
                               "Unexpected '{0}' files!",
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
    }
}