using System;
using System.Linq;
using App.SearchFight.Core;

namespace App.SearchFight.Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No query was specified. Please execute again with the required search terms.");
                return;
            }
            Console.WriteLine("SearchFight results...");
            SearchCore.GetSearchTotalResults(args.ToList()).GetAwaiter().GetResult();
            SearchCore.Results.ForEach(result => Console.WriteLine(result));
        }
    }
}
