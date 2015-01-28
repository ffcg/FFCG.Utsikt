using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using FFCG.Utsikt.Web.Helpers;

namespace FFCG.Utsikt.Web.Models.Pages.StandardPage
{
    [ContentType(DisplayName = "Standard nyhetsartikell", GUID = "c9470f15-f967-4a53-a62a-6fd0803fd7c3", Description = "Använd till att ...")]
    [AvailableContentTypes(Availability.All)]
    [ImageUrl(PageInforamtion.PreviewImagePath + "standardpage.png")]
    public class StandardPage : PageBase
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
            Name = "Title",
            Description = "Title",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Title { get; set; }

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

        public override string MatchText(string query, int length)
        {
            return base.MatchQueryInProperties(new List<string> { Preamble.ToNonNullString(), MainText.ToNonNullString() }, query, length);
        }
    }
}