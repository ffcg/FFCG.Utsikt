using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Editor;

namespace FFCG.Utsikt.Web.Models.Blocks
{
    public abstract class BlockPreviewControllerBase<TViewModel, TEpiData> : BlockControllerBase<TViewModel, TEpiData>
        where TViewModel : BlockPreviewViewModelBase<TEpiData>, new()
        where TEpiData : BlockBase
    {

        public override ActionResult Index(TEpiData currentBlock)
        {
            var model = CreateModel(currentBlock);
            return View(GetViewName(currentBlock), model);
        }

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
            return new TViewModel {EpiData = currentContent, IsInEditMode = PageEditing.PageIsInEditMode, ContentArea =area};
        }

        protected override string GetLayout(TEpiData currentContent)
        {
            return "~/Views/Shared/_PreviewLayout.cshtml";
        }
    }
}

 