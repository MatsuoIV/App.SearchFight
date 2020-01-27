using System;
using System.Net.Http;
using System.Threading.Tasks;
using App.SearchFight.Infrastructure.Providers;
using App.SearchFight.Infrastructure.Config;
using App.SearchFight.Infrastructure.Schemas.Bing;
using App.SearchFight.Utils.Helpers;
using App.SearchFight.Utils.Constants;

namespace App.SearchFight.Infrastructure.Impl
{
    public class BingSearchProvider : ISearchProvider
    {
        public string Name => ConfigConstants.Bing;
        private HttpClient _client { get; }

        public BingSearchProvider()
        {
            _client = new HttpClient();
        }

        public async Task<long> GetSearchResults(string query)
        {
            if(string.IsNullOrEmpty(query))
            {
                throw new Exception("Bing Search: Invalid parameters");
            }

            string requestUrl = BingConfigParams.BaseUrl.Replace("{ConfigurationId}", BingConfigParams.ConfigurationId)
                .Replace("{Query}", query);

            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", BingConfigParams.SuscriptionKey);

            HttpResponseMessage result = await _client.GetAsync(requestUrl);
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Bing Search: Can't perform the search");
            }

            BingResultSchema results = JsonHelper.Deserialize<BingResultSchema>(await result.Content.ReadAsStringAsync());
            return results.WebPages.TotalEstimatedMatches;
        }
    }
}
