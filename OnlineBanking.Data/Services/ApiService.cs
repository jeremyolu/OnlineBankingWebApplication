using Newtonsoft.Json;
using OnlineBanking.Data.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OnlineBanking.Data.Services
{
    public class ApiService
    {
        private HttpClient _apiClient { get; set; }

        public ApiService()
        {
            _apiClient = new HttpClient();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("User-Agent", "ApiService");
        }

        public async Task<ExchangeRateResult> LoadExchangeRates()
        {
            string url = $"https://free.currconv.com/api/v7/convert?q=GBP_EUR,GBP_USD,GBP_JPY,GBP_AUD,GBP_CAD,GBP_AED&compact=ultra&apiKey=e99b169b3b66d7a788e8";

            using (HttpResponseMessage response = await _apiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var repos = JsonConvert.DeserializeObject<ExchangeRateResult>(result);

                    return repos;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
