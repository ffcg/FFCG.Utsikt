using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using FFCG.Utsikt.Web.Util.Search;

namespace FFCG.Utsikt.Web.Models.Pages.NewsListPage
{
    [ContentType(DisplayName = "Nyhetslista", GUID = "cf58832f-6809-4a68-a659-1bd361963572", Description = "Listar samtliga undersidor (nyheter).", GroupName = PageInforamtion.Categorization.Groups.NewsPages)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(NewsPage.NewsPage) })]
    [ImageUrl(PageInforamtion.PreviewImagePath + "newslistpage.png")]
    public class NewsListPage : PageBase, IExcludeFromSearch
    {
        [CultureSpecific]
        [Display(
            Name = "Right Content Area",
            Description = "Right Content Area",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual ContentArea RightContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "MaxItems",
            Description = "MaxItems",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual int MaxItems { get; set; }


        [CultureSpecific]
        [Display(
            Name = "MaxMonths",
            Description = "MaxMonths",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual int MaxMonths { get; set; }

        
    }
}