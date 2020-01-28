using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using App.SearchFight.Core.Impl;
using App.SearchFight.Core.Schemas;
using App.SearchFight.Core.Services;

namespace App.SearchFight.Tests.Core
{
    [TestFixture]
    class SearchServiceTest
    {
        private ISearchService _searchService;

        public SearchServiceTest()
        {
            _searchService = new SearchService();
        }

        #region GetSearchResultsByQuery

        [Test]
        public void GetSearchResultsByQuery_Null_Results_Exception()
        {
            Assert.ThrowsAsync<Exception>(() => _searchService.GetSearchResultsByQuery(null));
        }

        [Test]
        public void GetSearchResultsByQuery_Empty_Results_Exception()
        {
            Assert.ThrowsAsync<Exception>(() => _searchService.GetSearchResultsByQuery(new List<string>()));
        }

        [Test]
        public async Task GetSearchResultsByQuery_Success()
        {
            IList<SearchResultSchema> searchResults = await _searchService.GetSearchResultsByQuery(GetTestQuery());

            Assert.IsNotNull(searchResults);
            Assert.IsNotEmpty(searchResults);
        }

        #endregion

        private IList<string> GetTestQuery()
        {
            return new List<string> { ".NET", "Java", "NodeJS" };
        }
    }
}
