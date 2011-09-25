using System;
using System.Collections;
using System.IO;

namespace jeza.ioFTPD.Framework
{
    public class CompareDirectoryByDate : IComparer
    {
        public int Compare(object x,
                           object y)
        {
            DirectoryInfo first = x as DirectoryInfo;
            DirectoryInfo second = y as DirectoryInfo;
            if (first != null)
            {
                DateTime creationTimeUtcFirst = first.CreationTimeUtc;
                if (second != null)
                {
                    DateTime creationTimeUtcSecond = second.CreationTimeUtc;
                    return DateTime.Compare(creationTimeUtcFirst, creationTimeUtcSecond);
                }
            }
            return 0;
        }
    }
}