using Newtonsoft.Json;
using OnlineBanking.Data.Models.Api;
using System;
using System.Collections.Generic;
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
            _apiClient.DefaultRequestHeaders.Add("User-Agent", "OnlineBanking");
        }

        public async Task<ExchangeRateResult> LoadExchangeRates()
        {
            string url = $"https://free.currconv.com/api/v7/convert?q=GBP_EUR,GBP_USD&compact=ultra&apiKey=e99b169b3b66d7a788e8";

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

        public async Task<IEnumerable<NewsResult>> LoadNewsArticles()
        {
            string url = $"https://newsdata.io/api/1/news?apikey=pub_54862b6d7a11a998196531075678fdff7b0e&category=business&language=en";

            using (HttpResponseMessage response = await _apiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<Rootobject>(result);

                    return data.results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
