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
            ItemType = ItemType.Card;
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
        public ItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets the item type number.
        /// </summary>
        /// <value>The item type number.</value>
        public int ItemTypeNumber { get; set; }

        public ItemType ConvertIntToItemType(int itemNumber)
        {
            switch (itemNumber)
            {
                case (int) ItemType.Card:
                    {
                        return ItemType.Card;
                    }
                default:
                    {
                        return ItemType.Card;
                    }
            }
        }
    }
}