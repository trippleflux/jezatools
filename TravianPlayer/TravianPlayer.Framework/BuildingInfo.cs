namespace TravianPlayer.Framework
{
    public class BuildingInfo
    {
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        private int id;
        private string name;
        private int level;
    }
}