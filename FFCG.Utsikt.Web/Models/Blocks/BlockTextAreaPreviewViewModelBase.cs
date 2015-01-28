using EPiServer.Core;

namespace FFCG.Utsikt.Web.Models.Blocks
{
    public class BlockTextAreaPreviewViewModelBase<TEpiData> : BlockTextAreaViewModelBase<TEpiData>, IBlockTextAreaPreviewViewModel<TEpiData> where TEpiData : BlockTextAreaBase
    {
        public ContentArea ContentArea { get; set; }
    }
}