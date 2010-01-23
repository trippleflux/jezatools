namespace TW.Helper
{
    public class Romans : TribesBase
    {
        public Romans()
        {
            Units.Add(Legionnaire);
            Units.Add(Praetorian);
            Units.Add(Imperian);
            Units.Add(EquitesLegati);
            Units.Add(EquitesImperatoris);
            Units.Add(EquitesCaesaris);
            Units.Add(BatteringRam);
            Units.Add(FireCatapult);
            Units.Add(Senator);
            Units.Add(Settler);
            Units.Add(Hero);
        }

        public Unit Legionnaire = new Unit("Legionnaire", "unit u1").AddTextBoxName("t1");
        public Unit Praetorian = new Unit("Praetorian", "unit u2").AddTextBoxName("t2");
        public Unit Imperian = new Unit("Imperian", "unit u3").AddTextBoxName("t3");
        public Unit EquitesLegati = new Unit("EquitesLegati", "unit u4").AddTextBoxName("t4");
        public Unit EquitesImperatoris = new Unit("EquitesImperatoris", "unit u5").AddTextBoxName("t5");
        public Unit EquitesCaesaris = new Unit("EquitesCaesaris", "unit u6").AddTextBoxName("t6");
        public Unit BatteringRam = new Unit("BatteringRam", "unit u7").AddTextBoxName("t7");
        public Unit FireCatapult = new Unit("FireCatapult", "unit u8").AddTextBoxName("t8");
        public Unit Senator = new Unit("Senator", "unit u9").AddTextBoxName("t9");
        public Unit Settler = new Unit("Settler", "unit u10").AddTextBoxName("t10");
        public Unit Hero = new Unit("Hero", "unit uhero").AddTextBoxName("t11");
    }
}