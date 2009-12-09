namespace TravianBot.Framework
{
    public class ActionParameters
    {
        /// <summary>
        /// Unique id if the entry.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Enable or disable sending.
        /// </summary>
        public int Enabled { get; set; }

        /// <summary>
        /// X coordinate of target.
        /// </summary>
        public int CoordinateX { get; set; }

        /// <summary>
        /// Y coordinate of target.
        /// </summary>
        public int CoordinateY { get; set; }

        /// <summary>
        /// Vilalge id from where troops should be send.
        /// </summary>
        public int VillageId { get; set; }

        /// <summary>
        /// Type of sending.
        /// </summary>
        /// <list>
        /// <item><term>2</term><description>Reinforcements</description></item>
        /// <item><term>3</term><description>Attaack</description></item>
        /// <item><term>4</term><description>Raid</description></item>
        /// </list>
        public int SendTroopType { get; set; }

        /// <summary>
        /// Id of the unit.
        /// </summary>
        /// <list>
        /// <item><term>0</term><description>Clubswinger</description></item>
        /// <item><term>1</term><description>Spearman</description></item>
        /// <item><term>2</term><description>Axeman</description></item>
        /// </list>
        public int UnitId { get; set; }

        /// <summary>
        /// Total number of troops to send.
        /// </summary>
        public int UnitCount { get; set; }

        /// <summary>
        /// Name of the unit to search for if available.
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Player name.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Village name.
        /// </summary>
        public string VillageName { get; set; }

        /// <summary>
        /// Village population.
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// Name of the aliance.
        /// </summary>
        public string Aliance { get; set; }

        /// <summary>
        /// User comment.
        /// </summary>
        public string Comment { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id: {0}, Enabled: {1}, CoordinateX: {2}, CoordinateY: {3}, VillageId: {4}, SendTroopType: {5}, UnitId: {6}, UnitCount: {7}, UnitName: {8}, PlayerName: {9}, VillageName: {10}, Population: {11}, Aliance: {12}, Comment: {13}",
                    Id, Enabled, CoordinateX, CoordinateY, VillageId, SendTroopType, UnitId, UnitCount, UnitName,
                    PlayerName, VillageName, Population, Aliance, Comment);
        }
    }
}