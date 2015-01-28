using EPiServer.Core;

namespace FFCG.Utsikt.Web.Components.LeftNavigation
{
    public class LeftNavigationViewModel
    {
        public ContentReference CurrentPage { get; set; }
        public ContentReference SectionStartPage { get; set; }

        public LeftNavigationViewModel(ContentReference currentPage, ContentReference sectionStartPage)
        {
            SectionStartPage = sectionStartPage;
            CurrentPage = currentPage;
        }
    }
}