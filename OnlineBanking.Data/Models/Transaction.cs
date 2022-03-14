using System;

namespace OnlineBanking.Data.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
