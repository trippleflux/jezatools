namespace jeza.Item.Tracker
{
    public struct Order
    {
        public int Id { get; set; }
        public Item ItemId { get; set; }
        public int Count { get; set; }
        public float PriceGross { get; set; }
        public float PriceNeto { get; set; }
        public float Postage { get; set; }
        public ItemStatus ItemStatus { get; set; }
        public Subscriber SubscriberId { get; set; }
    }
}