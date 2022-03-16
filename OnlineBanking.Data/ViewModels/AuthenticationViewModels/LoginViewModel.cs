using System.ComponentModel.DataAnnotations;

namespace OnlineBanking.Data.ViewModels.AuthenticationViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Customer number is required")]
        public int CustomerNo { get; set; }

        [Required(ErrorMessage = "Account password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
