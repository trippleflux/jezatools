#region
using System;
using System.Text;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;
using TagLib;

#endregion

namespace jeza.ioFTPD.Tests
{
    [TestFixture]
    public class OutputTests
    {
        [Test]
        public void Log()
        {
            Framework.Log.Debug("test line");
            Framework.Log.Debug("test linewith arguments {0} {1}", 1, 2);
        }

        [Test]
        public void Client()
        {
            Race race = new Race(new[] {"asdfasdf"}) {TotalFilesExpected = 5};
            Output output = new Output(race);
            Assert.AreEqual("=[   0/5   ]=", output.Format("=[   0/{5,-3:B3} ]="));
            Assert.AreEqual("=[   0/asd ]=", output.Format("=[   0/asd ]="));
            RaceStats raceStats = new RaceStats();
            const ulong bytes = 123456789;
            raceStats
                .AddFileName("a.txt")
                .AddCrc32("aabbccdd")
                .AddFileUploaded(true)
                .AddFileSpeed(100)
                .AddFileSize(bytes)
                .AddUserName("user1")
                .AddGroupName("group1");
            race.AddRaceStats(raceStats);
            Assert.AreEqual("]-[Complete 123456789MB - 1/5F]-[", output.Format("]-[Complete {7}MB - {6}/{5}F]-["));
            Assert.AreEqual("]-[Complete 117MB - 1/5F]-[", output.Format("]-[Complete {8}MB - {6}/{5}F]-["));
            Assert.AreEqual("|  1.           user1/group1           117MB   100kBit/s   1F |",
                            output.FormatUserStats(1,
                                                   race.GetUserStats() [0],
                                                   "| {0,2:B2}. {2,15:B15}/{3,-15:B15} {8,6:B6} {6,5:B5}kBit/s {7,3:B3}F |"));
            Assert.AreEqual("|  1. group1           117MB   100kBit/s   1F |",
                            output.FormatGroupStats(1,
                                                    race.GetGroupStats() [0],
                                                    "| {0,2:B2}. {3,-15:B15} {7,6:B6} {5,5:B5}kBit/s {6,3:B3}F |"));
            Assert.AreEqual("###--------------", output.Format("{14}"), "ProgressBar");
            Assert.AreEqual("117MB", bytes.FormatSize(), "FormatBytesUploaded");
        }

        [Test]
        public void Format()
        {
            Race race = new Race(new[] {"upload", @"..\..\TestFiles\Mp3\06-judas_priest-beyond_the_realms_of_death.mp3", "00000000", @"../../TestFiles/Mp3/06-judas_priest-beyond_the_realms_of_death.mp3"});
            race.ParseUpload();
            const int totalFilesExpected = 123;
            race.TotalFilesExpected = totalFilesExpected;
            bool isAudioRace = race.IsAudioRace;
            Assert.IsTrue(isAudioRace);
            Output output = new Output(race);
            File file = File.Create(@"..\..\TestFiles\Mp3\06-judas_priest-beyond_the_realms_of_death.mp3");
            Assert.AreEqual("06-judas_priest-beyond_the_realms_of_death.mp3", output.Format("{0}", file), "FileName");
            Assert.AreEqual("Mp3", output.Format("{1}", file), "DirectoryName");
            Assert.AreEqual("NoUser", output.Format("{2}", file), "UserName");
            Assert.AreEqual("NoGroup", output.Format("{3}", file), "GroupName");
            Assert.AreEqual("/NoPath", output.Format("{4}", file), "UploadVirtualPath");
            Assert.AreEqual(totalFilesExpected.ToString(), output.Format("{5}", file), "TotalFilesExpected");
            Assert.AreEqual("0", output.Format("{6}", file), "TotalFilesUploaded");
            Assert.AreEqual("0", output.Format("{7}", file), "TotalBytesUploaded");
            Assert.AreEqual("0", output.Format("{8}", file), "TotalMegaBytesUploaded");
            Assert.AreEqual("0B", output.Format("{9}", file), "TotalBytesUploadedFormated");
            Assert.AreEqual("0B", output.Format("{10}", file), "TotalBytesExpected");
            Assert.AreEqual("1", output.Format("{11}", file), "TotalAvarageSpeed");
            Assert.AreEqual("0", output.Format("{12}", file), "TotalUsersRacing");
            Assert.AreEqual("0", output.Format("{13}", file), "TotalGroupsRacing");
            Assert.AreEqual("-----------------", output.Format("{14}", file), "ProgressBar");
            Assert.AreEqual("0%", output.Format("{15}%", file), "PercentComplete");
            Assert.AreEqual(Constants.CodeIrcColor, output.Format("{16}", file), "CodeIrcColor");
            Assert.AreEqual(Constants.CodeIrcBold, output.Format("{17}", file), "CodeIrcBold");
            Assert.AreEqual(Constants.CodeIrcUnderline, output.Format("{18}", file), "CodeIrcUnderline");
            Assert.AreEqual(Constants.CodeNewLine, output.Format("{19}", file), "codeNewLine");
            Assert.AreEqual("Judas Priest", output.Format("{20}", file), "FirstPerformer");
            Assert.AreEqual("A Touch of Evil Live", output.Format("{21}", file), "Album");
            Assert.AreEqual("Beyond the Realms of Death", output.Format("{22}", file), "Title");
            Assert.AreEqual("Heavy Metal", output.Format("{23}", file), "FirstGenre");
            Assert.AreEqual("2009", output.Format("{24}", file), "Year");
            Assert.AreEqual("6", output.Format("{25}", file), "Track");
            Assert.AreEqual("1", output.Format("{26}", file), "Speed");
            Assert.AreEqual("231", output.Format("{27}", file), "AudioBitrate");
            Assert.AreEqual("2", output.Format("{28}", file), "AudioChannels");
            Assert.AreEqual("44100", output.Format("{29}", file), "AudioSampleRate");
            Assert.AreEqual("0", output.Format("{30}", file), "BitsPerSample");
            Assert.AreEqual("MPEG Version 1 Audio, Layer 3 VBR", output.Format("{31}", file), "Description");
            Assert.AreEqual("Audio", output.Format("{32}", file), "MediaTypes");
            Assert.AreEqual("MPEG Version 1 Audio, Layer 3 VBR", output.Format("{33}", file), "Codecs");
            Assert.AreEqual("00:06:51", output.Format("{34}", file), "Duration");
        }

        [Test]
        public void FormatTimeSpan()
        {
            TimeSpan timeSpan = new TimeSpan(0, 1, 2, 3, 4);
            Assert.AreEqual("01:02:03", timeSpan.FormatTimeSpan());
            timeSpan = new TimeSpan(9, 8, 7, 6, 5);
            Assert.AreEqual("08:07:06", timeSpan.FormatTimeSpan());
            timeSpan = new TimeSpan(19, 18, 17, 16, 15);
            Assert.AreEqual("18:17:16", timeSpan.FormatTimeSpan());
        }

        [Test]
        public void FormatSize()
        {
            ulong size = 999;
            Assert.AreEqual("999B", size.FormatSize());
            size = 999888;
            Assert.AreEqual("976kB", size.FormatSize());
            size = 999888777;
            Assert.AreEqual("953MB", size.FormatSize());
            size = 999888777666;
            Assert.AreEqual("931GB", size.FormatSize());
            size = 999888777666555;
            Assert.AreEqual("909TB", size.FormatSize());
            size = 999888777666555444;
            Assert.AreEqual("888PB", size.FormatSize());
        }
    }
}