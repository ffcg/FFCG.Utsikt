using System.Linq;
using System.Web.Mvc;
using EPiServer.Editor;
using EPiServer.Web.Mvc.Html;
using FFCG.Utsikt.Web.Business;

namespace FFCG.Utsikt.Web.Components.TopBanner
{
    public class TopBannerController : Controller
    {

        private readonly IGlobalSettings _globalSettings;

        public TopBannerController(IGlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }

        public ActionResult Index()
        {
            return View("~/Components/TopBanner/TopBanner.cshtml",
                new TopBannerViewModel
                {
                    GlobalNavigation = _globalSettings.GlobalNavigation.Select(i=>new TopBannerViewModel.Link{Text = i.Text,Url = Url.ContentUrl(i.Href)}).ToList(),
                    IsInEditMode = PageEditing.PageIsInEditMode,
                    LifLogo = _globalSettings.Logo
                });
        }
    }
}
