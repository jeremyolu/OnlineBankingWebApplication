using OnlineBanking.Data.ViewModels;
using System.Threading.Tasks;

namespace OnlineBanking.Data.Services
{
    public class HomeService
    {
        private ApiService _apiService;

        public HomeService()
        {
            _apiService = new ApiService();
        }

        public async Task<HomeViewModel> InitialiseHomeViewModel(bool newsApi = false)
        {
            if (newsApi == true)
            {
                var articles = await _apiService.LoadNewsArticles();

                return new HomeViewModel
                {
                    IsNewsDisplayed = true,
                    NewsResults = articles
                };
            }

            return new HomeViewModel
            {
                IsNewsDisplayed = false,
                NewsResults = null
            };
        }
    }
}
