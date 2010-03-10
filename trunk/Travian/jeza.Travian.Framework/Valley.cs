using System;
using System.Globalization;

namespace jeza.Travian.Framework
{
    public class Valley
    {
        public string Alliance { get; set; }
        public string AllianceUrl { get; set; }
        public string Player { get; set; }
        public string PlayerUrl { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string VillageUrl { get; set; }
        public ValleyType ValleyType { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public string Coordinates
        {
            get { return String.Format(CultureInfo.InvariantCulture, "({0}|{1})", X, Y); }
            set { Coordinates = value; }
        }

        public int AllianceId
        {
            //allianz.php?aid=0
            get { return Misc.String2Number(AllianceUrl.Substring(16)); }
            set { AllianceId = value; }
        }

        public int UserId
        {
            //spieler.php?uid=11436
            get { return Misc.String2Number(PlayerUrl.Substring(16)); }
            set { UserId = value; }
        }

        public int VillageId
        {
            get { return Misc.ConvertCoordinates(X, Y); }
            set { VillageId = value; }
        }

        /// <summary>
        /// Adds the alliance data.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public Valley AddAlliance(string name, string url)
        {
            Alliance = name;
            AllianceUrl = url;
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
            X = xCoords;
            Y = yCoords;
            return this;
        }

        /// <summary>
        /// Adds the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Valley AddName(string name)
        {
            Name = name;
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
            Player = name;
            PlayerUrl = url;
            return this;
        }

        /// <summary>
        /// Adds the population.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public Valley AddPopulation(int count)
        {
            Population = count;
            return this;
        }

        /// <summary>
        /// Adds the URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public Valley AddUrl(string url)
        {
            VillageUrl = url;
            return this;
        }

        /// <summary>
        /// Adds the type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public Valley AddType(ValleyType type)
        {
            ValleyType = type;
            return this;
        }
    }
}