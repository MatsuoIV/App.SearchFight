using System;
using System.Net.Http;
using System.Threading.Tasks;
using App.SearchFight.Infrastructure.Providers;
using App.SearchFight.Infrastructure.Config;
using App.SearchFight.Infrastructure.Schemas.Google;
using App.SearchFight.Utils.Helpers;
using App.SearchFight.Utils.Constants;

namespace App.SearchFight.Infrastructure.Impl
{
    public class GoogleSearchProvider : ISearchProvider
    {
        public string Name => ConfigConstants.Google;
        private HttpClient _client { get; }

        public GoogleSearchProvider()
        {
            _client = new HttpClient();
        }

        public async Task<long> GetSearchResults(string query)
        {
            if(string.IsNullOrEmpty(query))
            {
                throw new Exception("Google Search: Invalid parameters");
            }

            string requestUrl = GoogleConfigParams.BaseUrl.Replace("{ApiKey}", GoogleConfigParams.ApiKey)
                .Replace("{SearchId}", GoogleConfigParams.SearchId)
                .Replace("{Query}", query);

            HttpResponseMessage result = await _client.GetAsync(requestUrl);
            if(!result.IsSuccessStatusCode)
            {
                throw new Exception("Google Search: Can't perform the search");
            }

            GoogleResultSchema results = JsonHelper.Deserialize<GoogleResultSchema>(await result.Content.ReadAsStringAsync());
            return long.Parse(results.SearchInformation.TotalResults);
        }
    }
}
