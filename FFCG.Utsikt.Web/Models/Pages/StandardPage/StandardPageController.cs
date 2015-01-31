using System.Web.Mvc;

namespace FFCG.Utsikt.Web.Models.Pages.StandardPage
{
    public class StandardPageController : PageControllerBase<StandardPageViewModel, StandardPage>
    {
        public override ActionResult Index(StandardPage currentPage)
        {
            var model = CreateModel(currentPage);
            return View("InitialPage");
        }       
    }
}