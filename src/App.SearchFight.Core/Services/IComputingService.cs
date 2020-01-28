using System.Collections.Generic;
using App.SearchFight.Core.Schemas;

namespace App.SearchFight.Core.Services
{
    public interface IComputingService
    {
        IEnumerable<EngineWinnerSchema> GetWinnerBySearchTerm(IList<SearchResultSchema> searchResults);
        EngineWinnerSchema GetAbsoluteWinner(IList<SearchResultSchema> searchResults);
    }
}
