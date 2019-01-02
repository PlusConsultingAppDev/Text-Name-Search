using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Framework;
using SearchServices;

namespace Tests
{
    public class SearchServiceUnitTests
    {
        ContentManagementService svc;

        [SetUp]
        public void Setup()
        {
            // arrange for most of the tests
            svc = new ContentManagementService();
        }

        [Test]
        public void TestNamePermutations()
        {
            const string stringToPermutate = "Christopher Douglas Rickard";

            // arrange
            var permutationService = new PermutationService(stringToPermutate);

            // act
            var nameList = permutationService.GeneratePermutations();

            // assert
            Assert.IsNotEmpty(nameList);
            Assert.IsTrue(nameList.Contains("Christopher Douglas Rickard"));
            Assert.IsTrue(nameList.Contains("Christopher D Rickard"));
            Assert.IsTrue(nameList.Contains("Christopher D. Rickard"));
            Assert.IsTrue(nameList.Contains("Christopher Rickard"));
        }

        [Test]
        public void TestGettingContentSynchronouslyFromWeb()
        {
            const string stringToFind = "pulvinar turpis laoreet dictum ultrices. Aenean";


            // Act: fetch the text from the website
            var context = svc.FetchPage("https://github.com/PlusConsultingAppDev/Text-Name-Search").ToString().ToLower();

            // assert that our text is in the fetched string
            Assert.IsTrue(context.Contains(stringToFind.ToLower()));
        }

        [Test]
        public async Task TestGettingContentAsynchronouslyFromWeb()
        {
            const string stringToFind = "Curabitur viverra eget";

            // Act: fetch the text from the website
            var content = await svc.FetchPageAsync("https://github.com/PlusConsultingAppDev/Text-Name-Search");
            var contentToSearch = content.ToString().ToLower();

            // assert that our text is in the fetched string
            Assert.IsTrue(contentToSearch.Contains(stringToFind.ToLower()));
        }

        [Test]
        public async Task TestNameSearch()
        {

            // more arranging
            var resultsList = new List<KeyValuePair<string, int>>();
            var nameSearchService = new NameSearchService();

            // Act: fetch the text from the website
            var contentToSearch = await svc.FetchPageAsync("https://github.com/PlusConsultingAppDev/Text-Name-Search");

            // add our test names
            nameSearchService.AddSearchName("Connor Gary Smith");
            nameSearchService.AddSearchName("Seth David Greenly");
            nameSearchService.AddSearchName("David Warren Black");

            // find results in the content to search
            var listOfNamesFound = nameSearchService.SearchResults(contentToSearch);

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

            Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Seth David Greenly", 2)), true);
            Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Seth D Greenly", 1)), true);
            Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Seth D. Greenly", 1)), true);
            Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Seth Greenly", 0)), true);
            Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("Seth David Greenly total", 4)), true);

            Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("David Warren Black", 2)), true);
            Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("David W Black", 0)), true);
            Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("David W. Black", 1)), true);
            Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("David Black", 2)), true);
            Assert.AreEqual(listOfNamesFound.Contains(new KeyValuePair<string, int>("David Warren Black total", 5)), true);
        }
    }
}