namespace TravianPlayer.Framework
{
	public class ActionParameters
	{
		public int Id { get; set; }

		public int VillageId { get; set; }

		public int CoordX { get; set; }

		public int CoordY { get; set; }

		public int AttackType { get; set; }

		public int AttackUnit { get; set; }

		public string AttackUnitName { get; set; }

		public int TroopCount { get; set; }

		public string Comment { get; set; }

		public bool Enabled { get; set; }

		public override string ToString()
		{
			return
				string.Format(
					"ActionParameters: [Id: {0}, VillageId: {1}, CoordX: {2}, CoordY: {3}, AttackType: {4}, AttackUnit: {5}, AttackUnitName: {6}, TroopCount: {7}, Comment: {8}, Enabled: {9}]",
					Id, VillageId, CoordX, CoordY, AttackType, AttackUnit, AttackUnitName, TroopCount, Comment, Enabled);
		}
	}
}