using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.SearchFight.Infrastructure.Providers
{
    public interface ISearchProvider
    {
        string Name { get; }
        Task<long> GetSearchResults(string query);
    }
}
