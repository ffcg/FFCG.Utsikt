using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Routing;

namespace FFCG.Utsikt.Web.Components.LeftNavigation
{
    public class LeftNavigationController : Controller
    {
        
        private readonly IContentLoader _contentLoader;
        private readonly UrlResolver _urlResolver;
        public LeftNavigationController(IContentLoader contentLoader, UrlResolver urlResolver)
        {
            _contentLoader = contentLoader;
            _urlResolver = urlResolver;
        }

        public ActionResult Index(ContentReference currentPage)
        {
            return View("~/Components/LeftNavigation/LeftNavigation.cshtml",
                new LeftNavigationViewModel(currentPage ?? ContentReference.StartPage, GetSectionStartPage(currentPage)));
        }
        public virtual ContentReference GetSectionStartPage(ContentReference contentLink)
        {
            var currentContent = _contentLoader.Get<IContent>(contentLink);
            if (currentContent.ParentLink != null && currentContent.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage))
            {
                return currentContent.ContentLink;
            }

            return _contentLoader.GetAncestors(contentLink)
                .OfType<PageData>()
                .SkipWhile(x => x.ParentLink == null || !x.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage))
                .FirstOrDefault().ContentLink;
        }
    }
}