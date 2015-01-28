using System.Web.Mvc;
using FFCG.Utsikt.Web.Util;

namespace FFCG.Utsikt.Web.Controllers
{
    public class SitemapController : Controller
    {
        private readonly ISitemapFactory _sitemapFactory;

        public SitemapController(ISitemapFactory sitemapFactory)
        {
            _sitemapFactory = sitemapFactory;
        }

        [HttpGet]
        public EmptyResult Index()
        {
            Response.ContentType = "text/xml";
            Response.Write(_sitemapFactory.GetSiteMapAsXmlString());
            global::System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
            return new EmptyResult();
        }
    }
}