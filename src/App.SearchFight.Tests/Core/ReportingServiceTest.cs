using System;
using System.Collections.Generic;
using NUnit.Framework;
using App.SearchFight.Core.Impl;
using App.SearchFight.Core.Schemas;
using App.SearchFight.Core.Services;

namespace App.SearchFight.Tests.Core
{
    [TestFixture]
    class ReportingServiceTest
    {
        private IReportingService _reportingService;

        public ReportingServiceTest()
        {
            _reportingService = new ReportingService();
        }

        #region GetSearchResultsReport

        [Test]
        public void GetSearchResultsReport_Null_Results_Exception()
        {
            Assert.Throws<Exception>(() => _reportingService.GetSearchResultsReport(null));
        }

        [Test]
        public void GetSearchResultsReport_Empty_Results_Exception()
        {
            Assert.Throws<Exception>(() => _reportingService.GetSearchResultsReport(new List<SearchResultSchema>()));
        }

        [Test]
        public void GetSearchResultsReport_Success()
        {
            IList<string> report = _reportingService.GetSearchResultsReport(GetTestData());

            Assert.NotNull(report);
            Assert.AreNotEqual(0, report.Count);
        }

        #endregion

        #region GetWinnersByEngineReport

        [Test]
        public void GetWinnersByEngineReport_Null_Results_Exception()
        {
            Assert.Throws<Exception>(() => _reportingService.GetWinnersByEngineReport(null));
        }

        [Test]
        public void GetWinnersByEngineReport_Empty_Results_Exception()
        {
            Assert.Throws<Exception>(() => _reportingService.GetWinnersByEngineReport(new List<EngineWinnerSchema>()));
        }

        [Test]
        public void GetWinnersByEngineReport_Success()
        {
            IList<string> report = _reportingService.GetWinnersByEngineReport(GetTestEngineWinners());

            Assert.NotNull(report);
            Assert.AreNotEqual(0, report.Count);
        }

        #endregion

        #region GetAbsouluteWinnerReport

        [Test]
        public void GetAbsouluteWinnerReport_Null_Results_Exception()
        {
            Assert.Throws<Exception>(() => _reportingService.GetAbsoluteWinnerReport(null));
        }

        [Test]
        public void GetAbsoluteWinnerReport_Success()
        {
            string absoluteWinner = _reportingService.GetAbsoluteWinnerReport(GetTestAbsoluteWinner());

            Assert.NotNull(absoluteWinner);
            Assert.IsNotEmpty(absoluteWinner);
        }

        #endregion

        private List<SearchResultSchema> GetTestData()
        {
            List<SearchResultSchema> testData = new List<SearchResultSchema>
            {
                new SearchResultSchema { Engine = "Google", Query = ".NET", Result = 374060 },
                new SearchResultSchema { Engine = "Bing", Query = ".NET", Result = 434498 },

                new SearchResultSchema { Engine = "Google", Query = "Java", Result = 635626 },
                new SearchResultSchema { Engine = "Bing", Query = "Java", Result = 845455 },

                new SearchResultSchema { Engine = "Google", Query = "NodeJS", Result = 667991 },
                new SearchResultSchema { Engine = "Bing", Query = "NodeJS", Result = 642507 }
            };

            return testData;
        }

        private IList<EngineWinnerSchema> GetTestEngineWinners()
        {
            return new List<EngineWinnerSchema>
            {
                new EngineWinnerSchema { Engine = "Google", Term = "NodeJS" },
                new EngineWinnerSchema { Engine = "Bing", Term = "Java" }
            };
        }

        private EngineWinnerSchema GetTestAbsoluteWinner()
        {
            return new EngineWinnerSchema { Engine = "Bing", Term = "Java" };
        }
    }
}
