using OnlineBanking.Data.Repositories;
using OnlineBanking.Data.Services.Database;
using OnlineBanking.Data.ViewModels.AccountViewModels;
using OnlineBanking.Data.ViewModels.AuthenticationViewModels;
using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;

namespace OnlineBanking.Data.Services
{
    public class AuthenticationService
    {
        private CustomerRepository _customerRepository;
        private UserDatabaseService _userDatabaseService;

        public AuthenticationService()
        {
            _customerRepository = new CustomerRepository();
            _userDatabaseService = new UserDatabaseService();
        }

        public bool RegisterCustomer(RegisterViewModel model)
        {
            return true;
        }

        public bool LoginCustomer(LoginViewModel model)
        {
            var customer = _customerRepository.GetCustomerLogin(model.CustomerNo);

            if (customer != null)
            {
                var verify = VerifyCustomerCredentials(customer.Password, model.Password);

                if (verify)
                {
                    int timeout = 15;
                    var ticket = new FormsAuthenticationTicket(customer.CustomerId.ToString(), false, timeout);
                    var encrypted = FormsAuthentication.Encrypt(ticket);

                    _userDatabaseService.SetLastLoginDateTimeStamp(customer.CustomerId.ToString());

                    var cookie = SetCustomerCookie(encrypted, timeout);
                    HttpContext.Current.Response.Cookies.Add(cookie);

                    return true;
                }
            }

            return false;
        }

        private bool VerifyCustomerCredentials(string customerPassword, string loginPassword)
        {
            return Crypto.VerifyHashedPassword(customerPassword, loginPassword);
        }

        public string GetCustomerAuthId()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        private HttpCookie SetCustomerCookie(string value, int expiremins)
        {
            return new HttpCookie(FormsAuthentication.FormsCookieName, value)
            {
                Value = value,
                Expires = DateTime.Now.AddMinutes(expiremins),
                HttpOnly = true
            };
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public CustomerDetailsViewModel InitialiseCustomerDetailsViewModel()
        {
            return new CustomerDetailsViewModel
            {

            };
        }
    }
}
