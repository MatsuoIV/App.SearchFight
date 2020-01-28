using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using App.SearchFight.Core.Impl;
using App.SearchFight.Core.Schemas;
using App.SearchFight.Core.Services;

namespace App.SearchFight.Tests.Core
{
    [TestFixture]
    class ComputingServiceTest
    {
        private IComputingService _computingService;

        public ComputingServiceTest()
        {
            _computingService = new ComputingService();
        }

        #region GetWinnerBySearchTerm

        [Test]
        public void GetWinnerBySearchTerm_Null_Results_Exception()
        {
            Assert.Throws<Exception>(() => _computingService.GetWinnerBySearchTerm(null));
        }

        [Test]
        public void GetWinnerBySearchTerm_Empty_Results_Exception()
        {
            Assert.Throws<Exception>(() => _computingService.GetWinnerBySearchTerm(new List<SearchResultSchema>()));
        }

        [Test]
        public void GetWinnerBySearchTerm_Success()
        {
            IEnumerable<EngineWinnerSchema> searchEngineWinners = _computingService.GetWinnerBySearchTerm(GetTestSearchResults());

            Assert.IsNotNull(searchEngineWinners);
            Assert.IsNotEmpty(searchEngineWinners);

            Assert.AreEqual("NodeJS", searchEngineWinners.First(q => q.Engine == "Google").Term);
            Assert.AreEqual("Java", searchEngineWinners.First(q => q.Engine == "Bing").Term);
        }
        #endregion

        #region GetAbsoluteWinner

        [Test]
        public void GetAbsoluteWinner_Null_Results_Exception()
        {
            Assert.Throws<Exception>(() => _computingService.GetAbsoluteWinner(null));
        }

        [Test]
        public void GetAbsoluteWinner_Empty_Results_Exception()
        {
            Assert.Throws<Exception>(() => _computingService.GetAbsoluteWinner(new List<SearchResultSchema>()));
        }

        [Test]
        public void GetAbsoluteWinner_Success()
        {
            EngineWinnerSchema absoluteWinner = _computingService.GetAbsoluteWinner(GetTestSearchResults());

            Assert.IsNotNull(absoluteWinner);
            Assert.AreEqual("Bing", absoluteWinner.Engine);
            Assert.AreEqual("Java", absoluteWinner.Term);
        }

        #endregion

        private List<SearchResultSchema> GetTestSearchResults()
        {
            List<SearchResultSchema> testSearchResults = new List<SearchResultSchema>
            {
                new SearchResultSchema { Engine = "Google", Query = ".NET", Result = 374060 },
                new SearchResultSchema { Engine = "Bing", Query = ".NET", Result = 434498 },

                new SearchResultSchema { Engine = "Google", Query = "Java", Result = 635626 },
                new SearchResultSchema { Engine = "Bing", Query = "Java", Result = 845455 },

                new SearchResultSchema { Engine = "Google", Query = "NodeJS", Result = 667991 },
                new SearchResultSchema { Engine = "Bing", Query = "NodeJS", Result = 642507 }
            };

            return testSearchResults;
        }
    }
}
