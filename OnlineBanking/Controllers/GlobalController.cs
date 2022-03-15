using System.Web.Mvc;

namespace OnlineBanking.Controllers
{
    public class GlobalController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}