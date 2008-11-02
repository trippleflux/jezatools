#region

using System;

#endregion

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



		public override string ToString()
		{
			return
				string.Format("BuildTask [VillageId: {0}, BuildingId: {1}, WantedBuildingLevel: {2}, NextCheck: {3}, BuildTaskComment: {4}]",
							  VillageId, BuildingId, WantedBuildingLevel, NextCheck.ToString(("yyyy-MM-dd HH:mm:ss")), BuildTaskComment);
		}
	}
}