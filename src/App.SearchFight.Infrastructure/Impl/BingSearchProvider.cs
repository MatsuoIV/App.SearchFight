using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.SearchFight.Infrastructure.Providers;
using App.SearchFight.Infrastructure.Config;
using App.SearchFight.Infrastructure.Schemas.Bing;
using App.SearchFight.Utils.Helpers;

namespace App.SearchFight.Infrastructure.Impl
{
    public class BingSearchProvider : ISearchProvider
    {
        private HttpClient _client { get; }

        public BingSearchProvider()
        {
            _client = new HttpClient();
        }

        public async Task<long> GetSearchResults(string query)
        {
            if(string.IsNullOrEmpty(query))
            {
                throw new Exception("Parametros inválidos");
            }

            string configurationId = BingConfigParams.ConfigurationId;
            string suscriptionKey = BingConfigParams.SuscriptionKey;

            string requestUrl = BingConfigParams.BaseUrl.Replace("{ConfigurationId}", BingConfigParams.ConfigurationId)
                .Replace("{Query}", query);

            this._client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", BingConfigParams.SuscriptionKey);

            var result = await this._client.GetAsync(requestUrl);
            if (!result.IsSuccessStatusCode)
            {
            throw new NotImplementedException();
        }

            var results = JsonHelper.Deserialize<BingResultSchema>(await result.Content.ReadAsStringAsync());
            return results.WebPages.TotalEstimatedMatches;
        }
    }
}
