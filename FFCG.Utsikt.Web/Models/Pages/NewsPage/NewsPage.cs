using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using FFCG.Utsikt.Web.Helpers;

namespace FFCG.Utsikt.Web.Models.Pages.NewsPage
{
    [ContentType(DisplayName = "Nyhetssida", GUID = "25efa36b-d0a1-476a-aca1-ed25b714bcdf", Description = "Använd för att exempelvis publicera nyheter ...", GroupName = PageInforamtion.Categorization.Groups.NewsPages)]
    [AvailableContentTypes(Availability.None)]
    [ImageUrl(PageInforamtion.PreviewImagePath + "newspage.png")]
    public class NewsPage : PageBase, IAmNewsPage
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
                    Name = "ChangedDateText",
                    Description = "ChangedDateText",
                    GroupName = SystemTabNames.Content,
                    Order = 35)]
                public virtual string ChangedDateText { get; set; }

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
                    Order = 50)]
                public virtual ContentArea RightContentArea { get; set; }

                [CultureSpecific]
                [Display(
                    Name = "Blocktext",
                    Description = "Blocktext",
                    GroupName = SystemTabNames.Content,
                    Order = 60)]
                public virtual XhtmlString BlockText { get; set; }

                [CultureSpecific]
                [Display(
                    Name = "Blockimage",
                    Description = "Blockimage",
                    GroupName = SystemTabNames.Content,
                    Order = 70)]
                [UIHint(UIHint.Image)]
                public virtual ContentReference BlockImage { get; set; }

                public override string GetFallbackSearchText()
                {
                    return Preamble != null ? Preamble.ToString() : string.Empty;
                }

        public override string MatchText(string query, int length)
        {
            return base.MatchQueryInProperties(new List<string> { Preamble.ToNonNullString(), MainText.ToNonNullString() }, query, length);
        }
    }
}