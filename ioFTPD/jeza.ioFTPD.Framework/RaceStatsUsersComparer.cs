using System.Collections.Generic;

namespace jeza.ioFTPD.Framework
{
    public class RaceStatsUsersComparer : IComparer<RaceStatsUsers>
    {
        public int Compare
            (RaceStatsUsers x,
             RaceStatsUsers y)
        {
            return (int) (x.BytesUplaoded - y.BytesUplaoded);
        }
    }
}