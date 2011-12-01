namespace jeza.Item.Tracker
{
    public struct Order
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public float Postage { get; set; }
        public int ItemStatusId { get; set; }
        public int PersonInfoId { get; set; }
        public bool LegalEntity { get; set; }
    }
}