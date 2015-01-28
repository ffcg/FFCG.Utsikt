namespace FFCG.Utsikt.Web.Util.Search
{
    public interface ISearchTextMatcher
    {
        string MatchText(string query, int textLength);
    }
}