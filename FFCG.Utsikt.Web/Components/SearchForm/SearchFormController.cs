using System.Web.Mvc;
using EPiServer.Editor;
using FFCG.Utsikt.Web.Business;

namespace FFCG.Utsikt.Web.Components.SearchForm
{
    public class SearchFormController : Controller
    {
        private readonly IGlobalSettings _globalSettings;

        public SearchFormController(IGlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }

        public ActionResult Index()
        {
            return View("~/Components/SearchForm/SearchForm.cshtml",
                new SearchFormViewModel
                {
                    SearchPageRoute = _globalSettings.SearchPageRoute,
                    IsInEditMode = PageEditing.PageIsInEditMode
                });
        }
    }
}