using System.ComponentModel.DataAnnotations;

namespace OnlineBanking.Data.ViewModels.AuthenticationViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Account number is required")]
        public int AccountNumber { get; set; }

        [Required(ErrorMessage = "Account password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
