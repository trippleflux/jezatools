#region

using System;

#endregion

namespace ProductTracker
{
    public class Tracker
    {
        public Tracker()
        {
            Id = Guid.NewGuid();
            DateTime = new DateTime(DateTime.Now.Ticks);
        }

        public Tracker(ShopItem shopItem)
        {
            Id = Guid.NewGuid();
            ShopItemId = shopItem.Id;
            DateTime = new DateTime(DateTime.Now.Ticks);
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the shop item id.
        /// </summary>
        /// <value>The shop item id.</value>
        public Guid ShopItemId { get; set; }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>The date time.</value>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the sold count.
        /// </summary>
        /// <value>The sold count.</value>
        public int SoldCount { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, ShopItemId: {1}, DateTime: {2}, SoldCount: {3}", Id, ShopItemId, DateTime,
                                 SoldCount);
        }
    }
}