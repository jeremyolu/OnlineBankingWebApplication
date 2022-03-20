using OnlineBanking.Data.Repositories;
using OnlineBanking.Data.ViewModels.AccountViewModels;

namespace OnlineBanking.Data.Services
{
    public class CustomerService
    {
        private CustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        
        public CustomerDetailsViewModel InitialiseCustomerDetailsViewModel()
        {
            var customerId = 525649;

            var customerLogin = _customerRepository.GetCustomerLogin(customerId);

            return new CustomerDetailsViewModel
            {
                CustomerLogin = customerLogin
            };
        }
    }
}
