using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineBanking.Data.ViewModels.AuthenticationViewModels
{
    public class RegisterViewModel
    {
        public int CustomerAccNo { get; set; }

        [Required( ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Middle Name(s) are required")]
        public string Middlenames { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Postcode is required")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(int.MaxValue, ErrorMessage = "Password must be at least 8 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(int.MaxValue, ErrorMessage = "Password must be at least 8 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
