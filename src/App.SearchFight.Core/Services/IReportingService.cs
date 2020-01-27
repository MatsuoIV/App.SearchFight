using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
