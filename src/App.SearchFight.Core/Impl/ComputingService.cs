using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.SearchFight.Core.Schemas;
using App.SearchFight.Core.Services;
using App.SearchFight.Utils.Functions;

namespace App.SearchFight.Core.Impl
{
    public class ComputingService : IComputingService
    {
        public EngineWinnerSchema GetAbsoluteWinner(IList<SearchResultSchema> searchResults)
        {
            if(searchResults == null || searchResults.Count() == 0)
            {
                throw new Exception("No hay resultados");
            }

            SearchResultSchema absoluteWinner = searchResults.GetMax(item => item.Result);
            return new EngineWinnerSchema() { Engine = absoluteWinner.Engine, Term = absoluteWinner.Query };
        }

        public IEnumerable<EngineWinnerSchema> GetWinnerBySearchTerm(IList<SearchResultSchema> searchResults)
        {
            if (searchResults == null || searchResults.Count() == 0)
            {
                throw new Exception("No hay resultados");
            }

            IEnumerable<EngineWinnerSchema> searchEngineWinners = searchResults.GroupBy(data => data.Engine,
                result => result, (searchEngine, results) => new EngineWinnerSchema
                {
                    Engine = searchEngine,
                    Term = results.GetMax(item => item.Result).Query
                });

            return searchEngineWinners;
        }
    }
}
