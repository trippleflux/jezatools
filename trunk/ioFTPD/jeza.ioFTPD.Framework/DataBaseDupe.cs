namespace jeza.ioFTPD.Framework
{
    public class DataBaseDupe
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public string DateTime { get; set; }
        public string PathReal { get; set; }
        public string PathVirtual { get; set; }
        public string ReleaseName { get; set; }
        public bool Nuked { get; set; }
        public string NukedReason { get; set; }
        public bool Wiped { get; set; }
        public string WipedReason { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, UserName: {1}, GroupName: {2}, DateTime: {3}, PathReal: {4}, PathVirtual: {5}, ReleaseName: {6}, Nuked: {7}, NukedReason: {8}, Wiped: {9}, WipedReason: {10}", Id, UserName, GroupName, DateTime, PathReal, PathVirtual, ReleaseName, Nuked, NukedReason, Wiped, WipedReason);
        }
    }
}