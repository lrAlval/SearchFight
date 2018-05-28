using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Services.Interfaces
{
    public interface ISearchClient
    {
        string ClientName { get; }
        Task<long> GetResultsCountAsync(string query);
    }
}
