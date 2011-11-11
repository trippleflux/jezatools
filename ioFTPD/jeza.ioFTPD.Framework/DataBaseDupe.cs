namespace jeza.ioFTPD.Framework
{
    public class DataBaseDupe
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string DateTime { get; set; }
        public string PathReal { get; set; }
        public string PathVirtual { get; set; }
        public string ReleaseName { get; set; }
        public bool Nuked { get; set; }
        public string NukedReason { get; set; }
        public bool Wiped { get; set; }
        public string WipedReason { get; set; }
    }
}