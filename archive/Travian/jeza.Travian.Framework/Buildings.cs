namespace jeza.Travian.Framework
{
    public class Buildings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Level { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]-{1}", Id, Name);
        }
    }
}