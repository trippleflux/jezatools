namespace twL
{
	public class UpgradeCosts
	{
		public int BuildingWoodCost { get; set; }
		public int BuildingClayCost { get; set; }
		public int BuildingIronCost { get; set; }
		public int BuildingCropCost { get; set; }



		public override string ToString()
		{
			return string.Format("UpgradeCosts [BuildingWoodCost: {0}, BuildingClayCost: {1}, BuildingIronCost: {2}, BuildingCropCost: {3}]",
			                     BuildingWoodCost, BuildingClayCost, BuildingIronCost, BuildingCropCost);
		}
	}
}