using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Web.Routing;
using FFCG.Utsikt.Web.Business;
using FFCG.Utsikt.Web.Helpers;
using FFCG.Utsikt.Web.Models.Pages.NewsListPage;
using FFCG.Utsikt.Web.Models.Pages.NewsPage;
using Newtonsoft.Json;

namespace FFCG.Utsikt.Web.Controllers
{
    public class NewsFeedController :Controller
    {
        private readonly IContentRepository _contentRepository;
        private readonly IGlobalSettings _globalSettings;
        private readonly UrlResolver _urlResolver;

        public NewsFeedController(IContentRepository contentRepository, IGlobalSettings globalSettings, UrlResolver urlResolver)
        {
            _contentRepository = contentRepository;
            _globalSettings = globalSettings;
            _urlResolver = urlResolver;
        }
       
        public JsonResult Index()
        {
            var newspages = _contentRepository.GetChildren<NewsPage>(_globalSettings.NewsListPage);
            return Json(newspages.Select(p => new Jsonpage(p,_urlResolver)), JsonRequestBehavior.AllowGet);
        }
    }

    public class Jsonpage
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Preamble { get; set; }
        public string MainText { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }

        public Jsonpage(NewsPage newsPage, UrlResolver urlResolver)
        {
            ID = newsPage.PageLink.ID;
            Url =urlResolver.GetUrl(newsPage.PageLink);
            Name = newsPage.Name;
            Preamble = newsPage.Preamble.ToNonNullString();
            MainText = newsPage.MainText.ToNonNullString();
            ImageUrl = urlResolver.GetUrl(newsPage.Image);
            PublishDate = newsPage.StartPublish;

        }
    }
}