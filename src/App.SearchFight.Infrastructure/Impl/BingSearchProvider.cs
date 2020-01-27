using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.SearchFight.Infrastructure.Providers;

namespace App.SearchFight.Infrastructure.Impl
{
    public class BingSearchProvider : ISearchProvider
    {
        public Task<long> GetSearchResults(string query)
        {
            throw new NotImplementedException();
        }
    }
}
