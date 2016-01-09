namespace StringSearchingService
{
    using System.Text.RegularExpressions;

    public class StringSearchingService : IStringSearchingService
    {
        public int FindStringInString(string text, string searched, bool isCaseSensitive)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(searched) || searched.Length > text.Length)
            {
                return 0;
            }

            var found = isCaseSensitive ? Regex.Matches(text, searched).Count : Regex.Matches(text, searched, RegexOptions.IgnoreCase).Count;

            return found;
        }
    }
}
