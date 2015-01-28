using System.Collections.Generic;

namespace FFCG.Utsikt.Web.Util.Search.EpiserverSearch
{
    public class SearchResult : ISearchResult
    {
        public SearchResult()
        {
            SearchHits = new List<SearchHit>();
            Categories = new List<SearchCategory>();
        }

        public string SearchedQuery { get; set; }
        public int NumberOfHits { get; set; }
        public IEnumerable<ISearchHit> SearchHits { get; set; }
        public IEnumerable<ISearchCategory> Categories { get; set; }

    }
}