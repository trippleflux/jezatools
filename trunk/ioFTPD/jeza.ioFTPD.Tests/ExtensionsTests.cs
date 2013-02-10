using System;
using System.Collections.Generic;
using NUnit.Framework;
using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Framework.Manager;

namespace jeza.ioFTPD.Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        public void IsMatch()
        {
            string input = "mp3,flac";
            string extension = ".mp3";
            Assert.IsTrue(input.StringContainsFileExt(extension));
            input = "mp3,flac";
            extension = "mp3";
            Assert.IsTrue(input.StringContainsFileExt(extension));
            input = "mp3";
            extension = ".zip";
            Assert.IsFalse(input.StringContainsFileExt(extension));
        }

        [Test]
        [Ignore]
        public void GetImdbResponseForEventId()
        {
            Dictionary<string, object> imdbResponseForEventId = Extensions.GetImdbResponseForEventId("tt0088247");
            string formatImdb = new Output(new Race(new[] { "upload" })).FormatImdb(Config.LogLineIoFtpdUpdateImdb, imdbResponseForEventId);
            const string expectedValue = "IMDBJEZA: \"\" \"\" \"\" \"\" \"The Terminator\" \"1984\" \"R\" \"26 Oct 1984\" \"Action, Sci-Fi\" \"James Cameron\" \"James Cameron, Gale Anne Hurd\" \"Arnold Schwarzenegger, Linda Hamilton, Michael Biehn, Paul Winfield\" \"A cyborg is sent back in time by the sinister computer network Skynet to murder a woman who will one day give birth to the leader of the militia destined to end the coming robo-apocalypse.\" \"http://ia.media-imdb.com/images/M/MV5BODE1MDczNTUxOV5BMl5BanBnXkFtZTcwMTA0NDQyNA@@._V1_SX300.jpg\" \"1 h 47 min\" \"\" \"\" \"\"";
            Assert.AreEqual(expectedValue, formatImdb, "Maybe imdb response was changed???");
        }

        [Test]
        public void NextDate()
        {
            DateTime dateTime = new DateTime(2011, 1, 1);
            DateTime nextDay = dateTime.AddNextDate();
            Assert.AreEqual(dateTime.AddDays(1), nextDay);
            Assert.AreEqual(2, nextDay.Day);
            dateTime = new DateTime(2011, 1, 2);
            DateTime nextWeek = dateTime.AddNextDate();
            Assert.AreEqual(dateTime.AddDays(1), nextWeek);
            dateTime = new DateTime(2011, 1, 2);
            DateTime nextMonth = dateTime.AddNextDate();
            Assert.AreEqual(dateTime.AddDays(1), nextMonth);
        }

        [Test]
        public void FolderFormat()
        {
            DateTime dateTime = new DateTime(2011, 1, 1).AddNextDate();
            string folderName = dateTime.GetNewDayFolderFormat(new NewDayTask {CultureInfo = "en-US", FolderFormat = "{2:00}{0:00}"});
            Assert.AreEqual("0102", folderName, "DAY: 2011-01-01 : 2011-01-02");

            dateTime = new DateTime(2011, 11, 28).AddNextDate();
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask {CultureInfo = "en-US", FolderFormat = "{2:00}{0:00}"});
            Assert.AreEqual("1129", folderName, "DAY: 2011-11-28 : 2011-11-29");

            dateTime = new DateTime(2011, 11, 28).AddNextDate();
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask {CultureInfo = "en-US", FolderFormat = "{2:00}{1:00}", FirstDayOfWeek = DayOfWeek.Sunday});
            Assert.AreEqual("1149", folderName, "WEEK: 2011-11-28 : WEEK 49");

            dateTime = new DateTime(2011, 1, 1).AddNextDate();
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask {CultureInfo = "en-US", FolderFormat = "Week_{1:00}", FirstDayOfWeek = DayOfWeek.Monday});
            Assert.AreEqual("Week_01", folderName, "WEEK: 2011-01-01 : WEEK 01 (Monday)");

            dateTime = new DateTime(2011, 1, 2).AddNextDate();
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask {CultureInfo = "en-US", FolderFormat = "Week_{1:00}", FirstDayOfWeek = DayOfWeek.Sunday});
            Assert.AreEqual("Week_02", folderName, "WEEK: 2011-01-01 : WEEK 02 (Sunday)");

            dateTime = new DateTime(2011, 1, 8).AddNextDate();
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask {CultureInfo = "en-US", FolderFormat = "Week_{1:00}", FirstDayOfWeek = DayOfWeek.Monday});
            Assert.AreEqual("Week_02", folderName, "WEEK: 2011-01-01 : WEEK 02 (Monday)");

            dateTime = new DateTime(2011, 1, 8).AddNextDate();
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask {CultureInfo = "en-US", FolderFormat = "Week_{1:00}", FirstDayOfWeek = DayOfWeek.Sunday});
            Assert.AreEqual("Week_03", folderName, "WEEK: 2011-01-01 : WEEK 02 (Sunday)");

            dateTime = new DateTime(2011, 11, 30).AddNextDate();
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask {CultureInfo = "en-US", FolderFormat = "{2:00}{0:00}"});
            Assert.AreEqual("1201", folderName, "DAY: 2011-11-30 : 2011-12-01");

            dateTime = new DateTime(2011, 11, 30).AddNextDate();
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask {CultureInfo = "en-US", FolderFormat = "{3:0000}{2:00}{1:00}{0:00}"});
            Assert.AreEqual("2011124901", folderName, "MONTH: 2011-11-30 : 2011-12-30");
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask {CultureInfo = "en-US", FolderFormat = "{3:0000}-{2:00}-{0:00} WEEK-{1:00}"});
            Assert.AreEqual("2011-12-01 WEEK-49", folderName, "MONTH: 2011-11-30 : 2011-12-30");
        }
    }
}