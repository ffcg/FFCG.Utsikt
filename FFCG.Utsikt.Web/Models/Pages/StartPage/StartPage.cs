using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace FFCG.Utsikt.Web.Models.Pages.StartPage
{
    [ContentType(DisplayName = "Start page", GUID = "3b1fc4cc-7ee5-4b5f-be77-0777b86a8062", Description = "OBS! Only one per site", GroupName = PageInforamtion.Categorization.Groups.FunctionalPages)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(StandardPage.StandardPage),typeof(StandardNoLeftNavPage.StandardNoLeftNavPage), typeof(SearchPage.SearchPage), 
        typeof(NewsListPage.NewsListPage), typeof(ContentAreaPage.ContentAreaPage), typeof(ContentAreaLeftNavPage.ContentAreaLeftNavPage)})]
    [ImageUrl(PageInforamtion.PreviewImagePath + "startpage.png")]
    public class StartPage : GlobalSettingsPage
    {

        [CultureSpecific]
        [Display(
            Name = "WhatIsLifImage",
            Description = "WhatIsLifImage",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference WhatIsLifImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main Content Title",
            Description = "Main Content Title",
            GroupName = SystemTabNames.Content,
            Order = 9)]
        public virtual string MainContentAreaTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main Content Area",
            Description = "Main Content Area",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual ContentArea MainContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Right Content Area",
            Description = "Right Content Area",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual ContentArea RightContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Bottom Content Title",
            Description = "Bottom Content Title",
            GroupName = SystemTabNames.Content,
            Order = 29)]
        public virtual string BottomContentAreaTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Bottom Content Area",
            Description = "Bottom Content Area",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual ContentArea BottomContentArea { get; set; }

   
    }
}