using System.Collections.Generic;
using System.Linq;

namespace FFCG.Utsikt.Web.Models.Pages.SearchPage
{
    public class SearchPageViewModel : PageViewModelBase<SearchPage>
    {
        
        public SearchPageViewModel()
        {

        }

        public SearchPageViewModel(SearchPage currentPage)
            : base(currentPage)
        {
        }
        public string SearchedQuery { get; set; }
        public int NumberOfHits { get; set; }
        public IEnumerable<SearchHit> Hits { get; set; }
        public int AllHitCount
        {
            get { return Hits.Count(); }
        }
        
        public int CalendarEventHitCount
        {
            get { return Hits.Count(x => x.Category.Type() == SearchResultTypeEnum.CalendarEvent); }
        }
        public int DocumentHitCount
        {
            get { return Hits.Count(x => x.Category.Type() == SearchResultTypeEnum.Document); }
        }
        public int PageHitCount
        {
            get { return Hits.Count(x => x.Category.Type() == SearchResultTypeEnum.Page); }
        }

        public class SearchHit
        {
            public string Title { get; set; }
            public string Url { get; set; }
            public string Excerpt { get; set; }
            public SearchResultType Category { get; set; }
        }
    }
}