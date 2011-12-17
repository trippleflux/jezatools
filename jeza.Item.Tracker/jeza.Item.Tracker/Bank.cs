namespace jeza.Item.Tracker
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Owner { get; set; }

        public string Format()
        {
            return string.Format("Id: {0}, Name: {1}, AccountNumber: {2}, Owner: {3}", Id, Name, AccountNumber, Owner);
        }

        public override string ToString()
        {
            return string.Format("{0} - [{1}]", Name, Owner);
        }
    }
}