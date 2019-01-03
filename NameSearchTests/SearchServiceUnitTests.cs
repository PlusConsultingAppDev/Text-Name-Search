using NUnit.Framework;
using SearchServices;
using SupportServices;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class SearchServiceUnitTests
    {
        private ContentManagementService _cmSvc;
        private NameSearchService _nameSearchService;
        private string _contentToSearch;

        [SetUp]
        public async Task Setup()
        {
            // arrange for most of the tests
            _cmSvc = new ContentManagementService();
            // more arranging
            var resultsList = new List<KeyValuePair<string, int>>();
            _nameSearchService = new NameSearchService();

            // get our searchable content string
            _contentToSearch = await _cmSvc.FetchPageAsync("https://github.com/PlusConsultingAppDev/Text-Name-Search");
        }
        /*
                [Test]
                public int TestNameSearchForSmith()
                {
                    // add our test names
                    _nameSearchService.AddSearchName("Connor Gary Smith");

                    // find results in the content to search
                    var listOfNamesFound = _nameSearchService.SearchResults(_contentToSearch);

                    // first we can asset that we found names
                    Assert.IsNotEmpty(listOfNamesFound);

                    // Assert: should get 5 results for each of the three names
                    Assert.AreEqual(listOfNamesFound.Count,15);

                    // Assert the counts are correct.
                    // Each one should be one more than indicated on the exercise's because the description contains
                    // each the name in the description plus those in content to search
                    Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Connor Gary Smith", 1)), true);
                    Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Connor G Smith", 1)), true);
                    Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Connor G. Smith", 0)), true);
                    Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Connor Smith", 2)), true);
                    Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Connor Gary Smith total", 4)), true);
                }

                [Test]
                public int TestNameSearchForGreenly()
                {
                    // Act: fetch the text from the website
                    var contentToSearch = await _cmSvc.FetchPageAsync("https://github.com/PlusConsultingAppDev/Text-Name-Search");

                    // add our test names
                    _nameSearchService.AddSearchName("Seth David Greenly");

                    // find results in the content to search
                    var listOfNamesFound = _nameSearchService.SearchResults(contentToSearch);

                    // first we can asset that we found names
                    Assert.IsNotEmpty(listOfNamesFound);

                    // Assert: should get 5 results for each of the three names
                    Assert.AreEqual(listOfNamesFound.Count, 15);

                    // Assert the counts are correct.
                    // Each one should be one more than indicated on the exercise's because the description contains
                    // each the name in the description plus those in content to search
                    Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Seth David Greenly", 2)), true);
                    Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Seth D Greenly", 1)), true);
                    Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Seth D. Greenly", 1)), true);
                    Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Seth Greenly", 0)), true);
                    Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Seth David Greenly total", 4)), true);
                }
        */

        [TestCase("Connor Gary Smith", ExpectedResult = 1)]
        [TestCase("Connor G Smith", ExpectedResult = 1)]
        [TestCase("Connor G. Smith", ExpectedResult = 0)]
        [TestCase("Connor Smith", ExpectedResult = 2)]
        [TestCase("Connor Gary Smith total", ExpectedResult = 4)]
        public int TestNameSearchForSmith(string name)
        {
            // add our test names
            _nameSearchService.AddSearchName("Connor Gary Smith");

            // find results in the content to search
            var listOfNamesFound = _nameSearchService.SearchResults(_contentToSearch);

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
        public int TestNameSearchForGreenly(string name)
        {
            // add our test names
            _nameSearchService.AddSearchName("Seth David Greenly");

            // find results in the content to search
            var listOfNamesFound = _nameSearchService.SearchResults(_contentToSearch);

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
        public int TestNameSearchForBlack(string name)
        {
            // add our test names
            _nameSearchService.AddSearchName("David Warren Black");

            // find results in the content to search
            var listOfNamesFound = _nameSearchService.SearchResults(_contentToSearch);

            // Assert the counts are correct.
            // Each one should be one more than indicated on the exercise's because the description contains
            // each the name in the description plus those in content to search
            return listOfNamesFound.First(n => n.Key == name).Value;
        }

    }
}