#region

using System;
using System.Collections.Generic;
using System.Globalization;

#endregion

namespace jeza.Travian.Framework
{
    [Serializable]
    public class Village
    {
        /// <summary>
        /// Gets the coordinates in format (x|y).
        /// </summary>
        /// <value>The coordinates.</value>
        public string Coordinates
        {
            get { return String.Format(CultureInfo.InvariantCulture, "({0}|{1})", CoordinateX, CoordinateY); }
        }

        /// <summary>
        /// Gets the coordinate X.
        /// </summary>
        /// <value>The coordinate X.</value>
        public int CoordinateX { get; set; }


        /// <summary>
        /// Gets the coordinate Y.
        /// </summary>
        /// <value>The coordinate Y.</value>
        public int CoordinateY { get; set; }

        /// <summary>
        /// Gets the id of the village.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets the name of the village.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the own attacks countin village.
        /// </summary>
        /// <value>The own attacks.</value>
        public int OwnAttacks
        {
            get { return GetMovementCount(TroopMovementType.AttackOutgoing); }
        }

        /// <summary>
        /// Gets the production of the village.
        /// </summary>
        /// <value>The production.</value>
        public Production Production
        {
            get { return production; }
        }

        /// <summary>
        /// Gets the troop movement.
        /// </summary>
        /// <value>The troop movement.</value>
        public IEnumerable<TroopMovement> TroopMovement
        {
            get
            {
                troopMovement.Sort(new TroopMovementComparer());
                return troopMovement;
            }
        }

        /// <summary>
        /// Gets the troop movement count.
        /// </summary>
        /// <value>The troop movement count.</value>
        public int TroopMovementCount
        {
            get { return troopMovement.Count; }
        }

        /// <summary>
        /// Gets the available troops in village.
        /// </summary>
        /// <value>The troops available.</value>
        public Troops TroopsAvailable
        {
            get { return troopsAvailable; }
        }

        /// <summary>
        /// Adds the id of the village.
        /// </summary>
        /// <param name="villageId">The id.</param>
        /// <returns></returns>
        public Village AddId(int villageId)
        {
            Id = villageId;
            return this;
        }

        /// <summary>
        /// Adds the name of the village.
        /// </summary>
        /// <param name="villageName">The name.</param>
        /// <returns></returns>
        public Village AddName(string villageName)
        {
            Name = villageName;
            return this;
        }

        /// <summary>
        /// Updates the troops movement in village.
        /// </summary>
        /// <param name="troops">The troops.</param>
        /// <returns></returns>
        public Village AddTroopsMovement(TroopMovement troops)
        {
            troopMovement.Add(troops);
            return this;
        }

        /// <summary>
        /// Clears the troop movements list.
        /// </summary>
        /// <returns></returns>
        public Village ClearTroopMovementsList()
        {
            troopMovement.Clear();
            return this;
        }

        /// <summary>
        /// Sets the troop movements.
        /// </summary>
        /// <param name="movements">The movements.</param>
        /// <returns></returns>
        public Village SetTroopMovements(List<TroopMovement> movements)
        {
            ClearTroopMovementsList();
            troopMovement = movements;
            return this;
        }

        /// <summary>
        /// Updates the village coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns></returns>
        public Village UpdateCoordinates(int x, int y)
        {
            CoordinateX = x;
            CoordinateY = y;
            return this;
        }

        /// <summary>
        /// Updates the production in village.
        /// </summary>
        /// <param name="villageProduction">The village production.</param>
        /// <returns></returns>
        public Village UpdateProduction(Production villageProduction)
        {
            production = villageProduction;
            return this;
        }

        /// <summary>
        /// Updates the troops in village.
        /// </summary>
        /// <param name="troops">The troops.</param>
        /// <returns></returns>
        public Village UpdateTroopsInVillage(Troops troops)
        {
            troopsAvailable = troops;
            return this;
        }

        private int GetMovementCount(TroopMovementType movementType)
        {
            int count = 0;
            foreach (TroopMovement movement in troopMovement)
            {
                if (movement.Type == movementType)
                {
                    count++;
                }
            }
            return count;
        }

        public override string ToString()
        {
            return string.Format(Name);
        }

        private Production production;
        private List<TroopMovement> troopMovement = new List<TroopMovement>();
        private Troops troopsAvailable;
    }
}