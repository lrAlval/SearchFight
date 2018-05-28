using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SearchFight.Infrastructure.Factorys;
using SearchFight.Logic;
using SearchFight.Logic.Models;

namespace SearchFight.Tests
{
    [TestFixture]
    public class SearchManager
    {
        private ISearchManager _searchManager;

        [SetUp]
        public void Init()
        {
            _searchManager = SearchFightFactory.CreateSearchManager();
        }

        [Test]
        public void GetSearchReport_WithNullQuerys_ShouldThrowArgumentNullException()
        {
            List<string> querys = null;

            Func<Task> result =  async  () => await _searchManager.GetSearchReport(querys);

            result.Should().ThrowExactly<ArgumentNullException>();
        }

                
        [Test]
        public async Task GetSearchReport_WithOkQuerys_ShouldGenerateReportAsString()
        {
            var querys = new List<string>() { ".net","java" };

            var result = await _searchManager.GetSearchReport(querys);

            result.Should().BeOfType<string>();
        }

        [Test]
        public async Task GetResultsAsync_OkSearchResults_ShouldNotBeEmpty()
        {
            var querys = new List<string> { ".net", "java" };

            var results = await _searchManager.GetResultsAsync(querys);

            results.Should().NotBeEmpty();
        }

        [Test]
        public void GetWinners_WithNetAsGoogleWinner_ShouldGenerateWinners()
        {
            var searchResults = new List<SearchResult>
            {
                new SearchResult
                {
                    Query = ".net",
                    SearchClient = "Google",
                    TotalResults = 50000
                },
                new SearchResult
                {
                    Query = ".net",
                    SearchClient = "MSN Search",
                    TotalResults = 5000
                },
                new SearchResult
                {
                    Query = "java",
                    SearchClient = "Google",
                    TotalResults = 3000
                },
                new SearchResult
                {
                    Query = "java",
                    SearchClient = "MSN Search",
                    TotalResults = 5000
                },
            };

            var results = _searchManager.GetWinners(searchResults);

            results.Should().Contain(r => r.ClientName == "Google" && r.WinnerQuery == ".net");
        }

        [Test]
        public void GetTotalWinner_WithNetAsTotalWinner_ShouldGenerateWinnerString()
        {
            var searchResults = new List<SearchResult>
            {
                new SearchResult
                {
                    Query = ".net",
                    SearchClient = "Google",
                    TotalResults = 50000
                },
                new SearchResult
                {
                    Query = ".net",
                    SearchClient = "MSN Search",
                    TotalResults = 50000
                },
                new SearchResult
                {
                    Query = "java",
                    SearchClient = "Google",
                    TotalResults = 3000
                },
                new SearchResult
                {
                    Query = "java",
                    SearchClient = "MSN Search",
                    TotalResults = 5000
                },
            };

            var results = _searchManager.GetTotalWinner(searchResults);

            results.Should().Be(".net");
        }

        [Test]
        public void GetTotalWinner_WithNullSearchResults_ShouldThrowArgumentNullException()
        {
            List<SearchResult> searchResults = null;

            Action result =  () => _searchManager.GetTotalWinner(searchResults);

            result.Should().ThrowExactly<ArgumentNullException>();
        }

        [Test]
        public void GetMainResults_WithGoodSearchResults_ShouldGenerateLookUpBasedOnQuery()
        {
            var searchResults = new List<SearchResult>
            {
                new SearchResult
                {
                    Query = ".net",
                    SearchClient = "Google",
                    TotalResults = 50000
                },
                new SearchResult
                {
                    Query = ".net",
                    SearchClient = "MSN Search",
                    TotalResults = 50000
                },
                new SearchResult
                {
                    Query = "java",
                    SearchClient = "Google",
                    TotalResults = 3000
                },
                new SearchResult
                {
                    Query = "java",
                    SearchClient = "MSN Search",
                    TotalResults = 5000
                },
            };

            var results = _searchManager.GetMainResults(searchResults);

            results.Should().BeOfType<Lookup<string, SearchResult>>();
        }
        

    }
}
