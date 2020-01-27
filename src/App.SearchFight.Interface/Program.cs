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
            string[] args2 = { "java", ".NET" };
            if (args2.Length == 0)
            {
                Console.WriteLine("No query were specified. Please execute again with the required search terms.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("SearchFight results...");
            SearchCore.GetSearchTotalResults(args2.ToList()).GetAwaiter().GetResult();
            Console.ReadKey();
        }
    }
}
