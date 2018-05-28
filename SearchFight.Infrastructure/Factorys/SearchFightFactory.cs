using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SearchFight.Common.Extensions;
using SearchFight.Logic;
using SearchFight.Services.Interfaces;

namespace SearchFight.Infrastructure.Factorys
{
    public class SearchFightFactory
    {
        public static ISearchManager CreateSearchManager() => CreateSearchClients();

        private static SearchManager CreateSearchClients()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                ?.Where(assembly => assembly.FullName.StartsWith("SearchFight"));

            var searchClients = loadedAssemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(ISearchClient).ToString()) != null)
                .Select(type => Activator.CreateInstance(type) as ISearchClient);

            return new SearchManager(searchClients);
        }
    }
}
