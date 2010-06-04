using System;

namespace jeza.Travian.Framework
{
    public class Report
    {
        public string SubjectText { get; set; }
        public string Url { get; set; }
        public string DateText { get; set; }
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }

        public string AttackerName { get; set; }
        public string AttackerVillage { get; set; }
        public string AttackerUrl { get; set; }

        private string carryText;
        public string CarryText
        {
            get { return carryText; }
            set
            {
                carryText = value;
                string[] split = carryText.Split('/');
                CarryTotal = Misc.String2Number(split[1].Trim());
                CarryAmount = Misc.String2Number(split[0].Trim());
            }
        }

        public int CarryTotal { get; set; }
        public int CarryAmount { get; set; }
        
        private string resourcesText;
        public string ResourcesText
        {
            get { return resourcesText; }
            set
            {
                resourcesText = value;
                string[] split = resourcesText.Split('|');
                ResourcesWood = Misc.String2Number(split[0].Trim());
                ResourcesClay = Misc.String2Number(split[1].Trim());
                ResourcesIron = Misc.String2Number(split[2].Trim());
                ResourcesCrop = Misc.String2Number(split[3].Trim());
            }
        }

        public int ResourcesWood { get; set; }
        public int ResourcesClay { get; set; }
        public int ResourcesIron { get; set; }
        public int ResourcesCrop { get; set; }
    }
}