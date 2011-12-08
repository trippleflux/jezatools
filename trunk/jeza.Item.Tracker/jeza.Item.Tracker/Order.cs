namespace jeza.Item.Tracker
{
    public class Order
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemText { get; set; }
        public int Count { get; set; }
        public string Price { get; set; }
        public string Postage { get; set; }
        public int ItemStatusId { get; set; }
        public int PersonInfoId { get; set; }
        public string PersonInfoText { get; set; }
        public bool LegalEntity { get; set; }
        public string DateTime { get; set; }
        public string Tax { get; set; }

        public string Format()
        {
            return
                string.Format(
                    "[Id: {0}, ItemId: {1}, ItemText: {10}, Count: {2}, Price: {3}, Postage: {4}, ItemStatusId: {5}, PersonInfoId: {6}, PersonInfoText: {11}, LegalEntity: {7}, DateTime: {8}, Tax: {9}]",
                    Id, ItemId, Count, Price, Postage, ItemStatusId, PersonInfoId, LegalEntity, DateTime, Tax, ItemText, PersonInfoText);
        }

        public override string ToString()
        {
            return
                string.Format("{0} / {1} / [Count:{2}] / [{3} {4}]", PersonInfoText, ItemText, Count, Price, System.Configuration.ConfigurationManager.AppSettings["defaultCurrency"]);
        }
    }
}