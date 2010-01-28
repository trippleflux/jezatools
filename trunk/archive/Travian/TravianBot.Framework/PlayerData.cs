namespace TravianBot.Framework
{
    public class PlayerData
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public int Rang { get; set; }
        public int Population { get; set; }
        public int VillageCount { get; set; }
        public int AttackRang { get; set; }
        public int AttackPoints { get; set; }
        public int DefenseRang { get; set; }
        public int DefensePoints { get; set; }
        public string Aliance { get; set; }

        public override string ToString()
        {
            return string.Format("Number: {0}, Name: {1}, Aliance: {9}, Rang: {2}, Population: {3}, VillageCount: {4}, AttackRang: {5}, AttackPoints: {6}, DefenseRang: {7}, DefensePoints: {8}", Number, Name, Rang, Population, VillageCount, AttackRang, AttackPoints, DefenseRang, DefensePoints, Aliance);
        }
    }
}