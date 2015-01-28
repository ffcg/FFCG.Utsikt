namespace FFCG.Utsikt.Web.Models.Blocks
{
    public class BlockTextAreaViewModelBase<TEpiData> :BlockViewModelBase<TEpiData>, IBlockTextAreaViewModel<TEpiData> where TEpiData : BlockTextAreaBase
    {

        public BlockTextAreaViewModelBase()
        {
            
        }
        public string WidthCssClass { get; set; }
        public string PositionCssClass { get; set; }
    }
}