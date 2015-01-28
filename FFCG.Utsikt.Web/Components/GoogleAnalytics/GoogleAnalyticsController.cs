using System.Web.Mvc;
using FFCG.Utsikt.Web.Business;

namespace FFCG.Utsikt.Web.Components.GoogleAnalytics
{
    public class GoogleAnalyticsController : Controller
    {
        private readonly IGlobalSettings _globalSettings;

        public GoogleAnalyticsController(IGlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }

        public ActionResult Index()
        {
            var model = new GoogleAnalyticsViewModel {GoogleAnalyticsAccount = _globalSettings.GoogleAnalyticsAccount};
            return View("~/Components/GoogleAnalytics/GoogleAnalytics.cshtml", model);
        }

    }
}
