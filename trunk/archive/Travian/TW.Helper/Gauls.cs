namespace TW.Helper
{
    public class Gauls : TribesBase
    {
        public Gauls()
        {
            Units.Add(Phalanx);
            Units.Add(Swordsman);
            Units.Add(Pathfinder);
            Units.Add(TheutatesThunder);
            Units.Add(Druidrider);
            Units.Add(Haeduan);
            Units.Add(Ram);
            Units.Add(Trebuchet);
            Units.Add(Chieftain);
            Units.Add(Settler);
            Units.Add(Hero);
        }

        public Unit Phalanx = new Unit("Phalanx", "unit u21").AddTextBoxName("t1");
        public Unit Swordsman = new Unit("Swordsman", "unit u22").AddTextBoxName("t2");
        public Unit Pathfinder = new Unit("Pathfinder", "unit u23").AddTextBoxName("t3");
        public Unit TheutatesThunder = new Unit("TheutatesThunder", "unit u24").AddTextBoxName("t4");
        public Unit Druidrider = new Unit("Druidrider", "unit u25").AddTextBoxName("t5");
        public Unit Haeduan = new Unit("Haeduan", "unit u26").AddTextBoxName("t6");
        public Unit Ram = new Unit("Ram", "unit u27").AddTextBoxName("t7");
        public Unit Trebuchet = new Unit("Trebuchet", "unit u28").AddTextBoxName("t8");
        public Unit Chieftain = new Unit("Chieftain", "unit u29").AddTextBoxName("t9");
        public Unit Settler = new Unit("Settler", "unit u30").AddTextBoxName("t10");
        public Unit Hero = new Unit("Hero", "unit uhero").AddTextBoxName("t11");
    }
}