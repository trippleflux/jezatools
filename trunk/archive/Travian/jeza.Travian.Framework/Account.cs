using System.Collections.Generic;

namespace jeza.Travian.Framework
{
    /// <summary>
    /// Account info.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the tribeType.
        /// </summary>
        /// <value>The tribeType.</value>
        public TribeTypes TribeType
        {
            get { return tribeType; }
        }

        /// <summary>
        /// Gets the village list.
        /// </summary>
        public List<Village> Villages
        {
            get { return villages; }
        }

        /// <summary>
        /// Adds the name of the account (player name).
        /// </summary>
        /// <param name="accountName">Name of the account.</param>
        /// <returns></returns>
        public Account AddName(string accountName)
        {
            Name = accountName;
            return this;
        }

        /// <summary>
        /// Adds the id of the account (user id).
        /// </summary>
        /// <param name="accountId">The account id.</param>
        /// <returns></returns>
        public Account AddId(int accountId)
        {
            Id = accountId;
            return this;
        }

        /// <summary>
        /// Adds the tribeType of the player.
        /// </summary>
        /// <param name="accountTribeType">The account tribe.</param>
        /// <returns></returns>
        public Account AddTribe(TribeTypes accountTribeType)
        {
            tribeType = accountTribeType;
            return this;
        }

        /// <summary>
        /// Adds the village to the list.
        /// </summary>
        /// <param name="village">The village.</param>
        public void AddVillage(Village village)
        {
            if (villages.Contains(village))
            {
                return;
            }
            villages.Add(village);
        }

        /// <summary>
        /// Gets the village with specified id.
        /// </summary>
        /// <param name="villageId">The village id.</param>
        /// <returns><see cref="Village"/> if found, else <c>null</c></returns>
        public Village GetVillage(int villageId)
        {
            foreach (Village village in villages)
            {
                if (village.Id == villageId)
                {
                    return village;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds the villages.
        /// </summary>
        /// <param name="villageList">The village list.</param>
        public void UpdateVillages(List<Village> villageList)
        {
            villages.Clear();
            villages.AddRange(villageList);
        }

        private readonly List<Village> villages = new List<Village>();
        private TribeTypes tribeType;
    }
}