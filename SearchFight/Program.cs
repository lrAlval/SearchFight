using SearchFight.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchFight.Common.Exceptions;
using SearchFight.Infrastructure.Factorys;

namespace SearchFight
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Please enter a query to search....");
                    args = Console.ReadLine()?.Split(' ');
                }

                Console.WriteLine("Loading results ...");

                var searchManager = SearchFightFactory.CreateSearchManager();
                var result = await searchManager.GetSearchReport(args?.ToList());

                Console.Clear();
                Console.WriteLine(result);
            }
            catch (SearchFightException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error generating the report: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
