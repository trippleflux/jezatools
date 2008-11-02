#region

using System;
using System.Text.RegularExpressions;

#endregion

namespace twL
{
	public class VillageInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime BuildEndTime { get; set; }

		public int WoodAvailable { get; set; }
		public int ClayAvailable { get; set; }
		public int IronAvailable { get; set; }
		public int CropAvailable { get; set; }

		public int WoodPerHour { get; set; }
		public int ClayPerHour { get; set; }
		public int IronPerHour { get; set; }
		public int CropPerHour { get; set; }

		public int CropUnitsAvailable { get; set; }
		public int CropUnitsConsumption { get; set; }

		public int WarehouseSize { get; set; }
		public int GranarySize { get; set; }

		public bool NumberOfIncomingAttacks { get; set; }
		public bool NumberOfIncomingReinforces { get; set; }
		public bool NumberOfAttacks { get; set; }
		public bool NumberOfReinforces { get; set; }

		public MatchCollection ResourcesCollection { get; set; }
		public MatchCollection BuildingsCollection { get; set; }



		public override string ToString()
		{
			return
				string.Format(
					"VillageInfo [Id: {0}, Name: {1}, BuildEndTime: {2}, WoodAvailable: {3}, ClayAvailable: {4}, IronAvailable: {5}, CropAvailable: {6}, WoodPerHour: {7}, ClayPerHour: {8}, IronPerHour: {9}, CropPerHour: {10}, CropUnitsAvailable: {11}, CropUnitsConsumption: {12}, WarehouseSize: {13}, GranarySize: {14}, NumberOfIncomingAttacks: {15}, NumberOfIncomingReinforces: {16}, NumberOfAttacks: {17}, NumberOfReinforces: {18}, ResourcesCollection: {19}, BuildingsCollection: {20}]",
					Id, Name, BuildEndTime, WoodAvailable, ClayAvailable, IronAvailable, CropAvailable, WoodPerHour, ClayPerHour,
					IronPerHour, CropPerHour, CropUnitsAvailable, CropUnitsConsumption, WarehouseSize, GranarySize,
					NumberOfIncomingAttacks, NumberOfIncomingReinforces, NumberOfAttacks, NumberOfReinforces, ResourcesCollection,
					BuildingsCollection);
		}



		public string AvailableResources()
		{
			return
				string.Format(
					"AvailableResources [Id: {0}, Name: {1}, WoodAvailable: {2}, ClayAvailable: {3}, IronAvailable: {4}, CropAvailable: {5}]",
					Id, Name, WoodAvailable, ClayAvailable, IronAvailable, CropAvailable);
		}



		public string ProductionPerHour()
		{
			return
				string.Format(
					"ProductionPerHour [Id: {0}, Name: {1}, WoodPerHour: {2}, ClayPerHour: {3}, IronPerHour: {4}, CropPerHour: {5}]", Id,
					Name, WoodPerHour, ClayPerHour, IronPerHour, CropPerHour);
		}
	}
}