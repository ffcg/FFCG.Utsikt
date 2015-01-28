using System.Collections.Generic;
using FFCG.Utsikt.Web.Models.Pages.SearchPage;

namespace FFCG.Utsikt.Web.Util.Search
{
    public interface ISearchHit
    {
        SearchResultType Category { get; set; }
        string Url { get; set; }
        string Title { get; set; }
        string HighlightQueryText { get; set; }
        IEnumerable<string> Categories { get; set; }
    }
}