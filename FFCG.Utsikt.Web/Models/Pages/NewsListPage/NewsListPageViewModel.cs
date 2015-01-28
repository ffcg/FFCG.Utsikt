using System.Collections.Generic;

namespace FFCG.Utsikt.Web.Models.Pages.NewsListPage
{
    public class NewsListPageViewModel : PageViewModelBase<NewsListPage>
    {
        public IEnumerable<NewsItem> NewsItems { get; set; }
        public bool MoreItemsInCmsThanInList { get; set; }
    }
}