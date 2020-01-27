using System.Collections.Generic;
using App.SearchFight.Core.Schemas;

namespace App.SearchFight.Core.Services
{
    public interface IReportingService
    {
        IList<string> GetSearchResultsReport(IList<SearchResultSchema> searchResults);
        IList<string> GetWinnersByEngineReport(IEnumerable<EngineWinnerSchema> engineWinners);
        string GetAbsoluteWinnerReport(EngineWinnerSchema absoluteWinner);
    }
}
