using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.Archive
{
    /// <summary>
    /// Performs checks on source and destination folders.
    /// </summary>
    [TestFixture]
    public class Folders
    {
        /// <summary>
        /// Check the number of folders in source.
        /// </summary>
        [Test]
        public void NumberOfFoldersInSourceNoSkipPattern()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"..\..\TestFiles\Archive\source");
            List<DirectoryInfo> folders = directoryInfo.GetFolders(null);
            const int expectedValue = 5;
            Assert.AreEqual(expectedValue, folders.Count);
        }

        /// <summary>
        /// Check the number of folders in source.
        /// </summary>
        [Test]
        public void NumberOfFoldersInSource()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"..\..\TestFiles\Archive\source");
            List<DirectoryInfo> folders = directoryInfo.GetFolders(new string[] { "." });
            const int expectedValue = 4;
            Assert.AreEqual(expectedValue, folders.Count);
        }

        /// <summary>
        /// Check the total folder size in source.
        /// </summary>
        [Test]
        public void TotalFolderSize()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"..\..\TestFiles\Archive\source");
            List<DirectoryInfo> folders = directoryInfo.GetFolders(new string[] { "." });
            UInt64 totalFolderSize = 0;
            foreach (DirectoryInfo folder in folders)
            {
                totalFolderSize += folder.GetFolderSize();
            }
            const Int32 expectedValue = 26567* 4;
            const int delta = 2000;
            Assert.AreApproximatelyEqual(expectedValue, (Int32)totalFolderSize, delta);
        }

        [Test]
        public void GetOldest()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"..\..\TestFiles\Archive\source");
            List<DirectoryInfo> folders = directoryInfo.GetFolders(new string[] { "." });
            DirectoryInfo[] directoryInfos = folders.ToArray();
            Array.Sort(directoryInfos, (IComparer) new CompareDirectoryByDate());
            Assert.AreEqual("2", directoryInfos[0].Name);
        }
    }
}
