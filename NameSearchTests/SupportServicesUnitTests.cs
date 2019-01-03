using System.Threading.Tasks;
using NUnit.Framework;
using SupportServices;

namespace NameSearchTests
{
    [TestFixture]
    public class SupportServicesUnitTests
    {
        ContentManagementService _svc;

        [SetUp]
        public void Setup()
        {
            // arrange for most of the tests
            _svc = new ContentManagementService();
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
            var content = _svc.FetchPage("https://github.com/PlusConsultingAppDev/Text-Name-Search").ToString().ToLower();

            // assert that our text is in the fetched string
            Assert.IsTrue(content.Contains(stringToFind.ToLower()));
        }

        [Test]
        public async Task TestGettingContentAsynchronouslyFromWeb()
        {
            const string stringToFind = "Curabitur viverra eget";

            // Act: fetch the text from the website
            var content = await _svc.FetchPageAsync("https://github.com/PlusConsultingAppDev/Text-Name-Search");
            var contentToSearch = content.ToString().ToLower();

            // assert that our text is in the fetched string
            Assert.IsTrue(contentToSearch.Contains(stringToFind.ToLower()));
        }

    }
}