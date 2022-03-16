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
            var exchangeRates = await _apiService.LoadExchangeRates();

            var euroRate = exchangeRates.GBP_EUR.ToString("#.##");
            var dollarRate = exchangeRates.GBP_USD.ToString("#.##");

            if (newsApi == true)
            {
                var articles = await _apiService.LoadNewsArticles();

                return new HomeViewModel
                {
                    IsNewsDisplayed = true,
                    NewsResults = articles,
                    EuroRate = euroRate,
                    DollarRate = dollarRate
                };
            }

            return new HomeViewModel
            {
                IsNewsDisplayed = false,
                NewsResults = null,
                EuroRate = euroRate,
                DollarRate = dollarRate
            };
        }
    }
}
