using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Web.Mvc;
using FFCG.Utsikt.Web.Util.Search;

namespace FFCG.Utsikt.Web.Models.Pages.SearchPage
{
    public class SearchPageController : PageController<SearchPage>
    {
        private const int MaxResults = 40;
        private readonly ISearchService _searchService;

        public SearchPageController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [ValidateInput(false)]
        public ViewResult Index(SearchPage currentPage, string q)
        {
            SearchPageViewModel model=new SearchPageViewModel(currentPage);
            if (!string.IsNullOrWhiteSpace(q))
            {
                model=Search(q.Trim(), currentPage.Language, currentPage);
            }

            return View(GetViewName(currentPage), model);
        }

        /// <summary>
        /// Performs a search for pages and media and maps each result to the view model class SearchHit.
        /// </summary>
        /// <remarks>
        /// The search functionality is handled by the injected EpiserverSearchService in order to keep the controller simple.
        /// Uses EPiServer Search. For more advanced search functionality such as keyword highlighting,
        /// facets and search statistics consider using EPiServer Find.
        /// </remarks>
        private SearchPageViewModel Search(string searchText, CultureInfo languageBranch, SearchPage currentPage)
        {
            var searchResults = _searchService.Search(searchText, languageBranch, MaxResults);

            return CreateSearchModel(searchResults, currentPage);
        }

        private SearchPageViewModel CreateSearchModel(ISearchResult searchResults, SearchPage currentPage)
        {
            return new SearchPageViewModel
            {
                EpiData = currentPage,
                SearchedQuery = searchResults.SearchedQuery,
                NumberOfHits = searchResults.NumberOfHits,
                Hits = searchResults.SearchHits.Select(CreateHitModel)
            };
        }

        private SearchPageViewModel.SearchHit CreateHitModel(ISearchHit hit)
        {   
            return new SearchPageViewModel.SearchHit
            {
                Title = hit.Title,
                Url = hit.Url,
                Excerpt = hit.HighlightQueryText,
                Category = hit.Category
            };
        }

        protected virtual string GetViewName(SearchPage currentPage)
        {
            return string.Format("~/Models/Pages/{0}/{0}.cshtml", currentPage.GetOriginalType().Name);
        }


    }
}
