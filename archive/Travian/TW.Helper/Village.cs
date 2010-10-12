namespace TW.Helper
{
    public class Village
    {
        public Village(int id,
                       string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string Coordinates { get; set; }
        public Production Production { get; set; }
    }
}