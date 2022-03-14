using OnlineBanking.Data.Services;
using OnlineBanking.Data.ViewModels.AuthenticationViewModels;
using System.Web.Mvc;

namespace OnlineBanking.Controllers
{
    public class AccountController : Controller
    {
        [Route("account/dashboard")]
        public ActionResult Index()
        {
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
    }
}