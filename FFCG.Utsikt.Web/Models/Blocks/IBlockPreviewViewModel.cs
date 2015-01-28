using EPiServer.Core;

namespace FFCG.Utsikt.Web.Models.Blocks
{
    public interface IBlockPreviewViewModel<out TEpiData>: IBlockViewModel<TEpiData> where TEpiData : BlockBase
    {
        ContentArea ContentArea { get; }
    }
}