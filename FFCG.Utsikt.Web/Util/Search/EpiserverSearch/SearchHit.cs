using System.Collections.Generic;
using FFCG.Utsikt.Web.Models.Pages.SearchPage;

namespace FFCG.Utsikt.Web.Util.Search.EpiserverSearch
{
    public class SearchHit : ISearchHit
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string HighlightQueryText { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public SearchResultType Category { get; set; }
    }
}