#region

using System.Collections.Generic;

#endregion

namespace jeza.Travian.Framework
{
    public class TroopMovementComparer : IComparer<TroopMovement>
    {
        private static int Compare(TroopMovement x, TroopMovement y)
        {
            return x.DateTime.CompareTo(y.DateTime);
        }

        public int Compare(object x, object y)
        {
            return Compare((TroopMovement) x, (TroopMovement) y);
        }

        int IComparer<TroopMovement>.Compare(TroopMovement x, TroopMovement y)
        {
            return Compare(x, y);
        }
    }
}