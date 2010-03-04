#region

using System;
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

        /// <summary>
        /// Adds the villages.
        /// </summary>
        /// <param name="neighborhoods">The neighborhoods.</param>
        public void AddVillages(List<Neighborhood> neighborhoods)
        {
            neighborhood.AddRange(neighborhoods);
        }

        private readonly List<Neighborhood> neighborhood = new List<Neighborhood>();
    }
}