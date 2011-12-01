namespace jeza.Item.Tracker
{
    public class Item
    {
        public int Id { get; set; }
        public int ItemTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string ImageLocation { get; set; }

        public string FormatItem()
        {
            return string.Format(
                "[Id: {0}, ItemTypeId: {1}, Name: {2}, Description: {3}, Image: {4}, ImageLocation: {5}]", Id, ItemTypeId,
                Name, Description, Image, ImageLocation);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Description);
        }
    }
}