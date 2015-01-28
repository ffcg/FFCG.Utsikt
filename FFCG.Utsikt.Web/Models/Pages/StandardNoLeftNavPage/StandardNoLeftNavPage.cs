using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using FFCG.Utsikt.Web.Helpers;

namespace FFCG.Utsikt.Web.Models.Pages.StandardNoLeftNavPage
{
    [ContentType(DisplayName = "StandardNoLeftNavPage", GUID = "f02b9d14-2be7-461b-b3fc-b99fc883966b", Description = "")]
    [AvailableContentTypes(Availability.All)]
    [ImageUrl(PageInforamtion.PreviewImagePath + "standardnoleftnavpage.png")]
    public class StandardNoLeftNavPage : PageBase
    {
        [CultureSpecific]
        [Display(
            Name = "Image",
            Description = "The Image of the news",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Preamble",
            Description = "The preamble of the news",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString Preamble { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main Text",
            Description = "The main text of the news",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual XhtmlString MainText { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main Content Area",
            Description = "Main Content Area",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual ContentArea MainContentArea { get; set; }
        
        [CultureSpecific]
        [Display(
            Name = "Right Content Area",
            Description = "Right Content Area",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual ContentArea RightContentArea { get; set; }

        public override string MatchText(string query, int length)
        {
            return base.MatchQueryInProperties(new List<string> { Preamble.ToNonNullString(), MainText.ToNonNullString() }, query, length);
        }
    }
}