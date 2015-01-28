namespace FFCG.Utsikt.Web.Models.Blocks
{
    public interface IBlockTextAreaViewModel< out TEpiData> :  IBlockViewModel<TEpiData> where TEpiData : BlockTextAreaBase
    {
        string WidthCssClass { get; set; }
        string PositionCssClass { get; set; }
    }
}
