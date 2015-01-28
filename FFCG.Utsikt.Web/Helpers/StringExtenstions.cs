using System.Text.RegularExpressions;

namespace FFCG.Utsikt.Web.Helpers
{
    public static class StringExtenstions
    {
        public static string RemoveHtmlTags(this string s)
        {
            var noHtml=Regex.Replace(s, @"<[^>]+>|&nbsp;", "").Trim();
            var noHtmlNormalised = Regex.Replace(noHtml, @"\s{2,}", " ");
            return noHtmlNormalised;
        }

        public static string ToSubstring(this string s, int startAt, int length)
        {
            if (s.Length - startAt < length)
            {
                return s.Substring(startAt);
            }
            return s.Substring(startAt, length);
        }

        public static bool EqualsIgnoreCase(this string s, string a)
        {
            return s.ToLower().Equals(a.ToLower());
        }
    }
}