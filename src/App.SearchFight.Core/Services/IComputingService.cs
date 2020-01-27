using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.SearchFight.Core.Schemas;

namespace App.SearchFight.Core.Services
{
    interface IComputingService
    {
        IEnumerable<EngineWinnerSchema> GetWinnerBySearchTerm(IList<SearchResultSchema> searchResults);
        EngineWinnerSchema GetAbsoluteWinner(IList<SearchResultSchema> searchResults);
    }
}
