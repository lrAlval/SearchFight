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
using SearchFight.Services.Models.Google;

namespace SearchFight.Services.Clients
{
    public class GoogleSearchClient : ISearchClient
    {
        public string ClientName => "Google";
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _googleUrl;

        public GoogleSearchClient()
        {
            _googleUrl = ConfigManager.GoogleUri
                .Replace("{0}", ConfigManager.GoogleKey)
                .Replace("{1}", ConfigManager.GoogleCEKey);
        }

        public async Task<long> GetResultsCountAsync(string query)
        {

            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentNullException(nameof(query));

            try
            {
                using (var response = await _httpClient.GetAsync(_googleUrl.Replace("{2}", query)))
                {
                    if (!response.IsSuccessStatusCode)
                        throw new SearchFightHttpException(
                            "There was an error processing your request. Please try again later...");

                    var result = await response.Content.ReadAsStringAsync();
                    var googleResponse = result.DeserializeJson<GoogleResponse>();
                    return long.Parse(googleResponse.SearchInformation.TotalResults);
                }
            }
            catch (Exception ex)
            {
                throw new SearchFightHttpException(ex.Message);
            }
        }
    }
}
