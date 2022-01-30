using System.Text.RegularExpressions;

namespace Rowlan.SimpleBicyclePhysicsExtensions
{
    public class StringUtils
    {
        /// <summary>
        /// Check if a text matches a wildcard pattern
        /// </summary>
        /// <param name="text">The text to compare</param>
        /// <param name="pattern">Wildcard pattern using *</param>
        /// <returns></returns>
        public static bool Matches(string text, string pattern)
        {
            string regex = WildCardToRegular1(pattern);
            return Regex.IsMatch(text, regex);
        }

        /// <summary>
        /// Wildcard search for *.
        /// Thanks to Dmitry Bychenko: https://stackoverflow.com/questions/30299671/matching-strings-with-wildcard
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string WildCardToRegular1(string value)
        {
            return "^" + Regex.Escape(value).Replace("\\*", ".*") + "$";
        }

        /// <summary>
        /// Wildcard search for * and ?
        /// Thanks to Dmitry Bychenko: https://stackoverflow.com/questions/30299671/matching-strings-with-wildcard
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string WildCardToRegular2(string value)
        {
            return "^" + Regex.Escape(value).Replace("\\?", ".").Replace("\\*", ".*") + "$";
        }
    }
}