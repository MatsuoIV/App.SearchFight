﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using App.SearchFight.Infrastructure.Providers;
using App.SearchFight.Infrastructure.Impl;
using App.SearchFight.Core.Services;
using App.SearchFight.Core.Schemas;

namespace App.SearchFight.Core.Impl
{
    public class SearchService : ISearchService
    {
        private IList<ISearchProvider> _searchProviders;

        public SearchService()
        {
            _searchProviders = GetEngines();
        }

        private IList<ISearchProvider> GetEngines()
        {
            return new List<ISearchProvider>
            {
                new GoogleSearchProvider(),
                new BingSearchProvider()
            };
        }

        public async Task<IList<SearchResultSchema>> GetSearchResultsByQuery(IList<string> query)
        {
            IList<SearchResultSchema> searchResults = new List<SearchResultSchema>();

            foreach(ISearchProvider searchProvider in _searchProviders)
            {
                foreach(string term in query)
                {
                    searchResults.Add(new SearchResultSchema
                    {
                        Query = term,
                        Result = await searchProvider.GetSearchResults(term)
                    });
                }
            }
            
            return searchResults;
        }
    }
}
