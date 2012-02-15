#region

using System;

#endregion

namespace ProductTracker
{
    public class Item
    {
        public Item()
        {
        }

        public Item(string id, string name)
        {
            Id = id;
            Name = name;
            UniqueId = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the id of the item.
        /// </summary>
        /// <value>The id.</value>
        public Guid UniqueId { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The id.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the notes for the item.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>The type of the item.</value>
        public int ItemType { get; set; }

        public override string ToString()
        {
            return string.Format("UniqueId: {0}, Id: {1}, Name: {2}, Notes: {3}, ItemType: {4}", UniqueId, Id, Name,
                                 Notes, ItemType);
        }
    }
}