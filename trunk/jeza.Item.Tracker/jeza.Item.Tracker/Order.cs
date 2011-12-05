namespace jeza.Item.Tracker
{
    public class Order
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public string Price { get; set; }
        public string Postage { get; set; }
        public int ItemStatusId { get; set; }
        public int PersonInfoId { get; set; }
        public bool LegalEntity { get; set; }
        public string DateTime { get; set; }
        public string Tax { get; set; }

        public string Format()
        {
            return
                string.Format(
                    "[Id: {0}, ItemId: {1}, Count: {2}, Price: {3}, Postage: {4}, ItemStatusId: {5}, PersonInfoId: {6}, LegalEntity: {7}, DateTime: {8}, Tax: {9}]",
                    Id, ItemId, Count, Price, Postage, ItemStatusId, PersonInfoId, LegalEntity, DateTime, Tax);
        }

        public override string ToString()
        {
            return
                string.Format(
                    "PersonInfoId: {0}, Id: {1}, ItemId: {2}, Count: {3}, Price: {4}, ItemStatusId: {5}, Postage: {6}, Tax: {7}",
                    PersonInfoId, Id, ItemId, Count, Price, ItemStatusId, Postage, Tax);
        }
    }
}