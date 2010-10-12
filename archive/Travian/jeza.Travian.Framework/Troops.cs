#region

using System.Collections.Generic;
using System.Text;

#endregion

namespace jeza.Travian.Framework
{
    public class Troops
    {
        /// <summary>
        /// Gets the troop list.
        /// </summary>
        /// <value>The troops1.</value>
        public List<TroopUnit> TroopsList
        {
            get { return troopList; }
        }

        /// <summary>
        /// Adds the troop to the list.
        /// </summary>
        /// <param name="troopUnit">The troop unit.</param>
        /// <returns></returns>
        public Troops AddTroopUnit(TroopUnit troopUnit)
        {
            if (!troopList.Contains(troopUnit))
            {
                troopList.Add(troopUnit);
            }
            return this;
        }

        /// <summary>
        /// Gets the troop count for the unit.
        /// </summary>
        /// <param name="classAttribute">The class attribute.</param>
        /// <returns></returns>
        public int GetTroopCount(string classAttribute)
        {
            foreach (TroopUnit troopUnit in troopList)
            {
                if (troopUnit.ClassAttribute.Equals(classAttribute))
                {
                    return troopUnit.Count;
                }
            }
            return 0;
        }

        /// <summary>
        /// Gets the troop info for specified class attribute.
        /// </summary>
        /// <param name="classAttribute">The class attribute.</param>
        /// <returns><c>null</c> if not found.</returns>
        public TroopUnit GetTroopInfo(string classAttribute)
        {
            foreach (TroopUnit troopUnit in troopList)
            {
                if (troopUnit.ClassAttribute.Equals(classAttribute))
                {
                    return troopUnit;
                }
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (TroopUnit troopUnit in troopList)
            {
                sb.AppendFormat("{0} ", troopUnit.Count);
            }
            return sb.ToString();
        }

        private readonly List<TroopUnit> troopList = new List<TroopUnit>();
    }
}