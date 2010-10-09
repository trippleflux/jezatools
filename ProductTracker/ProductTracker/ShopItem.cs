using System;

namespace ProductTracker
{
    public class ShopItem
    {
        public ShopItem()
        {
        }

        public ShopItem(Item item, Shop shop, Price price)
        {
            Item = item;
            Shop = shop;
            Price = price;
            NumberOfItems = 1;
            DateTime = new DateTime(DateTime.Now.Ticks);
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
        /// Gets or sets the item.
        /// </summary>
        /// <value>The item.</value>
        public Item Item { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        public Guid ItemId { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public Price Price { get; set; }

        /// <summary>
        /// Gets or sets the price id.
        /// </summary>
        /// <value>The price id.</value>
        public Guid PriceId { get; set; }

        /// <summary>
        /// Gets or sets the shop.
        /// </summary>
        /// <value>The shop.</value>
        public Shop Shop { get; set; }

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