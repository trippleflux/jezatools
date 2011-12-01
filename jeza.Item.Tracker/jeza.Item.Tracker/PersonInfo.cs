namespace jeza.Item.Tracker
{
    public class PersonInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int PostNumber { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string TelephoneMobile { get; set; }
        public string Fax { get; set; }

        public string Format()
        {
            return
                string.Format(
                    "[Id: {0}, Name: {1}, SurName: {2}, NickName: {3}, Description: {4}, Address: {5}, PostNumber: {6}, City: {7}, Email: {8}, Telephone: {9}, TelephoneMobile: {10}, Fax: {11}]",
                    Id, Name, SurName, NickName, Description, Address, PostNumber, City, Email, Telephone,
                    TelephoneMobile, Fax);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} ({2}) - {3}", Name, SurName, NickName, Description);
        }
    }
}