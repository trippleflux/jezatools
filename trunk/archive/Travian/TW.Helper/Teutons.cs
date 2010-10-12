#region



#endregion

namespace TW.Helper
{
    public class Teutons : TribesBase
    {
        public Teutons()
        {
            Units.Add(Clubswinger);
            Units.Add(Spearman);
            Units.Add(Axeman);
            Units.Add(Scout);
            Units.Add(Paladin);
            Units.Add(TeutonicKnight);
            Units.Add(Ram);
            Units.Add(Catapult);
            Units.Add(Chief);
            Units.Add(Settler);
            Units.Add(Hero);
        }

        public Unit Clubswinger = new Unit("Clubswinger", "unit u11").AddTextBoxName("t1");
        public Unit Spearman = new Unit("Spearman", "unit u12").AddTextBoxName("t2");
        public Unit Axeman = new Unit("Axeman", "unit u13").AddTextBoxName("t3");
        public Unit Scout = new Unit("Scout", "unit u14").AddTextBoxName("t4");
        public Unit Paladin = new Unit("Paladin", "unit u15").AddTextBoxName("t5");
        public Unit TeutonicKnight = new Unit("TeutonicKnight", "unit u16").AddTextBoxName("t6");
        public Unit Ram = new Unit("Ram", "unit u17").AddTextBoxName("t7");
        public Unit Catapult = new Unit("Catapult", "unit u18").AddTextBoxName("t8");
        public Unit Chief = new Unit("Chief", "unit u19").AddTextBoxName("t9");
        public Unit Settler = new Unit("Settler", "unit u20").AddTextBoxName("t10");
        public Unit Hero = new Unit("Hero", "unit uhero").AddTextBoxName("t11");
    }
}