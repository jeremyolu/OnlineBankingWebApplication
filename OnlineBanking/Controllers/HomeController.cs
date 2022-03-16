using OnlineBanking.Data.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineBanking.Controllers
{
    public class HomeController : Controller
    {
        private HomeService _homeService;

        public HomeController()
        {
            _homeService = new HomeService();
        }

        public async Task<ActionResult> Index()
        {
            var model = await _homeService.InitialiseHomeViewModel();

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}