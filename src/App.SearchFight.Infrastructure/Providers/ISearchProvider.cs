using System.Threading.Tasks;

namespace App.SearchFight.Infrastructure.Providers
{
    public interface ISearchProvider
    {
        string Name { get; }
        Task<long> GetSearchResults(string query);
    }
}
