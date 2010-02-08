#region
using System;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class RaceStatsUsers : IComparable<RaceStatsUsers>
    {
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public int Speed { get; set; }
        public int FilesUplaoded { get; set; }
        public UInt64 BytesUplaoded { get; set; }

        public int CompareTo (RaceStatsUsers other)
        {
            return BytesUplaoded.CompareTo (other.BytesUplaoded);
        }

        public override string ToString ()
        {
            return string.Format ("UserName: {0}, GroupName: {1}, Speed: {2}, FilesUplaoded: {3}, BytesUplaoded: {4}",
                                  UserName,
                                  GroupName,
                                  Speed,
                                  FilesUplaoded,
                                  BytesUplaoded);
        }
    }
}