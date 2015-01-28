using EPiServer.Core;

namespace FFCG.Utsikt.Web.Models.Blocks
{
    public class BlockPreviewViewModelBase<TEpiData> : BlockViewModelBase<TEpiData>, IBlockPreviewViewModel<TEpiData> where TEpiData : BlockBase
    {
        public ContentArea ContentArea { get; set; }
    }
}