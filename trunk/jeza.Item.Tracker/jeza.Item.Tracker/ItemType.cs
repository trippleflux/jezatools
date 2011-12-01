namespace jeza.Item.Tracker
{
    public class ItemType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        public string FormatItem()
        {
            return string.Format("[Id: {0}, Name: {1}, Description: {2}]", Id, Name, Description);
        }
    }
}