using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using jeza.ioFTPD.Framework;
using jeza.ioFTPD.Framework.Archive;
using MbUnit.Framework;

namespace jeza.ioFTPD.Tests.Archive
{
    /// <summary>
    /// Performs checks on source and destination folders.
    /// </summary>
    [TestFixture]
    public class Folders
    {
        ///// <summary>
        ///// Check the number of folders in source.
        ///// </summary>
        //[Test]
        //[Explicit]
        //public void NumberOfFoldersInSourceNoSkipPattern()
        //{
        //    DirectoryInfo directoryInfo = new DirectoryInfo(@"..\..\TestFiles\Archive\source");
        //    archiveTask.RegExpressionInclude = null;
        //    archiveTask.RegExpressionExclude = null;
        //    List<DirectoryInfo> folders = directoryInfo.GetFolders(archiveTask);
        //    const int expectedValue = 6;
        //    Assert.AreEqual(expectedValue, folders.Count);
        //}

        /// <summary>
        /// Check the number of folders in source.
        /// </summary>
        [Test]
        public void NumberOfFoldersInSource()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"..\..\TestFiles\Archive\source");
            archiveTask.RegExpressionInclude = null;
            archiveTask.RegExpressionExclude = @"\b(\.|[Ff]|[Ss])\S*";
            List<DirectoryInfo> folders = directoryInfo.GetFolders(archiveTask);
            const int expectedValue = 4;
            Assert.AreEqual(expectedValue, folders.Count);
        }

        ///// <summary>
        ///// Check the total folder size in source.
        ///// </summary>
        //[Test]
        //[Explicit]
        //public void TotalFolderSize()
        //{
        //    DirectoryInfo directoryInfo = new DirectoryInfo(@"..\..\TestFiles\Archive\source");
        //    archiveTask.RegExpressionInclude = null;
        //    archiveTask.RegExpressionExclude = @"\b(\.|[Ff]|[Ss])\S*";
        //    List<DirectoryInfo> folders = directoryInfo.GetFolders(archiveTask);
        //    UInt64 totalFolderSize = 0;
        //    foreach (DirectoryInfo folder in folders)
        //    {
        //        totalFolderSize += folder.GetFolderSize();
        //    }
        //    const Int32 expectedValue = 106268;
        //    const int delta = 2000;
        //    Assert.AreApproximatelyEqual(expectedValue, (Int32)totalFolderSize, delta);
        //}

        //[Test]
        //[Explicit("Can not determine how SVN creates test folders")]
        //public void GetOldest()
        //{
        //    DirectoryInfo directoryInfo = new DirectoryInfo(@"..\..\TestFiles\Archive\source");
        //    List<DirectoryInfo> folders = directoryInfo.GetFolders(archiveTask);
        //    DirectoryInfo[] directoryInfos = folders.ToArray();
        //    Array.Sort(directoryInfos, (IComparer) new CompareDirectoryByDate());
        //    Assert.AreEqual("2", directoryInfos[0].Name);
        //}

        private readonly ArchiveTask archiveTask = new ArchiveTask
        {
            ArchiveStatus = ArchiveStatus.Enabled,
            ArchiveType = ArchiveType.Delete,
            RegExpressionInclude = @"\S*([Ss]targate|[Ss]tar[Tt]rek)\S*",
            RegExpressionExclude = @"\S*([Cc]aprica|[Ff]ringe)\S*",
            Source = "C:\\temp123asd",
            Destination = "D:\\temp123dsa",
            Action = new ArchiveAction
            {
                Id = ArchiveActionAttribute.TotalFolderCount,
                Value = 999 * 1024 * 1024,
                MinFolderAction = 5,
            },
        };
    }
}
