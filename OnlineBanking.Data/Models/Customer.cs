using System;

namespace OnlineBanking.Data.Models
{
    public class Customer
    {
        public int CustomerAccNo { get; set; }
        public string Firstname { get; set; }
        public string MiddleNames { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
    }
}
