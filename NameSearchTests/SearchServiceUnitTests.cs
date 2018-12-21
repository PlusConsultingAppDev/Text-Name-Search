using System.Threading.Tasks;
using NUnit.Framework;
using SearchServices;

namespace Tests
{
    public class SearchServiceUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNamePermutations()
        {
            const string stringToPermutate = "Christopher Douglas Rickard";

            var svc = new PermutationService(stringToPermutate);
            var nameList = svc.GeneratePermutations();
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

            // fire up an instance
            var svc = new ContentManagementService();

            // fetch the text from the website
            var context = svc.FetchPage("https://github.com/PlusConsultingAppDev/Text-Name-Search").ToString().ToLower();

            // assert that our text is in the fetched string
            Assert.IsTrue(context.Contains(stringToFind.ToLower()));
        }

        [Test]
        public async Task TestGettingContentAsynchronouslyFromWeb()
        {
            const string stringToFind = "Curabitur viverra eget";

            // fire up an instance
            var svc = new ContentManagementService();

            // fetch the text from the website
            var content = await svc.FetchPageAsync("https://github.com/PlusConsultingAppDev/Text-Name-Search");
            var contentToSearch = content.ToString().ToLower();

            // assert that our text is in the fetched string
            Assert.IsTrue(contentToSearch.Contains(stringToFind.ToLower()));
        }
    }
}