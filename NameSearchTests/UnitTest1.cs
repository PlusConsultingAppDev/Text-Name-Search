using NUnit.Framework;
using SearchServices;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGettingContentFromWeb()
        {
            var svc = new ContentRetrieval();
            Assert.Pass();
        }
    }
}