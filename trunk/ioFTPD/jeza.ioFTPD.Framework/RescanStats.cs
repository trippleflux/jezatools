using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jeza.ioFTPD.Framework
{
    public class RescanStats
    {
        public RescanStats()
        {
            RescanStatsData = new List<RescanStatsData>();
        }

        public int TotalFiles { get; set; }
        public int MissingFiles { get; set; }
        public int OkFiles { get; set; }
        public int FailedFiles { get; set; }
        public List<RescanStatsData> RescanStatsData { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string format = String.Format(CultureInfo.InvariantCulture, "{1,-8} {2,-8} {3,-8} {0,-60}", "FileName", "Expected", "Actual", "Status");
            sb.AppendLine(format);
            foreach (RescanStatsData rescanStatsData in RescanStatsData)
            {
                sb.AppendLine(rescanStatsData.ToString());
            }
            return sb.ToString();
        }
    }
}