using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlusConsulting.NameSearch.SearchCritera;

namespace PlusConsulting.NameSearch.SearchEngineTests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void Search_ShouldReturnPositiveMatch_WhenMatchingEntireName()
        {
            var name = new Name("John", "Eugene", "Doe");
            var hits = name.Search("My name is John Eugene Doe.");
            Assert.AreEqual(1, hits);
        }

        [TestMethod]
        public void Search_ShouldReturnPositiveMatch_WhenMatchingFirstAndLastNameOnly()
        {
            var name = new Name("John", "Eugene", "Doe");
            var hits = name.Search("My name is John Doe.");
            Assert.AreEqual(1, hits);
        }

        [TestMethod]
        public void Search_ShouldReturnPositiveMatch_WhenMatchingWithMiddleInitial()
        {
            var name = new Name("John", "Eugene", "Doe");
            var hits = name.Search("My name is John E. Doe (aka John E Doe).");
            Assert.AreEqual(2, hits);
        }

        [TestMethod]
        [ExpectedException(typeof(SearchException))]
        public void Search_ShouldThrowSearchException_WhenFirstNameIsEmpty()
        {
            var name = new Name("", "Doe");
            name.Search("foo");
        }

        [TestMethod]
        [ExpectedException(typeof(SearchException))]
        public void Search_ShouldThrowSearchException_WhenLastNameIsEmpty()
        {
            var name = new Name("John", "");
            name.Search("foo");
        }

        [TestMethod]
        public void Search_ShouldReturnResultsForAliases_IfAliasesAreNotNull()
        {
            var name = new Name("John", "Doe");
            name.Aliases = new[] {new Name("Jack", "Doe")};
            var hits = name.Search("My name is John Doe but my friends call me Jack Doe.");
            Assert.AreEqual(2, hits);
        }
    }
}
