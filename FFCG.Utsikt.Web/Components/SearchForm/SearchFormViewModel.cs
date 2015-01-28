using System.Web.Routing;

namespace FFCG.Utsikt.Web.Components.SearchForm
{
    public class SearchFormViewModel
    {
        public RouteValueDictionary SearchPageRoute { get; set; }
        public bool IsInEditMode { get; set; }
    }
}