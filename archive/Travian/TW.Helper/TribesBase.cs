using System.Collections.Generic;
using System.Text;

namespace TW.Helper
{
    public class TribesBase
    {
        protected readonly List<Unit> Units = new List<Unit>();

        public string GetClassNames(string[] list)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Unit unit in Units)
            {
                foreach (string name in list)
                {
                    if (name.ToLowerInvariant().Equals(unit.Name.ToLowerInvariant()))
                    {
                        stringBuilder.Append(unit.Class).Append(",");
                    }
                }
            }
            return stringBuilder.ToString();
        }

        public string GetTextBoxName(string troopName)
        {
            foreach (Unit unit in Units)
            {
                if ((unit.Name == troopName) || (unit.Class == troopName))
                {
                    return unit.TextBoxName;
                }
            }
            return "t1";
        }

        public string UnitList()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Unit unit in Units)
            {
                stringBuilder.Append(unit.Name).Append(",");
            }
            return stringBuilder.ToString();
        }
    }
}