using TNSLibrary.Type;

namespace TNSLibrary.Pattern {

    public interface IPatternChecker {

        /// <summary>
        /// Returns the number of occurences of an employee's name in a longer input text.
        /// </summary>
        /// <param name="search">The search string</param>
        /// <param name="input">The input to match against</param>
        /// <returns>The number of matches</returns>
        int MatchPatterns(Employee employee, string input);

        /// <summary>
        /// Returns the number of occurences of an email in a longer input text.
        /// </summary>
        /// <param name="search">The search string</param>
        /// <param name="input">The input to match against</param>
        /// <returns>The number of matches</returns>
        int MatchPatterns(Email email, string input);
    }
}
