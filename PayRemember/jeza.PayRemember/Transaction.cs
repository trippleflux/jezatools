using System;

namespace jeza.PayRemember
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Recipient Recipient { get; set; }
        public Price Price { get; set; }
        public Account Sender { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}