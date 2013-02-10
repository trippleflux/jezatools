using System;
using jeza.ioFTPD.Framework;
using NUnit.Framework;

namespace jeza.ioFTPD.Tests.Dupe
{
    [TestFixture]
    public class NewDir
    {
        /// <summary>
        /// Create new dir and add it to dupe DB.
        /// </summary>
        [Test]
        public void AddNew()
        {
            ConsoleAppTasks task = new ConsoleAppTasks(new[] {"newdir", @"..\..\TestFiles", "/test/TestFiles"});
            task.Execute(TaskType.DupeNewDir);
        }

        /// <summary>
        /// Creatinon of new dir fails because of dupe.
        /// </summary>
        [Test]
        public void AddNewDupe()
        {
            const string releasename = "TestFiles";
            string commandText = String.Format(@"INSERT INTO Folders (UserName, GroupName, ReleaseName, PathReal, PathVirtual) VALUES('jeza', 'group', '{0}', 'c:\temp\{0}', '/temp/{0}')", releasename);
            int numberOfRows = DataBase.Insert(commandText);
            Assert.AreEqual(1, numberOfRows);
            ConsoleAppTasks task = new ConsoleAppTasks(new[] { "newdir", @"..\..\" + releasename, "/test/" + releasename });
            Assert.AreEqual(Constants.CodeFail, task.Execute(TaskType.DupeNewDir));
        }
    }
}