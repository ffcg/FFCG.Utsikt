using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Routing;

namespace FFCG.Utsikt.Web.Controllers
{
    public class PageAsJsonController : Controller
    {
        private readonly IContentRepository _contentRepository;

        public PageAsJsonController(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public JsonResult Index(string url)
        {
            var pagereference = UrlResolver.Current.Route(new UrlBuilder(GetUrl(url)));
            var page = _contentRepository.Get<Models.Pages.PageBase>(pagereference.ContentLink);
            return page.ToJson();
        }
        private string GetUrl(string url)
        {
            return string.Format("{0}{1}", SiteDefinition.Current.SiteUrl.ToString(), url);
        }
    }

}
