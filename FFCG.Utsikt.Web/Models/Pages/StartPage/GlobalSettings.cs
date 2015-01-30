using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace FFCG.Utsikt.Web.Models.Pages.StartPage
{
    public class GlobalSettingsPage: PageBase
    {
        [CultureSpecific]
        [Display(
            Name = "Search page link",
            Description = "Search page link",
            GroupName = PageInforamtion.Categorization.Tabs.SiteSettings,
            Order = 100)]
        public virtual PageReference SearchPageLink { get; set; }

        [CultureSpecific]
        [Display(
            Name = "LifLogo",
            Description = "Lif Logo",
            GroupName = PageInforamtion.Categorization.Tabs.SiteSettings,
            Order = 105)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Logo { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Global Navigation List",
            Description = "Global Navigation List",
            GroupName = PageInforamtion.Categorization.Tabs.SiteSettings,
            Order = 110)]
        public virtual LinkItemCollection GlobalNavigationList { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Footer Content Area",
            Description = "Footer Content Area",
            GroupName = PageInforamtion.Categorization.Tabs.SiteSettings,
            Order = 120)]
        public virtual ContentArea FooterContentArea { get; set; }

        [Required]
        [CultureSpecific]
        [Display(
            Name = "Calendar Page",
            Description = "CalendarPage",
            GroupName = PageInforamtion.Categorization.Tabs.SiteSettings,
            Order = 130)]
        public virtual PageReference CalendarPage { get; set; }

        [Required]
        [CultureSpecific]
        [Display(
            Name = "RobotsTxtContent",
            Description = "RobotsTxtContent",
            GroupName = PageInforamtion.Categorization.Tabs.SiteSettings,
            Order = 140)]
        public virtual XhtmlString RobotsTxtContent { get; set; }

        [Required]
        [CultureSpecific]
        [Display(
            Name = "GoogleAnalyticsAccount",
            Description = "GoogleAnalyticsAccount",
            GroupName = PageInforamtion.Categorization.Tabs.SiteSettings,
            Order = 150)]
        public virtual string GoogleAnalyticsAccount { get; set; }

        [CultureSpecific]
        [Display(
            Name = "NewsListPage",
            Description = "NewsListPage",
            GroupName = PageInforamtion.Categorization.Tabs.SiteSettings,
            Order = 160)]
        public virtual ContentReference NewsListPage { get; set; }
    }
}
