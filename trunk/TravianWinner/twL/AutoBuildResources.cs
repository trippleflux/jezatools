namespace twL
{
	public class AutoBuildResources
	{
		public enum AutoBuildTasks
		{
			BuildWood,
			BuildClay,
			BuildIron,
			BuildCrop,
			BuildAll,
		}

		/// <summary>
		/// Village Id
		/// </summary>
		public int VillageId { get; set; }
	}
}