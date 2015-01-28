using System.Web.Mvc;
using EPiServer.Core;

namespace FFCG.Utsikt.Web.Components.TopNavigation
{
    public class TopNavigationController : Controller
    {
        //
        // GET: /TopMenu/

        public ActionResult Index(PageReference currentPage)
        {
            return View("~/Components/TopNavigation/TopNavigation.cshtml", new TopNavigationViewModel(currentPage??PageReference.StartPage));
        }

    }
}
