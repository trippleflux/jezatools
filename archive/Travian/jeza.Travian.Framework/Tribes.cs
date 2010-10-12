using System.Collections.Generic;

namespace jeza.Travian.Framework
{
    public class Tribes
    {
        public Tribes()
        {
            troops.AddRange(new Gauls().Troops);
            troops.AddRange(new Romans().Troops);
            troops.AddRange(new Teutons().Troops);
        }

        /// <summary>
        /// Gets the unit info by it's class name.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns><see cref="TroopUnit"/> or <c>null</c> if not found.</returns>
        public TroopUnit GetUnit(string className)
        {
            foreach (TroopUnit troopUnit in troops)
            {
                if (troopUnit.ClassAttribute.ToLower().Equals(className.ToLower()))
                {
                    return troopUnit;
                }
            }
            return null;
        }
        private readonly List<TroopUnit> troops = new List<TroopUnit>();
    }
}