using System.Collections.Generic;
using EPiServer.Core;

namespace FFCG.Utsikt.Web.Components.TopBanner
{
    public class TopBannerViewModel
    {
        public TopBannerViewModel()
        {
            GlobalNavigation = new List<Link>();
        }
        public IEnumerable<Link> GlobalNavigation { get; set; }
        public bool IsInEditMode { get; set; }
        public ContentReference LifLogo { get; set; }
        public string LifLogoLink { get; set; }
        public class Link
        {
            public string Text { get; set; }
            public string Url { get; set; }
        }
    }
}