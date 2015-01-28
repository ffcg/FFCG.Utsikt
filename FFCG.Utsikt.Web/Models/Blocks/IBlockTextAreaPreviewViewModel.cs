using EPiServer.Core;

namespace FFCG.Utsikt.Web.Models.Blocks
{
    public interface IBlockTextAreaPreviewViewModel<out TEpiData> : IBlockPreviewViewModel<TEpiData>, IBlockTextAreaViewModel<TEpiData> where TEpiData : BlockTextAreaBase
    {
        ContentArea ContentArea { get; }
    }
}