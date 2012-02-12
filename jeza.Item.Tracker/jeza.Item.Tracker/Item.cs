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
        public string ItemTypeName { get; set; }
        public decimal Price { get; set; }

        public string Format()
        {
            return string.Format(
                "[Id: {0}, ItemType: [{1}]-{6}, Name: {2}, Description: {3}, Price: {7}, Image: {4}, ImageLocation: {5}]", Id, ItemTypeId,
                Name, Description, Image, ImageLocation, ItemTypeName, Price);
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}