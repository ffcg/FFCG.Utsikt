namespace FFCG.Utsikt.Web.Models.Pages.NewsPage
{
    public class NewsPageViewModel : PageViewModelBase<NewsPage>
    {
        public string ImageURL { get; set; }
        public bool ShowImage { get; set; }
        public string ShortPreamble { get; set; }
        public string YearIfEarlinerThanThisYear { get; set; }
      
    }
}