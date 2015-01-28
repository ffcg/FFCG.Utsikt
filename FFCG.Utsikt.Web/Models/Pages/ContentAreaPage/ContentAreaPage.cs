using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace FFCG.Utsikt.Web.Models.Pages.ContentAreaPage
{
    [ContentType(DisplayName = "ContentAreaPage", GUID = "b0219ec9-41b7-48a5-a89e-490bc6e917fb", Description = "", GroupName = PageInforamtion.Categorization.Groups.SpecialPages)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(StandardPage.StandardPage), typeof(StandardNoLeftNavPage.StandardNoLeftNavPage) })]
    [ImageUrl(PageInforamtion.PreviewImagePath + "contentareapage.png")]
    public class ContentAreaPage : PageBase
    {

        [CultureSpecific]
        [Display(
            Name = "MainContentArea",
            Description = "MainContentArea",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual ContentArea MainContentArea { get; set; }

    }
}