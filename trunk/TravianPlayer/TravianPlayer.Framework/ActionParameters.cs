namespace TravianPlayer.Framework
{
    public class ActionParameters
    {
        public int Id { get; set; }

        public int VillageId { get; set; }

        public int CoordX { get; set; }

        public int CoordY { get; set; }

        public int AttackType { get; set; }

        public int AttackUnit { get; set; }

        public int TroopCount { get; set; }

        public string Comment { get; set; }

    	public bool Enabled { get; set; }
    }
}