using System.Web.Routing;
using EPiServer;
using EPiServer.Core;
using EPiServer.SpecializedProperties;
using FFCG.Utsikt.Web.Helpers;
using FFCG.Utsikt.Web.Models.Pages.StartPage;

namespace FFCG.Utsikt.Web.Business
{
    public class GlobalSettings : IGlobalSettings
    {
        public GlobalSettings(IContentLoader contentLoader, RequestContext requestContext)
        {
            var startPage = contentLoader.Get<StartPage>(PageReference.StartPage);
            SearchPageRoute = requestContext.GetPageRoute(startPage.SearchPageLink);
            GlobalNavigation = startPage.GlobalNavigationList??new LinkItemCollection();
            SiteFooter = startPage.FooterContentArea;
            CalendarPage = startPage.CalendarPage??PageReference.StartPage;
            RobotsTxtContent = startPage.RobotsTxtContent != null ? startPage.RobotsTxtContent.ToString().RemoveHtmlTags() : string.Empty;
            GoogleAnalyticsAccount = startPage.GoogleAnalyticsAccount;
            Logo = startPage.Logo;
        }
        public RouteValueDictionary SearchPageRoute { get; set; }
        public LinkItemCollection GlobalNavigation { get; set; }
        public ContentArea SiteFooter { get; set; }
        public ContentReference CalendarPage { get; set; }
        public string RobotsTxtContent { get; set; }
        public string GoogleAnalyticsAccount { get; set; }
        public ContentReference Logo { get; set; }
    }
}