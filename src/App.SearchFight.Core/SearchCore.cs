using System.Collections.Generic;
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
        static IComputingService ComputingService;
        static IReportingService ReportingService;

        static SearchCore()
        {
            Results = new List<string>();
            SearchService = new SearchService();
            ComputingService = new ComputingService();
            ReportingService = new ReportingService();
        }

        public static async Task GetSearchTotalResults(IList<string> terms)
        {
            IList<SearchResultSchema> searchResults = await SearchService.GetSearchResultsByQuery(terms);
            IEnumerable<EngineWinnerSchema> engineWinners = ComputingService.GetWinnerBySearchTerm(searchResults);
            EngineWinnerSchema absoluteWinner = ComputingService.GetAbsoluteWinner(searchResults);

            #region Reports
            Results.AddRange(ReportingService.GetSearchResultsReport(searchResults));
            Results.AddRange(ReportingService.GetWinnersByEngineReport(engineWinners));
            Results.Add(ReportingService.GetAbsoluteWinnerReport(absoluteWinner));
            #endregion
        }
    }
}
