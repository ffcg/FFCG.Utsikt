using EPiServer.Core;

namespace FFCG.Utsikt.Web.Components.TopNavigation
{
    public class TopNavigationViewModel
    {
        public PageReference CurrentPage { get; set; }

        public TopNavigationViewModel(PageReference currentPage)
        {
            CurrentPage = currentPage;
        }
    }
}