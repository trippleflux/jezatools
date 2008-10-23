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
	}
}