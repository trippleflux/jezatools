namespace jeza.ioFTPD.Framework
{
    public class RescanStatsData
    {
        public string FileName { get; set; }
        public string ExpectedCrc32Value { get; set; }
        public string ActualCrc32Value { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return string.Format("{1,-8} {2,-8} {3,-8} {0,-60}", FileName, ExpectedCrc32Value, ActualCrc32Value, Status);
        }
    }
}