namespace jeza.Item.Tracker
{
    public class Item
    {
        public int Id { get; set; }
        public ItemType ItemType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string ImageLocation { get; set; }
    }
}