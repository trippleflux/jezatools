#region

using System;

#endregion

namespace TW.Helper
{
    public class Report
    {
        public Report
            (string id,
             string text)
        {
            Url = id;
            Text = text;
        }

        public string Url { get; set; }
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string AttackerName { get; set; }
        public int AttackerId { get; set; }
        public string AttackerVillageName { get; set; }
        public int AttackerVillageId { get; set; }
        public string DefenderName { get; set; }
        public int DefenderId { get; set; }
        public string DefenderVillageName { get; set; }
        public int DefenderVillageId { get; set; }
        public Tribes TribeAttacker { get; set; }
        public Tribes TribeDefender{ get; set; }
        public Tribes TribeReinforcements { get; set; }
        public int[] Troops { get; set; }
        public int[] Casualties { get; set; }
        public int[] Goods { get; set; }
        public int[] Prisoners { get; set; }
        public int[] TroopsDefender { get; set; }
        public int[] CasualtiesDefender { get; set; }

    }
}