using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using FFCG.Utsikt.Web.Business.Renderer;

namespace FFCG.Utsikt.Web.Models.Blocks
{
    [TemplateDescriptor(Inherited = true, TemplateTypeCategory = TemplateTypeCategories.MvcPartialController,
             Tags = new[] { ContentAreaTags.InlineTextArea }, AvailableWithoutTag = false)]
    public abstract class BlockTextAreaControllerBase<TViewModel, TEpiData> : BlockControllerBase<TViewModel, TEpiData>
        where TViewModel : BlockTextAreaViewModelBase<TEpiData>, new()
        where TEpiData : BlockTextAreaBase
    {
        protected override string GetLayout(TEpiData currentContent)
        {
            return "~/Views/Shared/_TextAreaBlockLayout.cshtml";
        }

        protected override TViewModel CreateModel(TEpiData currentContent)
        {
            var model= base.CreateModel(currentContent);
            model.PositionCssClass = currentContent.Position.GetCssClass();
            model.WidthCssClass = currentContent.Width.GetCssClass();
            return model;
        }
    }
}