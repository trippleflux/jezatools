namespace TravianPlayer.Framework
{
    public class Building
    {
        public Building(int id, string name, int level)
        {
            Id = id;
            Name = name;
            Level = level;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }
    }
}