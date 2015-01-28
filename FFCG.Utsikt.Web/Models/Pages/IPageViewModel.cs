namespace FFCG.Utsikt.Web.Models.Pages
{
    public interface IPageViewModel<out TEpiData> where TEpiData : PageBase
    {
        TEpiData EpiData { get; }
        string MetaTitle { get; set; }
        string MetaDescription { get; set; }
    }
}