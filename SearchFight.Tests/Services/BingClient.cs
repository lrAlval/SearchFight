using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SearchFight.Services.Clients;

namespace SearchFight.Tests.Services
{
    public class BingClient
    {
        private BingSearchClient _bingSearchClient;

        [SetUp]
        public void Init()
        {
            _bingSearchClient = new BingSearchClient();
        }

        [Test]
        public async Task GetResultsCountAsync_OkStatus_ShouldGenerateResultsCount()
        {
            var query = ".net";

            var result = await _bingSearchClient.GetResultsCountAsync(query);

            result.GetType().Should().Be(typeof(long));
        }

        [Test]
        public void GetResultsCountAsync_NullQuery_ShouldThrowArgumentNullException()
        {
            string query = null;

            Func<Task> result = async () => await _bingSearchClient.GetResultsCountAsync(query);

            result.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}
