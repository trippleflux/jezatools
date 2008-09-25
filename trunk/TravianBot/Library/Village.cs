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
        private string villageId;
        private string villageName;

        /// <summary>
        /// Village ID
        /// </summary>
        public string VillageId
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
    }
}