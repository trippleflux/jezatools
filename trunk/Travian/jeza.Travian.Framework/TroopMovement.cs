#region

using System;

#endregion

namespace jeza.Travian.Framework
{
    public class TroopMovement

    {
        public TroopMovementType Type
        {
            get { return type; }
        }

        public Troops Troops
        {
            get { return troops; }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
        }

        public string SourceVillageName
        {
            get { return sourceVillageName; }
        }

        public string DestinationVillageName
        {
            get { return destinationVillageName; }
        }

        public string SourceVillageUrl
        {
            get { return sourceVillageUrl; }
        }

        public string DestinationVillageUrl
        {
            get { return destinationVillageUrl; }
        }

        /// <summary>
        /// Adds the troops to the list.
        /// </summary>
        /// <param name="troopList">The new troops.</param>
        /// <returns></returns>
        public TroopMovement AddTroops(Troops troopList)
        {
            troops = troopList;
            return this;
        }

        /// <summary>
        /// Sets the date the troop will arrive.
        /// </summary>
        /// <param name="arrivalDateTime">The arrival date time.</param>
        /// <returns></returns>
        public TroopMovement SetDate(DateTime arrivalDateTime)
        {
            dateTime = arrivalDateTime;
            return this;
        }

        /// <summary>
        /// Sets the destination village name and url.
        /// </summary>
        /// <param name="villageName">Name of the village.</param>
        /// <param name="villageUrl">The village URL.</param>
        /// <returns></returns>
        public TroopMovement SetDestination(string villageName, string villageUrl)
        {
            destinationVillageName = villageName;
            destinationVillageUrl = villageUrl;
            return this;
        }

        /// <summary>
        /// Sets the source village name and url.
        /// </summary>
        /// <param name="villageName">Name of the village.</param>
        /// <param name="villageUrl">The village URL.</param>
        /// <returns></returns>
        public TroopMovement SetSource(string villageName, string villageUrl)
        {
            sourceVillageName = villageName;
            sourceVillageUrl = villageUrl;
            return this;
        }

        /// <summary>
        /// Sets the type of the troop movement.
        /// </summary>
        /// <param name="movementType">Type of the movement.</param>
        /// <returns></returns>
        public TroopMovement SetType(TroopMovementType movementType)
        {
            type = movementType;
            return this;
        }

        private TroopMovementType type;
        private Troops troops;
        private DateTime dateTime;
        private string sourceVillageName;
        private string destinationVillageName;
        private string sourceVillageUrl;
        private string destinationVillageUrl;
    }
}