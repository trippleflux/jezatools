#region
using System;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class RaceStatsUsers
    {
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public int Speed { get; set; }
        public int FilesUplaoded { get; set; }
        public UInt64 BytesUplaoded { get; set; }
    }
}