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

        public int WoodAvailable { get; set; }
        public int ClayAvailable { get; set; }
        public int IronAvailable { get; set; }
        public int CropAvailable { get; set; }

        public int WoodProduction { get; set; }
        public int ClayProduction { get; set; }
        public int IronProduction { get; set; }
        public int CropProduction { get; set; }

        public int CapacityWarehouse { get; set; }
        public int CapacityGranary { get; set; }

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

        public void RemoveVillageUnits()
        {
            villageUnits.Clear();
        }

        private readonly int villageId;

        private readonly string villageName;

        private readonly List<Unit> villageUnits = new List<Unit>();
    }
}