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
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return name; }
        }

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
            name = accountName;
            return this;
        }

        /// <summary>
        /// Adds the id of the account (user id).
        /// </summary>
        /// <param name="accountId">The account id.</param>
        /// <returns></returns>
        public Account AddId(int accountId)
        {
            id = accountId;
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

        private readonly List<Village> villages = new List<Village>();
        private string name;
        private int id;
        private TribeTypes tribeType;
    }
}