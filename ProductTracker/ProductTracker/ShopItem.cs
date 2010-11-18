using System;

namespace ProductTracker
{
    public class ShopItem
    {
        public ShopItem()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Sets the number of items being added.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>The same object.</returns>
        public ShopItem SetNumberOfItems(int count)
        {
            NumberOfItems = count;
            return this;
        }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        public Guid ItemId { get; set; }

        /// <summary>
        /// Gets or sets the price id.
        /// </summary>
        /// <value>The price id.</value>
        public Guid PriceId { get; set; }

        /// <summary>
        /// Gets or sets the shop id.
        /// </summary>
        /// <value>The shop id.</value>
        public Guid ShopId { get; set; }

        /// <summary>
        /// Gets or sets the number of items being added.
        /// </summary>
        /// <value>The item count.</value>
        public int NumberOfItems { get; set; }

        /// <summary>
        /// Gets or sets the date time when item was send to shop.
        /// </summary>
        /// <value>The date time.</value>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; set; }
    }
}