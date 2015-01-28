using EPiServer.Core;

namespace FFCG.Utsikt.Web.Models.Blocks.Preview
{
    public class PreviewViewModel
    {
        public IContent PreviewContent { get; set; }
        public ContentArea Area { get; set; }
    }
}