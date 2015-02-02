using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Routing;
using Microsoft.Ajax.Utilities;

namespace FFCG.Utsikt.Web.Controllers
{
    public class PageAsJsonController : Controller
    {
        private readonly IContentRepository _contentRepository;

        public PageAsJsonController(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public JsonResult Index()

        {

            var url = System.Web.HttpContext.Current.Request.QueryString["PageUrl"];
            var pagereference = Get(url);
            var page = _contentRepository.Get<Models.Pages.PageBase>(pagereference);
            return page.ToJson();
        }

        private ContentReference Get(string url)
        {
            if (url.ToLower().Contains("episerver/cms"))
            {
                var id = url.Split('/');
                return new ContentReference(int.Parse((id[id.Length - 2][id[id.Length - 2].Length-1]).ToString()));
            }
            return UrlResolver.Current.Route(new UrlBuilder(GetUrl(url))).ContentLink;
        }

        private string GetUrl(string url)
        {
            return string.Format("{0}{1}", SiteDefinition.Current.SiteUrl.ToString(), url);
        }
    }

}
