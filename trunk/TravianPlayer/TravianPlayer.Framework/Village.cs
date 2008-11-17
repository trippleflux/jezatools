#region

using System;
using System.Collections.Generic;

#endregion

namespace TravianPlayer.Framework
{
	public class Village
	{
		public Village
			(int id,
			 string name)
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

		public void AddUnit(Unit unit)
		{
			units.Add(unit);
		}

		public Production Production
		{
			get { return production; }
			set { production = value; }
		}

		public Production GetVillageProduction()
		{
			return production;
		}

		public void ChangeVillageData
			(int villageId,
			 Building newBuilding)
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

		public int GetVillageBuildingsLevel(int buildingId)
		{
			foreach (Building building in buildings)
			{
				if (building.Id == buildingId)
				{
					return building.Level;
				}
			}
			return 0;
		}

		public Building GetVillageBuildingsData(int buildingId)
		{
			foreach (Building building in buildings)
			{
				if (building.Id == buildingId)
				{
					return building;
				}
			}
			return null;
		}

		public int GetUnitCount(string unitName)
		{
			foreach (Unit unit in units)
			{
				if (unit.UnitName.Equals(unitName))
				{
					return unit.UnitCount;
				}
			}
			return 0;
		}

		public IList<Building> Buildings
		{
			get { return buildings; }
		}

		public List<Unit> Units
		{
			get { return units; }
		}

		public int UnitsCount
		{
			get { return units.Count; }
		}

		public bool BuildInProgress { get; set; }

		private readonly List<Building> buildings = new List<Building>();

		private Production production;

		private readonly List<Unit> units = new List<Unit>();
	}
}