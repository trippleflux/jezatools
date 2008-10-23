using System;

namespace twL
{
	/// <summary>
	/// Build task for buildings
	/// </summary>
	public class BuildTask
	{
		/// <summary>
		/// Village Id
		/// </summary>
		public int VillageId { get; set; }

		/// <summary>
		/// Id of the Building
		/// </summary>
		public int BuildingId { get; set; }

		/// <summary>
		/// Wanted Building level
		/// </summary>
		public int WantedBuildingLevel { get; set; }

        /// <summary>
        /// DateTime when the next check is done
        /// </summary>
        public DateTime NextCheck { get; set; }
        
        /// <summary>
		/// User comment
		/// </summary>
		public string BuildTaskComment { get; set; }
	}
}