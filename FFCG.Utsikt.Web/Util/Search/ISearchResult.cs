using System.Collections.Generic;

namespace FFCG.Utsikt.Web.Util.Search
{
    public interface ISearchResult
    {
        string SearchedQuery { get; set; }
        int NumberOfHits { get; set; }
        IEnumerable<ISearchHit> SearchHits { get; set; }
        IEnumerable<ISearchCategory> Categories { get; set; }
    }
}