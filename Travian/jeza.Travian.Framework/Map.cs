#region

using System.Collections.Generic;

#endregion

namespace jeza.Travian.Framework
{
    public class Map
    {
        public List<Neighborhood> Neighborhood
        {
            get { return neighborhood; }
        }

        /// <summary>
        /// Adds the villageto the list.
        /// </summary>
        /// <param name="village">The village.</param>
        public void AddVillage(Neighborhood village)
        {
            neighborhood.Add(village);
        }

        private readonly List<Neighborhood> neighborhood = new List<Neighborhood>();
    }
}