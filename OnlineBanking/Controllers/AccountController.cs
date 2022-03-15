using OnlineBanking.Data.Repositories;
using OnlineBanking.Data.Services;
using OnlineBanking.Data.ViewModels.AuthenticationViewModels;
using System.Web.Mvc;

namespace OnlineBanking.Controllers
{
    public class AccountController : Controller
    {
        private PaymentService _paymentService;

        public AccountController()
        {
            _paymentService = new PaymentService();
        }

        [Route("account/dashboard")]
        public ActionResult Index()
        {
            var repo = new CustomerRepository();

            //var customer = repo.GetCustomerByAccountNo(20802074);

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

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

        public ActionResult Login(string application)
        {
            if (!string.IsNullOrEmpty(application))
            {
                ViewBag.Message = "applicationsuccess";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            return View();
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

        public ActionResult Settings()
        {
            return View();
        }
    }
}