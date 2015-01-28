using System.Web.Mvc;
using EPiServer.Editor;
using FFCG.Utsikt.Web.Business;

namespace FFCG.Utsikt.Web.Components.SearchForm
{
    public class MobileSearchFormController : Controller
    {
        private readonly IGlobalSettings _globalSettings;

        public MobileSearchFormController(IGlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }

        public ActionResult Index()
        {
            return View("~/Components/SearchForm/MobileSearchForm.cshtml",
               new SearchFormViewModel
               {
                   SearchPageRoute = _globalSettings.SearchPageRoute,
                   IsInEditMode = PageEditing.PageIsInEditMode
               });
        }
    }
}