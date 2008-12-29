namespace TravianBot.Framework
{
    public class Unit
    {
        public Unit(int unitCount,
                    string unitName)
        {
            this.unitCount = unitCount;
            this.unitName = unitName;
        }

        public string UnitName
        {
            get { return unitName; }
        }

        public int UnitCount
        {
            get { return unitCount; }
        }

        private readonly int unitCount;
        private readonly string unitName;
    }
}