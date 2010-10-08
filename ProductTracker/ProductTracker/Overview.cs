using System;
using System.Collections.Generic;

namespace ProductTracker
{
    public class Overview
    {
        /// <summary>
        /// Adds the shop item.
        /// </summary>
        /// <param name="shopItem">The item.</param>
        /// <returns></returns>
        public Overview AddShopItem(ShopItem shopItem)
        {
            if (ItemExistsInShop(shopItem.Item.UniqueId, shopItem.Shop))
            {
                UpdateShopItem();
            }
            else
            {
                shopItems.Add(shopItem);
            }
            return this;
        }

        /// <summary>
        /// Gets the total items in all shops.
        /// </summary>
        /// <value>The total items in all shops.</value>
        public int TotalNumberOftemsInAllShops
        {
            get
            {
                int totalItemsCount = 0;
                foreach (ShopItem shopItem in shopItems)
                {
                    totalItemsCount += shopItem.NumberOfItems;
                }
                return totalItemsCount;
            }
        }

        /// <summary>
        /// Gets the total number of items in specified shop.
        /// </summary>
        /// <param name="shop">The shop.</param>
        /// <returns></returns>
        public int TotalNumberOfItemsInShop(Shop shop)
        {
            int totalItemsCount = 0;
            foreach (ShopItem shopItem in shopItems)
            {
                if (shopItem.Shop == shop)
                {
                    totalItemsCount += shopItem.NumberOfItems;
                }
            }
            return totalItemsCount;
        }

        private void UpdateShopItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if specified item allready exists in shop.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="shop">The shop.</param>
        /// <returns></returns>
        private bool ItemExistsInShop(Guid id, Shop shop)
        {
            foreach (ShopItem shopItem in shopItems)
            {
                if (shopItem.Shop.Id == shop.Id)
                {
                    if (shopItem.Item.UniqueId == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private readonly List<ShopItem> shopItems = new List<ShopItem>();
    }
}