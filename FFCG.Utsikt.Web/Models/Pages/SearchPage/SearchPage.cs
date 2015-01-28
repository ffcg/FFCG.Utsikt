using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using FFCG.Utsikt.Web.Util.Search;

namespace FFCG.Utsikt.Web.Models.Pages.SearchPage
{
    [ContentType(DisplayName = "Sökresultat", GUID = "2a825837-eabc-4bef-b4d5-388441b5d758", Description = "Använd för att presentera sökresultat.", GroupName = PageInforamtion.Categorization.Groups.FunctionalPages)]
    [AvailableContentTypes(Availability.None)]
    [ImageUrl(PageInforamtion.PreviewImagePath + "searchpage.png")]
    public class SearchPage : PageBase, IExcludeFromSearch
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 310)]
        [CultureSpecific]
        public virtual ContentArea RelatedContentArea { get; set; }
    }
}