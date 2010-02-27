#region

using System.Collections.Generic;

#endregion

namespace jeza.Travian.Framework
{
    public class Gauls : ITribe
    {
        public Gauls()
        {
            phalanx = new TroopUnit().AddName("Phalanx").AddHtmlClassName("unit u21").AddSendTroopTextBoxName("t1");
            swordsman = new TroopUnit().AddName("Swordsman").AddHtmlClassName("unit u22").AddSendTroopTextBoxName("t2");
            pathfinder = new TroopUnit().AddName("Pathfinder").AddHtmlClassName("unit u23").AddSendTroopTextBoxName("t3");
            theutatesThunder =
                new TroopUnit().AddName("Theutates Thunder").AddHtmlClassName("unit u24").AddSendTroopTextBoxName("t4");
            druidrider = new TroopUnit().AddName("Druidrider").AddHtmlClassName("unit u25").AddSendTroopTextBoxName("t5");
            haeduan = new TroopUnit().AddName("Haeduan").AddHtmlClassName("unit u26").AddSendTroopTextBoxName("t6");
            ram = new TroopUnit().AddName("Ram").AddHtmlClassName("unit u27").AddSendTroopTextBoxName("t7");
            trebuchet = new TroopUnit().AddName("Trebuchet").AddHtmlClassName("unit u28").AddSendTroopTextBoxName("t8");
            chieftain = new TroopUnit().AddName("Chieftain").AddHtmlClassName("unit u29").AddSendTroopTextBoxName("t9");
            settler = new TroopUnit().AddName("Settler").AddHtmlClassName("unit u30").AddSendTroopTextBoxName("t10");
            hero = new TroopUnit().AddName("Hero").AddHtmlClassName("unit uhero").AddSendTroopTextBoxName("t11");
            troops.Add(phalanx);
            troops.Add(swordsman);
            troops.Add(pathfinder);
            troops.Add(theutatesThunder);
            troops.Add(druidrider);
            troops.Add(haeduan);
            troops.Add(ram);
            troops.Add(trebuchet);
            troops.Add(chieftain);
            troops.Add(settler);
        }

        public List<TroopUnit> Troops
        {
            get { return troops; }
        }

        public TroopUnit Phalanx
        {
            get { return phalanx; }
        }

        public TroopUnit Swordsman
        {
            get { return swordsman; }
        }

        public TroopUnit Pathfinder
        {
            get { return pathfinder; }
        }

        public TroopUnit TheutatesThunder
        {
            get { return theutatesThunder; }
        }

        public TroopUnit Druidrider
        {
            get { return druidrider; }
        }

        public TroopUnit Haeduan
        {
            get { return haeduan; }
        }

        public TroopUnit Ram
        {
            get { return ram; }
        }

        public TroopUnit Trebuchet
        {
            get { return trebuchet; }
        }

        public TroopUnit Chieftain
        {
            get { return chieftain; }
        }

        public TroopUnit Settler
        {
            get { return settler; }
        }

        public TroopUnit Hero
        {
            get { return hero; }
        }

        private readonly TroopUnit phalanx;
        private readonly TroopUnit swordsman;
        private readonly TroopUnit pathfinder;
        private readonly TroopUnit theutatesThunder;
        private readonly TroopUnit druidrider;
        private readonly TroopUnit haeduan;
        private readonly TroopUnit ram;
        private readonly TroopUnit trebuchet;
        private readonly TroopUnit chieftain;
        private readonly TroopUnit settler;
        private readonly TroopUnit hero;
        private readonly List<TroopUnit> troops = new List<TroopUnit>();
    }
}