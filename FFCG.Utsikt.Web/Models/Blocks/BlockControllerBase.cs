using System.Web.Mvc;
using EPiServer;
using EPiServer.Editor;
using EPiServer.Web.Mvc;

namespace FFCG.Utsikt.Web.Models.Blocks
{
    public abstract class BlockControllerBase<TViewModel, TEpiData> : BlockController<TEpiData> 
        where TViewModel : BlockViewModelBase<TEpiData>, new()
        where TEpiData : BlockBase
    {

        public override ActionResult Index(TEpiData currentBlock)
        {
            var model = CreateModel(currentBlock);
            return View(GetViewName(currentBlock), model);
        }

        protected virtual string GetViewName(TEpiData currentContent)
        {
            return string.Format("~/Models/Blocks/{0}/{0}.cshtml", currentContent.GetOriginalType().Name);
        }

        protected virtual TViewModel CreateModel(TEpiData currentContent)
        {
            return new TViewModel {EpiData = currentContent, IsInEditMode = PageEditing.PageIsInEditMode,Layout = GetLayout(currentContent)};
        }

        protected virtual string GetLayout(TEpiData currentContent)
        {
            return null;
        }
    }
}