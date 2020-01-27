using System;
using System.Linq;
using App.SearchFight.Core;
using System.Threading.Tasks;

namespace App.SearchFight.Interface
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No query was specified. Please execute again with the required search terms.");
                return;
            }
            Console.WriteLine("SearchFight results...");
            await SearchCore.GetSearchTotalResults(args.ToList());
            SearchCore.Results.ForEach(result => Console.WriteLine(result));
            Console.Write("Search completed. Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
    }
}
