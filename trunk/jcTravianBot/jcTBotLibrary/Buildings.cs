namespace jcTBotLibrary
{
	public class Buildings
	{
		public int BuildingId
		{
			get { return buildingId; }
			set { buildingId = value; }
		}

		public string BuildingName
		{
			get { return buildingName; }
			set { buildingName = value; }
		}

		public int BuildingLevel
		{
			get { return buildingLevel; }
			set { buildingLevel = value; }
		}

		private int buildingId;
		private string buildingName;
		private int buildingLevel;

	}
}