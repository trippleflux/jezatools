#region

using System.Collections.Generic;

#endregion

namespace jeza.Travian.Framework
{
    public class Village
    {
        /// <summary>
        /// Gets the coordinate X.
        /// </summary>
        /// <value>The coordinate X.</value>
        public int CoordinateX
        {
            get { return coordinateX; }
        }

        /// <summary>
        /// Gets the coordinate Y.
        /// </summary>
        /// <value>The coordinate Y.</value>
        public int CoordinateY
        {
            get { return coordinateY; }
        }

        /// <summary>
        /// Gets the id of the village.
        /// </summary>
        /// <value>The id.</value>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Gets the name of the village.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return name; }
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
            id = villageId;
            return this;
        }

        /// <summary>
        /// Adds the name of the village.
        /// </summary>
        /// <param name="villageName">The name.</param>
        /// <returns></returns>
        public Village AddName(string villageName)
        {
            name = villageName;
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
            coordinateX = x;
            coordinateY = y;
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

        private int id;
        private string name;
        private Production production;
        private int coordinateX;
        private int coordinateY;
        private List<TroopMovement> troopMovement = new List<TroopMovement>();
        private Troops troopsAvailable;
    }
}