namespace twL
{
    public class Attacks
    {
        public string FileExtensionForAttacks { get; set; }
        public string FileExtensionForFinishedAttacks { get; set; }
        public string TroopList { get; set; }
        public string FileForAttacks { get; set; }
        public string FileForFinishedAttacks { get; set; }


        public override string ToString()
        {
            return
                string.Format(
                    "Attacks: [FileExtensionForAttacks: {0}, FileExtensionForFinishedAttacks: {1}, TroopList: {2}, FileForAttacks: {3}, FileForFinishedAttacks: {4}]",
                    FileExtensionForAttacks, FileExtensionForFinishedAttacks, TroopList, FileForAttacks,
                    FileForFinishedAttacks);
        }
    }
}