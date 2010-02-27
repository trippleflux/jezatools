#region

using System.Collections.Generic;

#endregion

namespace jeza.Travian.Framework
{
    public class Teutons : ITribe
    {
        public Teutons()
        {
            clubswinger =
                new TroopUnit().AddName("Clubswinger").AddHtmlClassName("unit u11").AddSendTroopTextBoxName("t1");
            spearman = new TroopUnit().AddName("Spearman").AddHtmlClassName("unit u12").AddSendTroopTextBoxName("t2");
            axeman = new TroopUnit().AddName("Axeman").AddHtmlClassName("unit u13").AddSendTroopTextBoxName("t3");
            scout = new TroopUnit().AddName("Scout").AddHtmlClassName("unit u14").AddSendTroopTextBoxName("t4");
            paladin = new TroopUnit().AddName("Paladin").AddHtmlClassName("unit u15").AddSendTroopTextBoxName("t5");
            teutonicKnight =
                new TroopUnit().AddName("TeutonicKnight").AddHtmlClassName("unit u16").AddSendTroopTextBoxName("t6");
            ram = new TroopUnit().AddName("Ram").AddHtmlClassName("unit u17").AddSendTroopTextBoxName("t7");
            catapult = new TroopUnit().AddName("Catapult").AddHtmlClassName("unit u18").AddSendTroopTextBoxName("t8");
            chief = new TroopUnit().AddName("Chief").AddHtmlClassName("unit u19").AddSendTroopTextBoxName("t9");
            settler = new TroopUnit().AddName("Settler").AddHtmlClassName("unit u20").AddSendTroopTextBoxName("t10");
            hero = new TroopUnit().AddName("Hero").AddHtmlClassName("unit uhero").AddSendTroopTextBoxName("t11");
            troops.Add(clubswinger);
            troops.Add(spearman);
            troops.Add(axeman);
            troops.Add(scout);
            troops.Add(paladin);
            troops.Add(teutonicKnight);
            troops.Add(ram);
            troops.Add(catapult);
            troops.Add(chief);
            troops.Add(settler);
        }

        public TroopUnit Clubswinger
        {
            get { return clubswinger; }
        }

        public TroopUnit Spearman
        {
            get { return spearman; }
        }

        public TroopUnit Axeman
        {
            get { return axeman; }
        }

        public TroopUnit Scout
        {
            get { return scout; }
        }

        public TroopUnit Paladin
        {
            get { return paladin; }
        }

        public TroopUnit TeutonicKnight
        {
            get { return teutonicKnight; }
        }

        public TroopUnit Ram
        {
            get { return ram; }
        }

        public TroopUnit Catapult
        {
            get { return catapult; }
        }

        public TroopUnit Chief
        {
            get { return chief; }
        }

        public TroopUnit Settler
        {
            get { return settler; }
        }

        public TroopUnit Hero
        {
            get { return hero; }
        }

        public IEnumerable<TroopUnit> Troops
        {
            get { return troops; }
        }

        private readonly TroopUnit clubswinger;
        private readonly TroopUnit spearman;
        private readonly TroopUnit axeman;
        private readonly TroopUnit scout;
        private readonly TroopUnit paladin;
        private readonly TroopUnit teutonicKnight;
        private readonly TroopUnit ram;
        private readonly TroopUnit catapult;
        private readonly TroopUnit chief;
        private readonly TroopUnit settler;
        private readonly TroopUnit hero;
        private readonly List<TroopUnit> troops = new List<TroopUnit>();
    }
}