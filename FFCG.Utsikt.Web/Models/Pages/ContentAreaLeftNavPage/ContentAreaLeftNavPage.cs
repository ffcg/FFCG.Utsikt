using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace FFCG.Utsikt.Web.Models.Pages.ContentAreaLeftNavPage
{
    [ContentType(DisplayName = "ContentAreaLeftNavPage", GUID = "ee181481-c6f7-4449-9cc5-f614c6c8381c", Description = "", GroupName = PageInforamtion.Categorization.Groups.SpecialPages)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(StandardPage.StandardPage), typeof(StandardNoLeftNavPage.StandardNoLeftNavPage) })]
    [ImageUrl(PageInforamtion.PreviewImagePath + "contentareapageleftnav.png")]
    public class ContentAreaLeftNavPage : PageBase
    {
        [CultureSpecific]
        [Display(
            Name = "ContentArea",
            Description = "ContentArea",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual ContentArea ContentArea { get; set; }
    }
}