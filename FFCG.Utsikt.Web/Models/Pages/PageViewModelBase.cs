namespace FFCG.Utsikt.Web.Models.Pages
{
    public abstract class PageViewModelBase<TEpiData> : IPageViewModel<TEpiData> where TEpiData : PageBase
    {
        public PageViewModelBase()
        {
            
        }

        public PageViewModelBase(TEpiData epiData)
        {
            EpiData = epiData;
        }

        public TEpiData EpiData { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public bool IsInEditMode { get; set; }
    }
}