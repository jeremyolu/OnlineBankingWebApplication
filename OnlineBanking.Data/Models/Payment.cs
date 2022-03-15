using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineBanking.Data.Models
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public int PayeeAccountNo { get; set; }

        [Required( ErrorMessage = "Recipient name is required")]
        public string RecipientName { get; set; }

        [Required(ErrorMessage = "Recipient surname is required")]
        public string RecipientSurname { get; set; }

        [Required(ErrorMessage = "Recipient account is required")]
        public int RecipientAccountNo { get; set; }

        public string PaymentReference { get; set; }

        [Required(ErrorMessage = "Payment account is required")]
        [Range(1, 1000000, ErrorMessage = "Amount must be between £1 and £1000000")]
        public decimal PaymentAmount { get; set; }
    }
}
