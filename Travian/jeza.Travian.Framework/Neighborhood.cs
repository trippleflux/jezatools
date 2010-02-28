namespace jeza.Travian.Framework
{
    public class Neighborhood
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
        public Neighborhood AddAlliance(string name, string url)
        {
            allianceName = name;
            allianceUrl = url;
            return this;
        }

        /// <summary>
        /// Adds the coordinates of the village.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Neighborhood AddCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
            return this;
        }

        /// <summary>
        /// Adds the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Neighborhood AddName(string name)
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
        public Neighborhood AddPlayer(string name, string url)
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
        public Neighborhood AddPopulation(int count)
        {
            villagePopulation = count;
            return this;
        }

        /// <summary>
        /// Adds the URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public Neighborhood AddUrl(string url)
        {
            villageUrl = url;
            return this;
        }

        private string allianceName;
        private string allianceUrl;
        private string playerName;
        private string playerUrl;
        private string villageName;
        private int villagePopulation;
        private string villageUrl;
        private int x;
        private int y;
    }
}