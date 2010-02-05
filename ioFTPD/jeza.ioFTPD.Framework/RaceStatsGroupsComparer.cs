using System.Collections.Generic;

namespace jeza.ioFTPD.Framework
{
    public class RaceStatsGroupsComparer : IComparer<RaceStatsGroups>
    {
        public int Compare (RaceStatsGroups x,
                            RaceStatsGroups y)
        {
            return (int) (x.BytesUplaoded - y.BytesUplaoded);
        }
    }
}