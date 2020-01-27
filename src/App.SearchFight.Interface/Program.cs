using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.SearchFight.Core;

namespace App.SearchFight.Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No query were specified. Please execute again with the required search terms.");
                return;
            }
            Console.WriteLine("SearchFight results...");
            SearchCore.GetSearchTotalResults(args.ToList()).GetAwaiter().GetResult();
            SearchCore.Results.ForEach(result => Console.WriteLine(result));
        }
    }
}
