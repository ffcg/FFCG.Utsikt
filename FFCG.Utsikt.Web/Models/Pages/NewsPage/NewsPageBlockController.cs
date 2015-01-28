using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc.Html;
using FFCG.Utsikt.Web.Helpers;

namespace FFCG.Utsikt.Web.Models.Pages.NewsPage
{
    [TemplateDescriptor(TemplateTypeCategory = TemplateTypeCategories.MvcPartialController, Inherited = true)]
    public class NewsPageBlockController : PageBlockControllerBase<NewsPageViewModel,NewsPage>
    {

        protected override NewsPageViewModel CreateModel(NewsPage currentPage)
        {
            var m = base.CreateModel(currentPage);
            m.ImageURL = GetImageUrl(currentPage);
            m.ShowImage = !string.IsNullOrEmpty(m.ImageURL);
            m.ShortPreamble = currentPage.BlockText != null ? currentPage.BlockText.ToString().RemoveHtmlTags() : string.Empty;
            m.YearIfEarlinerThanThisYear = DateHelper.GetYearIfEarlierThanThisYear(m.EpiData.StartPublish);
            return m;
        }

        private string GetImageUrl(NewsPage currentPage)
        {
            return Url.ContentUrl(currentPage.BlockImage ?? currentPage.Image);
        }
    }
}
