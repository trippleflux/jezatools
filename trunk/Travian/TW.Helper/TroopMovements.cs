using System;

namespace TW.Helper
{
    public class TroopMovements
    {
        public TroopMovements()
        {
        }

        public TroopMovements(TroopMovementType type)
        {
            Type = type;
        }

        public TroopMovementType Type{ get; set;}
        public int Number { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {3}, Number: {1}, ArrivalTime: {2}, Type: {0}", Type, Number, ArrivalTime, Name);
        }
    }
}