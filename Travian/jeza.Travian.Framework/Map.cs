#region

using System.Collections.Generic;

#endregion

namespace jeza.Travian.Framework
{
    public class Map
    {
        public List<Valley> Valleys
        {
            get { return valleys; }
        }

        /// <summary>
        /// Adds the villageto the list.
        /// </summary>
        /// <param name="valley">The valley.</param>
        public void AddVillage(Valley valley)
        {
            valleys.Add(valley);
        }

        /// <summary>
        /// Adds the villages.
        /// </summary>
        /// <param name="valleyList">The valleyList.</param>
        public void AddVillages(List<Valley> valleyList)
        {
            valleys.AddRange(valleyList);
        }

        private readonly List<Valley> valleys = new List<Valley>();
    }
}