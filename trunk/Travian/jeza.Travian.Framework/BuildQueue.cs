namespace jeza.Travian.Framework
{
    /// <summary>
    /// Info about build queue.
    /// </summary>
    public class BuildQueue
    {
        /// <summary>
        /// Gets or sets the village id.
        /// </summary>
        /// <value>The village id.</value>
        public int VillageId { get; set; }

        /// <summary>
        /// Gets or sets the name of the village.
        /// </summary>
        /// <value>The name of the village.</value>
        public string VillageName { get; set; }

        /// <summary>
        /// Gets or sets the building id.
        /// </summary>
        /// <value>The building id.</value>
        public int BuildingId { get; set; }

        /// <summary>
        /// Gets or sets the wanted level.
        /// </summary>
        /// <value>The level.</value>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the name of the queue.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the priority for the queue.
        /// </summary>
        /// <value>The priority.</value>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the resources needed for upgrade.
        /// </summary>
        /// <value>The resources.</value>
        public ResourcesForUpgrade Resources { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {2}, Level: {1}", VillageName, Level, Name);
        }
    }
}