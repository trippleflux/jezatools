namespace Library
{
	/// <summary>
	/// Villages ID and Name.
	/// </summary>
	/// <example><div class="dname"><h1>Muta01</h1></div> - one village!!! ?newdid=0</example>
	/// <example><a href="?newdid=123788">Muta06</a> - more villages!!!</example>
	/// 
	public class Village
	{
		private int villageId;
		private string villageName;

		/// <summary>
		/// Village ID
		/// </summary>
		public int VillageId
		{
			get { return villageId; }
			set { villageId = value; }
		}

		/// <summary>
		/// Vilalge Name
		/// </summary>
		public string VillageName
		{
			get { return villageName; }
			set { villageName = value; }
		}

        public override string ToString()
		{
			return string.Format("VillageId: {0}, VillageName: {1}", villageId, villageName);
		}
	}
}