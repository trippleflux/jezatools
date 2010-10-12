using System.Collections.Generic;

namespace TW.Helper
{
    public class TroopList
    {
        public TroopList()
        {
        }

        public TroopList(string troopClass,
                         int count)
        {
            TroopClass = troopClass.Trim();
            Count = count;
        }

        public string TroopClass { get; set; }
        public int Count { get; set; }
        public IList<TroopList> TroopsForVillage
        {
            get { return availableTroops; }
        }

        public void AddTroop(TroopList troops)
        {
            if (!availableTroops.Contains(troops))
            {
                availableTroops.Add(troops);
            }
        }

        private readonly List<TroopList> availableTroops = new List<TroopList>();
    }
}