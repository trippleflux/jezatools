using System.Collections.Generic;

namespace TravianBot.Framework
{
    public class Village
    {
        public Village(int villageId,
                       string villageName)
        {
            this.villageId = villageId;
            this.villageName = villageName;
        }

        public string VillageName
        {
            get { return villageName; }
        }

        public int VillageId
        {
            get { return villageId; }
        }

        public IList<Unit> VillageUnits
        {
            get { return villageUnits; }
        }

        public void AddVillageUnit(Unit unit)
        {
            villageUnits.Add(unit);
        }

        public Unit GetUnit(string unitName)
        {
            foreach (Unit unit in villageUnits)
            {
                if (unit.UnitName == unitName)
                {
                    return unit;
                }
            }
            return null;
        }

        private readonly int villageId;

        private readonly string villageName;

        private readonly List<Unit> villageUnits = new List<Unit>();
    }
}