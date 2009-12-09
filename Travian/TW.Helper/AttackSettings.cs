namespace TW.Helper
{
    public class AttackSettings
    {
        public AttackSettings(int destinationVillage,
                              AttackType attackType,
                              string troopName,
                              string troopCount)
        {
            DestinationVillage = destinationVillage;
            AttackType = attackType;
            TroopName = troopName;
            TroopCount = troopCount;
        }

        public int DestinationVillage { get; set; }
        public AttackType AttackType { get; set; }
        public string AttackType2String
        {
            get { return AttackTypeToString(); }
        }
        public string TroopName { get; set; }
        public string TroopCount { get; set; }

        private string AttackTypeToString()
        {
            string attackType;
            switch(AttackType)
            {
                case AttackType.Normal:
                {
                    attackType = "3";
                    break;
                }
                case AttackType.Raid:
                {
                    attackType = "4";
                    break;
                }
                default:
                {
                    attackType = "2";
                    break;
                }
            }
            return attackType;
        }
    }
}