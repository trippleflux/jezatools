namespace ProductTracker
{
    public class ItemType
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}", Id, Name);
        }
    }
}