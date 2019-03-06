using Microsoft.VisualStudio.TestTools.UnitTesting;
using TNSLibrary.Pattern;
using TNSLibrary.Type;

namespace TNSLibraryTest {

    [TestClass]
    public class PatternTest {

        [TestMethod]
        public void Test_First_And_Last() {
            var employee = new Employee("Joe", "Brown", "Smith");
            string input = "Hello Joe Smith, how are you.?";
            IPatternChecker patternChecker = new NamePatternChecker();
            int count = patternChecker.MatchPatterns(employee, input);

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_First_MiddleInitial_Last() {
            var employee = new Employee("Joe", "Brown", "Smith");
            string input = "Hello Joe B Smith, how are you?";
            IPatternChecker patternChecker = new NamePatternChecker();
            int count = patternChecker.MatchPatterns(employee, input);

            Assert.AreEqual(1, count);

        }

        [TestMethod]
        public void Test_First_MiddleInitialDot_Last() {
            var employee = new Employee("Joe", "Brown", "Smith");
            string input = "Hello Joe B. Smith, how are you?";
            IPatternChecker patternChecker = new NamePatternChecker();
            int count = patternChecker.MatchPatterns(employee, input);

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_First_MiddleName_Last() {
            var employee = new Employee("Joe", "Brown", "Smith");
            string input = "Hello Joe Brown Smith, how are you?";
            IPatternChecker patternChecker = new NamePatternChecker();
            int count = patternChecker.MatchPatterns(employee, input);

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_First_And_Last_With_Hyphen() {
            var employee = new Employee("Ryan", "David", "O-Connor");
            string input = "Ryan O-Connor, long time no see.";
            IPatternChecker patternChecker = new NamePatternChecker();
            int count = patternChecker.MatchPatterns(employee, input);

            Assert.AreEqual(1, count);

        }

        [TestMethod]
        public void Test_First_And_Last_With_SingleQuote() {
            var employee = new Employee("Jim", "Mason", "O'Malley");
            string input = "I'll run over to Jim M. O'Malley next.";
            IPatternChecker patternChecker = new NamePatternChecker();
            int count = patternChecker.MatchPatterns(employee, input);

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_All_Cases() {
            var employee = new Employee("Joe", "Brown", "Smith");
            string input = "Hello Joe Smith, Joe B Smith, joe b. smith, joe brown SMITH, joey smith.";
            IPatternChecker patternChecker = new NamePatternChecker();
            int count = patternChecker.MatchPatterns(employee, input);

            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void Test_Next_To_Special_Characters() {
            var employee = new Employee("Joe", "Brown", "Smith");
            string input = "Hello !Joe Smith@ #Joe B Smith$, ^joe b. smith&, *joe brown SMITH(, )joey smith-=.";
            IPatternChecker patternChecker = new NamePatternChecker();
            int count = patternChecker.MatchPatterns(employee, input);

            Assert.AreEqual(4, count);
        }
    }
}
