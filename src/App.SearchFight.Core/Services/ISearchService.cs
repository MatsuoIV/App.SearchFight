using System.Collections.Generic;
using System.Threading.Tasks;
using App.SearchFight.Core.Schemas;

namespace App.SearchFight.Core.Services
{
    public interface ISearchService
    {
        Task<IList<SearchResultSchema>> GetSearchResultsByQuery(IList<string> query);
    }
}
