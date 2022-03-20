using OnlineBanking.Data.Repositories;
using OnlineBanking.Data.Services;
using OnlineBanking.Data.Services.Database;
using OnlineBanking.Data.ViewModels.AuthenticationViewModels;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineBanking.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private AuthenticationService _authenticationService;
        private PaymentService _paymentService;

        public AccountController()
        {
            _authenticationService = new AuthenticationService();
            _paymentService = new PaymentService();
        }

        [Route("account/dashboard")]
        public ActionResult Index()
        {
            var repo = new CustomerRepository();

            //var customer = repo.GetCustomerByAccountNo(20802074);

            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            var data = new UserDatabaseService();

            if (ModelState.IsValid)
            {
                var result = data.CreateCustomer(model);

                if (result == true)
                {
                    return RedirectToAction("login", new { application = "success" });
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Login(string application)
        {
            if (!string.IsNullOrEmpty(application))
            {
                ViewBag.Message = "applicationsuccess";
            }

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authenticated = _authenticationService.LoginCustomer(model);

                if (authenticated)
                {
                    return RedirectToAction("index");
                }

            }

            return View(model);
        }

        public ActionResult CurrentAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessPayment()
        {
            return View();
        }

        public ActionResult Messages()
        {
            return View();
        }

        public ActionResult Transactions(string accountId)
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("account/help-center")]
        public ActionResult HelpCenter()
        {
            var customerId = User.Identity.Name;

            return Content(customerId);
        }

        public ActionResult Logout()
        {
            _authenticationService.Logout();

            return RedirectToAction("login");
        }
    }
}