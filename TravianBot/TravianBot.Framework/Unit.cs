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

        public override string ToString()
        {
            return string.Format("UnitCount: {0}, UnitName: {1}", unitCount, unitName);
        }

        private readonly int unitCount;
        private readonly string unitName;
    }
}