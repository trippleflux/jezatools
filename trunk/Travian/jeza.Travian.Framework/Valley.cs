namespace jeza.Travian.Framework
{
    public class Valley
    {
        public string AllianceName
        {
            get { return allianceName; }
        }

        public string AllianceUrl
        {
            get { return allianceUrl; }
        }

        public string PlayerName
        {
            get { return playerName; }
        }

        public string PlayerUrl
        {
            get { return playerUrl; }
        }

        public string VillageName
        {
            get { return villageName; }
        }

        public int VillagePopulation
        {
            get { return villagePopulation; }
        }

        public string VillageUrl
        {
            get { return villageUrl; }
        }

        public ValleyType ValleyType
        {
            get { return valleyType; }
            set { valleyType = value; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        /// <summary>
        /// Adds the alliance data.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public Valley AddAlliance(string name, string url)
        {
            allianceName = name;
            allianceUrl = url;
            return this;
        }

        /// <summary>
        /// Adds the coordinates of the village.
        /// </summary>
        /// <param name="xCoords">The x.</param>
        /// <param name="yCoords">The y.</param>
        /// <returns></returns>
        public Valley AddCoordinates(int xCoords, int yCoords)
        {
            x = xCoords;
            y = yCoords;
            return this;
        }

        /// <summary>
        /// Adds the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Valley AddName(string name)
        {
            villageName = name;
            return this;
        }

        /// <summary>
        /// Adds the name of the player.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="url">The url to profile.</param>
        /// <returns></returns>
        public Valley AddPlayer(string name, string url)
        {
            playerName = name;
            playerUrl = url;
            return this;
        }

        /// <summary>
        /// Adds the population.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public Valley AddPopulation(int count)
        {
            villagePopulation = count;
            return this;
        }

        /// <summary>
        /// Adds the URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public Valley AddUrl(string url)
        {
            villageUrl = url;
            return this;
        }

        /// <summary>
        /// Adds the type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public Valley AddType(ValleyType type)
        {
            valleyType = type;
            return this;
        }

        private string allianceName;
        private string allianceUrl;
        private string playerName;
        private string playerUrl;
        private ValleyType valleyType;
        private string villageName;
        private int villagePopulation;
        private string villageUrl;
        private int x;
        private int y;
    }
}