using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using FFCG.Utsikt.Web.Business;
using FFCG.Utsikt.Web.Models.Pages.NewsListPage;
using FFCG.Utsikt.Web.Models.Pages.NewsPage;
using Newtonsoft.Json;

namespace FFCG.Utsikt.Web.Controllers
{
    public class NewsFeedController :Controller
    {
        private readonly IContentRepository _contentRepository;
        private readonly IGlobalSettings _globalSettings;

        public NewsFeedController(IContentRepository contentRepository, IGlobalSettings globalSettings)
        {
            _contentRepository = contentRepository;
            _globalSettings = globalSettings;
        }
       
        public JsonResult Index()
        {
            var newspages = _contentRepository.GetChildren<NewsPage>(_globalSettings.NewsListPage);
            return Json(JsonConvert.SerializeObject(newspages.Select(p => new Jsonpage(p))), JsonRequestBehavior.AllowGet);
        }
    }

    public class Jsonpage
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public Jsonpage(NewsPage newsPage)
        {
            ID = newsPage.PageLink.ID;
            Url = newsPage.ExternalURL;
            Name = newsPage.Name;
        }
    }
}