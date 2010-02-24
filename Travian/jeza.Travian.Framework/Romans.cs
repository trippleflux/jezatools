namespace jeza.Travian.Framework
{
    public class Romans
    {
        public Romans()
        {
            legionnaire =
                new TroopUnit().AddName("Legionnaire").AddHtmlClassName("unit u1").AddSendTroopTextBoxName("t1");
            praetorian = new TroopUnit().AddName("Praetorian").AddHtmlClassName("unit u2").AddSendTroopTextBoxName("t2");
            imperian = new TroopUnit().AddName("Imperian").AddHtmlClassName("unit u3").AddSendTroopTextBoxName("t3");
            equitesLegati =
                new TroopUnit().AddName("Equites Legati").AddHtmlClassName("unit u4").AddSendTroopTextBoxName("t4");
            equitesImperatoris =
                new TroopUnit().AddName("Equites Imperatoris").AddHtmlClassName("unit u5").AddSendTroopTextBoxName("t5");
            equitesCaesaris =
                new TroopUnit().AddName("Equites Caesaris").AddHtmlClassName("unit u6").AddSendTroopTextBoxName("t6");
            batteringRam =
                new TroopUnit().AddName("RaBattering Ram").AddHtmlClassName("unit u7").AddSendTroopTextBoxName("t7");
            fireCatapult =
                new TroopUnit().AddName("Fire Catapult").AddHtmlClassName("unit u8").AddSendTroopTextBoxName("t8");
            senator = new TroopUnit().AddName("Senator").AddHtmlClassName("unit u9").AddSendTroopTextBoxName("t9");
            settler = new TroopUnit().AddName("Settler").AddHtmlClassName("unit u10").AddSendTroopTextBoxName("t10");
            hero = new TroopUnit().AddName("Hero").AddHtmlClassName("unit uhero").AddSendTroopTextBoxName("t11");
        }

        public TroopUnit Legionnaire
        {
            get { return legionnaire; }
        }

        public TroopUnit Praetorian
        {
            get { return praetorian; }
        }

        public TroopUnit Imperian
        {
            get { return imperian; }
        }

        public TroopUnit EquitesLegati
        {
            get { return equitesLegati; }
        }

        public TroopUnit EquitesImperatoris
        {
            get { return equitesImperatoris; }
        }

        public TroopUnit EquitesCaesaris
        {
            get { return equitesCaesaris; }
        }

        public TroopUnit BatteringRam
        {
            get { return batteringRam; }
        }

        public TroopUnit FireCatapult
        {
            get { return fireCatapult; }
        }

        public TroopUnit Senator
        {
            get { return senator; }
        }

        public TroopUnit Settler
        {
            get { return settler; }
        }

        public TroopUnit Hero
        {
            get { return hero; }
        }

        private readonly TroopUnit legionnaire;
        private readonly TroopUnit praetorian;
        private readonly TroopUnit imperian;
        private readonly TroopUnit equitesLegati;
        private readonly TroopUnit equitesImperatoris;
        private readonly TroopUnit equitesCaesaris;
        private readonly TroopUnit batteringRam;
        private readonly TroopUnit fireCatapult;
        private readonly TroopUnit senator;
        private readonly TroopUnit settler;
        private readonly TroopUnit hero;
    }
}