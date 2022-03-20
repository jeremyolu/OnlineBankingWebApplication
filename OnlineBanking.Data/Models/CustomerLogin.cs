using System;

namespace OnlineBanking.Data.Models
{
    public class CustomerLogin
    {
        public Guid CustomerId { get; set; }
        public int CustomerNo { get; set; }
        public string Password { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public bool IsLockedOut { get; set; }
        public DateTime LockedOutDateTime { get; set; }
        public int LoginAttempts { get; set; }
    }
}
