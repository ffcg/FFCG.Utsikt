using System.Globalization;

namespace FFCG.Utsikt.Web.Util.Search
{
    public interface ISearchService
    {
        ISearchResult Search(string query, CultureInfo culture, int maxResults);
    }
}