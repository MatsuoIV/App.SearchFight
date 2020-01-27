using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.SearchFight.Core.Impl;
using App.SearchFight.Core.Services;
using App.SearchFight.Core.Schemas;

namespace App.SearchFight.Core
{
    public static class SearchCore
    {
        public static List<string> Results { get; set; }

        static ISearchService SearchService;

        static SearchCore()
        {
            Results = new List<string>();
            SearchService = new SearchService();
        }

        public static async Task GetSearchTotalResults(IList<string> terms)
        {
            IList<SearchResultSchema> searchResults = await SearchService.GetSearchResultsByQuery(terms);
            if (searchResults == null || searchResults.Count() == 0)
            {
                throw new Exception("No se encontraron resultados");
            }

            foreach(SearchResultSchema searchResult in searchResults)
            {
                Console.WriteLine("==========================");
                Console.WriteLine(searchResult.Query);
                Console.WriteLine(searchResult.Result);
            }
        }
    }
}
