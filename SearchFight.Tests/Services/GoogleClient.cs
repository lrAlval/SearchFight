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
    [TestFixture]
    public class GoogleClient
    {
        private GoogleSearchClient _googleSearchClient;

        [SetUp]
        public void Init()
        {
            _googleSearchClient = new GoogleSearchClient();
        }

        [Test]
        public async Task GetResultsCountAsync_OkStatus_ShouldGenerateResultsCount()
        {
            var query = "java";

            var result = await _googleSearchClient.GetResultsCountAsync(query);

            result.GetType().Should().Be(typeof(long));
        }

        [Test]
        public void GetResultsCountAsync_NullQuery_ShouldThrow_ArgumentNullException()
        {
            string query = null;

            Func<Task> result = async () => await _googleSearchClient.GetResultsCountAsync(query);

            result.Should().ThrowExactly<ArgumentNullException>();
        }

    }
}
