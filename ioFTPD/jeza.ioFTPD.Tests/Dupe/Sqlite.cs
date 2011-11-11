using System;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.Dupe
{
    [TestFixture]
    public class Sqlite
    {
        /// <summary>
        /// Insert new record.
        /// </summary>
        [Test]
        public void Insert()
        {
            string releasename = Guid.NewGuid().ToString();
            string commandText = String.Format(@"INSERT INTO Folders (UserName, GroupName, ReleaseName, PathReal, PathVirtual) VALUES('jeza', 'group', '{0}', 'c:\temp\{0}', '/temp/{0}')", releasename);
            int numberOfRows = DataBase.Insert(commandText);
            Assert.AreEqual(1, numberOfRows);
        }

        /// <summary>
        /// Checks that a record does not exists and insert it.
        /// </summary>
        [Test]
        public void Select()
        {
            string releasename = Guid.NewGuid().ToString();
            string commandText = String.Format(@"SELECT * FROM Folders WHERE ReleaseName = '{0}'", releasename);
            DataBaseDupe dataBaseDupe = DataBase.SelectFromDupe(commandText);
            Assert.IsNull(dataBaseDupe);
            commandText = String.Format(@"INSERT INTO Folders (UserName, GroupName, ReleaseName, PathReal, PathVirtual) VALUES('jeza', 'group', '{0}', 'c:\temp\{0}', '/temp/{0}')", releasename);
            int numberOfRows = DataBase.Insert(commandText);
            Assert.AreEqual(1, numberOfRows);
            commandText = String.Format(@"SELECT * FROM Folders WHERE ReleaseName = '{0}'", releasename);
            dataBaseDupe = DataBase.SelectFromDupe(commandText);
            Assert.IsNotNull(dataBaseDupe);
            Assert.AreEqual(releasename, dataBaseDupe.ReleaseName);
        }

        /// <summary>
        /// Nuke a release.
        /// </summary>
        [Test]
        public void UpdateNuke()
        {
            string releasename = Guid.NewGuid().ToString();
            string commandText = String.Format(@"SELECT * FROM Folders WHERE ReleaseName = '{0}'", releasename);
            DataBaseDupe dataBaseDupe = DataBase.SelectFromDupe(commandText);
            Assert.IsNull(dataBaseDupe);
            commandText = String.Format(@"INSERT INTO Folders (UserName, GroupName, ReleaseName, PathReal, PathVirtual) VALUES('jeza', 'group', '{0}', 'c:\temp\{0}', '/temp/{0}')", releasename);
            int numberOfRows = DataBase.Insert(commandText);
            Assert.AreEqual(1, numberOfRows);
            const string nukedReason = "Nuked for some reason";
            commandText = String.Format(@"UPDATE Folders SET Nuked = 1, NukedReason = '{1}' WHERE ReleaseName = '{0}'", releasename, nukedReason);
            numberOfRows = DataBase.Update(commandText);
            Assert.AreEqual(1, numberOfRows);
            commandText = String.Format(@"SELECT * FROM Folders WHERE ReleaseName = '{0}'", releasename);
            dataBaseDupe = DataBase.SelectFromDupe(commandText);
            Assert.IsNotNull(dataBaseDupe);
            Assert.AreEqual(releasename, dataBaseDupe.ReleaseName);
            Assert.IsTrue(dataBaseDupe.Nuked);
            Assert.AreEqual(nukedReason, dataBaseDupe.NukedReason);
        }

        /// <summary>
        /// Wipe a release.
        /// </summary>
        [Test]
        public void UpdateWipe()
        {
            string releasename = Guid.NewGuid().ToString();
            string commandText = String.Format(@"SELECT * FROM Folders WHERE ReleaseName = '{0}'", releasename);
            DataBaseDupe dataBaseDupe = DataBase.SelectFromDupe(commandText);
            Assert.IsNull(dataBaseDupe);
            commandText = String.Format(@"INSERT INTO Folders (UserName, GroupName, ReleaseName, PathReal, PathVirtual) VALUES('jeza', 'group', '{0}', 'c:\temp\{0}', '/temp/{0}')", releasename);
            int numberOfRows = DataBase.Insert(commandText);
            Assert.AreEqual(1, numberOfRows);
            const string wipedReason = "Wiped for some reason";
            commandText = String.Format(@"UPDATE Folders SET Wiped = 1, WipedReason = '{1}' WHERE ReleaseName = '{0}'", releasename, wipedReason);
            numberOfRows = DataBase.Update(commandText);
            Assert.AreEqual(1, numberOfRows);
            commandText = String.Format(@"SELECT * FROM Folders WHERE ReleaseName = '{0}'", releasename);
            dataBaseDupe = DataBase.SelectFromDupe(commandText);
            Assert.IsNotNull(dataBaseDupe);
            Assert.AreEqual(releasename, dataBaseDupe.ReleaseName);
            Assert.IsTrue(dataBaseDupe.Wiped);
            Assert.AreEqual(wipedReason, dataBaseDupe.WipedReason);
        }
    }
}
