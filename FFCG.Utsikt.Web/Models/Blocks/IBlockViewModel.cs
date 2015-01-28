namespace FFCG.Utsikt.Web.Models.Blocks
{
    public interface IBlockViewModel<out TEpiData> where TEpiData : BlockBase
    {
        TEpiData EpiData { get;}
        bool IsInEditMode { get; set; }
        string Layout { get; set; }
    }
}
