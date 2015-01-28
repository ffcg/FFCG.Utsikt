using EPiServer;
using EPiServer.Core;
using EPiServer.Editor;

namespace FFCG.Utsikt.Web.Models.Blocks
{
    public class BlockTextAreaPreviewControllerBase<TViewModel, TEpiData> : BlockTextAreaControllerBase<TViewModel, TEpiData>
        where TViewModel : BlockTextAreaPreviewViewModelBase<TEpiData>, new()
        where TEpiData : BlockTextAreaBase
    {
        protected override string GetViewName(TEpiData currentContent)
        {
            return string.Format("~/Models/Blocks/{0}/{0}Preview.cshtml", currentContent.GetOriginalType().Name);
        }

        protected override TViewModel CreateModel(TEpiData currentContent)
        {
            // set flag
            ViewBag.IsInEditMode = true;

            var area = new ContentArea();
            area.Items.Add(new ContentAreaItem
            {
                ContentLink = ((IContent)currentContent).ContentLink
            });
            return new TViewModel { EpiData = currentContent, IsInEditMode = PageEditing.PageIsInEditMode, ContentArea = area , Layout = GetLayout(currentContent)};
        }

        protected override string GetLayout(TEpiData currentContent)
        {
            return "~/Views/Shared/_PreviewTextAreaLayout.cshtml";
        }
    }
}