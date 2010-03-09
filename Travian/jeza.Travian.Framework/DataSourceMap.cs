namespace jeza.Travian.Framework
{
    public class DataSourceMap
    {
        public int Id { get; set; }
        public string Player { get; set; }
        public string VillageName { get; set; }
        public string Alliance { get; set; }
        public int Population { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public ValleyType ValleyType { get; set; }
        public string Notes { get; set; }
    }
}