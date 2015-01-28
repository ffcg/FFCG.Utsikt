using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.Web;
using FFCG.Utsikt.Web.Helpers;

namespace FFCG.Utsikt.Web.Models.Pages.NewsListPage
{
    public class NewsItem   
    {
        public string Title { get; set; }
        public string Preamble { get; set; }
        public DateTime PublishDate { get; set; }

        public string YearIfEarlinerThanThisYear
        {
            get { return DateHelper.GetYearIfEarlierThanThisYear(this.PublishDate); }
        }

        [UIHint(UIHint.Image)]
        public ContentReference Image { get; set; }
        public ContentReference PageLink { get; set; }
    }
}