using OnlineBanking.Data.Services;
using System.Web.Mvc;

namespace OnlineBanking.Controllers
{
    public class GlobalController : Controller
    {
        private CustomerService _customerService;

        public GlobalController()
        {
            _customerService = new CustomerService();
        }

        [ChildActionOnly]
        public PartialViewResult Navigation()
        {
            var model = _customerService.InitialiseCustomerDetailsViewModel();

            return PartialView("_Navigation", model);
        }
    }
}