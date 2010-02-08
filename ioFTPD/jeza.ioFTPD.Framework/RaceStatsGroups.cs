#region
using System;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class RaceStatsGroups : IComparable<RaceStatsGroups>
    {
        public string GroupName { get; set; }
        public int Speed { get; set; }
        public int FilesUplaoded { get; set; }
        public UInt64 BytesUplaoded { get; set; }

        public int CompareTo (RaceStatsGroups other)
        {
            return BytesUplaoded.CompareTo (other.BytesUplaoded);
        }

        public override string ToString ()
        {
            return string.Format ("GroupName: {0}, Speed: {1}, FilesUplaoded: {2}, BytesUplaoded: {3}",
                                  GroupName,
                                  Speed,
                                  FilesUplaoded,
                                  BytesUplaoded);
        }
    }
}