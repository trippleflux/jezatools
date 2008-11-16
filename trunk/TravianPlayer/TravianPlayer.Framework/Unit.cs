namespace TravianPlayer.Framework
{
	public class Unit
	{
		public Unit
			(int unitCount,
			 string unitName)
		{
			UnitCount = unitCount;
			UnitName = unitName;
		}

		public int UnitCount { get; set; }

		public string UnitName { get; set; }
	}
}