using FFCG.Utsikt.Web.Helpers;

namespace FFCG.Utsikt.Web.Models.Pages.NewsPage
{
    public class NewsPageController : PageControllerBase<NewsPageViewModel,NewsPage>
    {
        protected override NewsPageViewModel CreateModel(NewsPage currentPage)
        {
            var newsPageViewModel = base.CreateModel(currentPage);

            newsPageViewModel.YearIfEarlinerThanThisYear =
                DateHelper.GetYearIfEarlierThanThisYear(newsPageViewModel.EpiData.StartPublish);


            return newsPageViewModel;
        }
    }
}