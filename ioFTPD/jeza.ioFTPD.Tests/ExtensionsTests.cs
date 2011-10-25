using System;
using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Framework.Manager;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        public void NextDate()
        {
            DateTime dateTime = new DateTime(2011, 1, 1);
            DateTime nextDay = dateTime.AddNextDate(NewDayTaskType.Day);
            Assert.AreEqual(dateTime.AddDays(1), nextDay);
            Assert.AreEqual(2, nextDay.Day);
            dateTime = new DateTime(2011, 1, 1);
            DateTime nextWeek = dateTime.AddNextDate(NewDayTaskType.Week);
            Assert.AreEqual(dateTime.AddDays(1), nextWeek);
            dateTime = new DateTime(2011, 1, 1);
            DateTime nextMonth = dateTime.AddNextDate(NewDayTaskType.Month);
            Assert.AreEqual(dateTime.AddMonths(1), nextMonth);
        }

        [Test]
        public void FolderFormat()
        {
            DateTime dateTime = new DateTime(2011, 1, 1).AddNextDate(NewDayTaskType.Day);
            string folderName = dateTime.GetNewDayFolderFormat(new NewDayTask {CultureInfo = "en-US", FolderFormat = "{2:00}{0:00}"});
            Assert.AreEqual("0102", folderName, "DAY: 2011-01-01 : 2011-01-02");

            dateTime = new DateTime(2011, 11, 28).AddNextDate(NewDayTaskType.Day);
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask { CultureInfo = "en-US", FolderFormat = "{2:00}{0:00}" });
            Assert.AreEqual("1129", folderName, "DAY: 2011-11-28 : 2011-11-29");

            dateTime = new DateTime(2011, 11, 28).AddNextDate(NewDayTaskType.Week);
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask { CultureInfo = "en-US", FolderFormat = "{2:00}{1:00}", FirstDayOfWeek = DayOfWeek.Sunday});
            Assert.AreEqual("1149", folderName, "WEEK: 2011-11-28 : WEEK 49");

            dateTime = new DateTime(2011, 1, 1).AddNextDate(NewDayTaskType.Week);
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask { CultureInfo = "en-US", FolderFormat = "Week_{1:00}", FirstDayOfWeek = DayOfWeek.Monday });
            Assert.AreEqual("Week_01", folderName, "WEEK: 2011-01-01 : WEEK 01 (Monday)");

            dateTime = new DateTime(2011, 1, 2).AddNextDate(NewDayTaskType.Week);
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask { CultureInfo = "en-US", FolderFormat = "Week_{1:00}", FirstDayOfWeek = DayOfWeek.Sunday });
            Assert.AreEqual("Week_02", folderName, "WEEK: 2011-01-01 : WEEK 02 (Sunday)");

            dateTime = new DateTime(2011, 1, 8).AddNextDate(NewDayTaskType.Week);
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask { CultureInfo = "en-US", FolderFormat = "Week_{1:00}", FirstDayOfWeek = DayOfWeek.Monday });
            Assert.AreEqual("Week_02", folderName, "WEEK: 2011-01-01 : WEEK 02 (Monday)");

            dateTime = new DateTime(2011, 1, 8).AddNextDate(NewDayTaskType.Week);
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask { CultureInfo = "en-US", FolderFormat = "Week_{1:00}", FirstDayOfWeek = DayOfWeek.Sunday });
            Assert.AreEqual("Week_03", folderName, "WEEK: 2011-01-01 : WEEK 02 (Sunday)");

            dateTime = new DateTime(2011, 11, 30).AddNextDate(NewDayTaskType.Day);
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask { CultureInfo = "en-US", FolderFormat = "{2:00}{0:00}" });
            Assert.AreEqual("1201", folderName, "DAY: 2011-11-30 : 2011-12-01");

            dateTime = new DateTime(2011, 11, 30).AddNextDate(NewDayTaskType.Month);
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask { CultureInfo = "en-US", FolderFormat = "{3:0000}{2:00}{1:00}{0:00}" });
            Assert.AreEqual("2011125330", folderName, "MONTH: 2011-11-30 : 2011-12-30");
            folderName = dateTime.GetNewDayFolderFormat(new NewDayTask { CultureInfo = "en-US", FolderFormat = "{3:0000}-{2:00}-{0:00} WEEK-{1:00}" });
            Assert.AreEqual("2011-12-30 WEEK-53", folderName, "MONTH: 2011-11-30 : 2011-12-30");
        }
    }
}