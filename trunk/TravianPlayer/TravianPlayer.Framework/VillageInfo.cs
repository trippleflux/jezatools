using System.Collections;
using System.Collections.Generic;

namespace TravianPlayer.Framework
{
    public class VillageInfo
    {
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public void AddVillageBuilding(BuildingInfo buildingInfo)
        {
            villageBuildings.Add(buildingInfo);
        }

        public IList GetVillageBuildings()
        {
            return villageBuildings;
        }

        public BuildingInfo GetBuildingInfo(int buildingId)
        {
            foreach (BuildingInfo buildingInfo in villageBuildings)
            {
                if (buildingInfo.Id == buildingId)
                {
                    return buildingInfo;
                }
            }
            return null;
        }

        public int GetBuildingLevel(int buildingId)
        {
            foreach (BuildingInfo buildingInfo in villageBuildings)
            {
                if (buildingInfo.Id == buildingId)
                {
                    return buildingInfo.Level;
                }
            }
            return 0;
        }

        public int VillageBuildingsCount()
        {
            return villageBuildings.Count;
        }

        private List<BuildingInfo> villageBuildings = new List<BuildingInfo>();
        private string name;
        private int id;
    }
}