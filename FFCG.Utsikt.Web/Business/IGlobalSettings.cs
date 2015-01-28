using System.Web.Routing;
using EPiServer.Core;
using EPiServer.SpecializedProperties;

namespace FFCG.Utsikt.Web.Business
{
    public interface IGlobalSettings
    {
        RouteValueDictionary SearchPageRoute { get; set; }
        LinkItemCollection GlobalNavigation { get; set; }
        ContentArea SiteFooter { get; set; }
        ContentReference CalendarPage { get; set; }
        string RobotsTxtContent { get; set; }
        string GoogleAnalyticsAccount { get; set; }
        ContentReference Logo { get; set; }
    }
}