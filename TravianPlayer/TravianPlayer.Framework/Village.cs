using System;
using System.Collections.Generic;

namespace TravianPlayer.Framework
{
    public class Village
    {
        public Village(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public void AddBuilding(Building building)
        {
            buildings.Add(building);
        }

        public void ChangeVillageData(int villageId, Building newBuilding)
        {
            foreach (Building building in buildings)
            {
                if (building.Id == villageId)
                {
                    building.Level = newBuilding.Level;
                    building.Name = newBuilding.Name;
                    break;
                }
            }
        }

        public int GetBuildingsCount
        {
            get { return buildings.Count; }
        }

        public int GetBuildingsLevel(int villageId)
        {
            foreach (Building building in buildings)
            {
                if (building.Id == villageId)
                {
                    return building.Level;
                }
            }
            return 0;
        }

        public string GetBuildingsName(int villageId)
        {
            foreach (Building building in buildings)
            {
                if (building.Id == villageId)
                {
                    return building.Name;
                }
            }
            return String.Empty;
        }

        public IList<Building> Buildings
        {
            get { return buildings; }
        }

        private List<Building> buildings = new List<Building>();
    }
}