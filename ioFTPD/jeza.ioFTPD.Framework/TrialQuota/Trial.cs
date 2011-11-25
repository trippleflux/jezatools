using System;

namespace jeza.ioFTPD.Framework.TrialQuota
{
    public class Trial
    {
        public int Uid { get; set; }
        public DateTime DateAdded { get; set; }
        public int Period { get; set; }
        public int QuotaToPass { get; set; }
        public UInt64 StartAllUp { get; set; }
    }
}