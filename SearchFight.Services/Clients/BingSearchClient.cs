using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SearchFight.Common.Config;
using SearchFight.Common.Exceptions;
using SearchFight.Common.Extensions;
using SearchFight.Services.Interfaces;
using SearchFight.Services.Models.Bing;

namespace SearchFight.Services.Clients
{
    public class BingSearchClient : ISearchClient
    {
        public string ClientName => "MSN Search";
        private static readonly HttpClient _httpClient;

        static BingSearchClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ConfigManager.BingUri),
                DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", ConfigManager.BingKey } }
            };
        }

        public async Task<long> GetResultsCountAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentNullException(nameof(query));

            try
            {
                using (var response = await _httpClient.GetAsync($"?q={query}"))
                {
                    if (!response.IsSuccessStatusCode)
                        throw new SearchFightHttpException(
                            "There was an error processing your request. Please try again later...");

                    var result = await response.Content.ReadAsStringAsync();
                    var bingResponse = result.DeserializeJson<BingResponse>();
                    return long.Parse(bingResponse.WebPages.TotalEstimatedMatches);
                }
            }
            catch (Exception ex)
            {
                throw new SearchFightHttpException(ex.Message);
            }
        }
    }
}
