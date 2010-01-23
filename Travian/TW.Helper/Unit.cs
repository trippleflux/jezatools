namespace TW.Helper
{
    public class Unit
    {
        public Unit(string name)
        {
            Name = name;
        }

        public Unit(string name, string className)
        {
            Name = name;
            Class = className;
        }

        public Unit AddTextBoxName(string name)
        {
            TextBoxName = name;
            return this;
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string TextBoxName { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
    }
}