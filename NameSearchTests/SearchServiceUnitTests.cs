using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SearchServices;
using SupportServices;

namespace NameSearchTests
{
    [TestFixture]
    public class SearchServiceUnitTests
    {
        private NameSearchService _nameSearchService;
        private const string UrlToFetch = "https://github.com/PlusConsultingAppDev/Text-Name-Search";

        [SetUp]
        public void Setup()
        {
            // arrange for the coommonality of the tests
            var resultsList = new List<KeyValuePair<string, int>>();
            _nameSearchService = new NameSearchService();
        }


        [TestCase("Connor Gary Smith", ExpectedResult = 1)]
        [TestCase("Connor G Smith", ExpectedResult = 1)]
        [TestCase("Connor G. Smith", ExpectedResult = 0)]
        [TestCase("Connor Smith", ExpectedResult = 2)]
        [TestCase("Connor Gary Smith total", ExpectedResult = 4)]
        public async Task<int> TestNameSearchForSmith(string name)
        {
            // add our test names
            _nameSearchService.AddSearchName("Connor Gary Smith");

            // find results in the content to search
            var listOfNamesFound = await _nameSearchService.SearchResults(UrlToFetch);

            // Assert the counts are correct.
            // Each one should be one more than indicated on the exercise's because the description contains
            // each the name in the description plus those in content to search
            return listOfNamesFound.First(n => n.Key == name).Value;
        }

        [TestCase("Seth David Greenly", ExpectedResult = 2)]
        [TestCase("Seth D Greenly", ExpectedResult = 1)]
        [TestCase("Seth D. Greenly", ExpectedResult = 1)]
        [TestCase("Seth Greenly", ExpectedResult = 0)]
        [TestCase("Seth David Greenly total", ExpectedResult = 4)]
        public async Task<int> TestNameSearchForGreenly(string name)
        {
            // add our test names
            _nameSearchService.AddSearchName("Seth David Greenly");

            // find results in the content to search
            var listOfNamesFound = await _nameSearchService.SearchResults(UrlToFetch);

            // Assert the counts are correct.
            // Each one should be one more than indicated on the exercise's because the description contains
            // each the name in the description plus those in content to search
            return listOfNamesFound.First(n => n.Key == name).Value;
        }

        [TestCase("David Warren Black", ExpectedResult = 2)]
        [TestCase("David W Black", ExpectedResult = 0)]
        [TestCase("David W. Black", ExpectedResult = 1)]
        [TestCase("David Black", ExpectedResult = 2)]
        [TestCase("David Warren Black total", ExpectedResult = 5)]
        public async Task<int> TestNameSearchForBlack(string name)
        {
            // add our test names
            _nameSearchService.AddSearchName("David Warren Black");

            // find results in the content to search
            var listOfNamesFound = await _nameSearchService.SearchResults(UrlToFetch);

            // Assert the counts are correct.
            // Each one should be one more than indicated on the exercise's because the description contains
            // each the name in the description plus those in content to search
            return listOfNamesFound.First(n => n.Key == name).Value;
        }

    }
}