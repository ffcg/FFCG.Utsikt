using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer;
using FFCG.Utsikt.Web.Helpers;

namespace FFCG.Utsikt.Web.Models.Pages.NewsListPage
{
    public class NewListPageController : PageControllerBase<NewsListPageViewModel,NewsListPage>
    {
        private readonly IContentLoader _contentLoader;

        public NewListPageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        protected override NewsListPageViewModel CreateModel(NewsListPage currentPage)
        {
            var model= base.CreateModel(currentPage);
            var newsItems = GetNewsItemsList(currentPage);
            var totalNumberOfItems = newsItems.Count();
            model.NewsItems = SetNewsListLenght(newsItems, currentPage);
            model.MoreItemsInCmsThanInList = totalNumberOfItems > model.NewsItems.Count();
            return model;
        }

        private IEnumerable<NewsItem> SetNewsListLenght(IEnumerable<NewsItem> items,NewsListPage currentPage)
        {
            if (currentPage.MaxMonths > 0)
            {
                items = GetNewsForMaxMonth(currentPage.MaxMonths, items);
            }
            if (currentPage.MaxItems > 0)
            {
                items=items.Take(currentPage.MaxItems);
            }
            return items;
        }

        private IEnumerable<NewsItem> GetNewsItemsList(NewsListPage currentPage)
        {
            return _contentLoader.GetChildren<NewsPage.NewsPage>(currentPage.ContentLink)
                .Select(x => 
                    new NewsItem { Title = x.PageName, 
                        Image = x.Image,
                        PublishDate =  x.StartPublish,
                        PageLink = x.PageLink,
                        Preamble = x.Preamble!=null? x.Preamble.ToString().RemoveHtmlTags():String.Empty }
                );
        }

        private IEnumerable<NewsItem> GetNewsForMaxMonth(int maxMonths, IEnumerable<NewsItem> items)
        {
            var month = DateTime.Today.AddMonths(-maxMonths);
            var compareMonth = new DateTime(month.Year, month.Month, 1);
            return items.Where(x => x.PublishDate.CompareTo(compareMonth) >= 0);
        }
    }
}