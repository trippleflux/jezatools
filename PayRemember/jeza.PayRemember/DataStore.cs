using System.Collections.Generic;

namespace jeza.PayRemember
{
    public class DataStore
    {
        private List<Transaction> transactions = new List<Transaction>();
        private List<Recipient> recipients = new List<Recipient>();
        private List<Account> senders = new List<Account>();
    }
}