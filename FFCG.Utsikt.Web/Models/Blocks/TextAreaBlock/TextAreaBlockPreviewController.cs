using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;

namespace FFCG.Utsikt.Web.Models.Blocks.TextAreaBlock
{
        [TemplateDescriptor( Inherited = true, TemplateTypeCategory = TemplateTypeCategories.MvcController, 
            Tags = new[] { RenderingTags.Preview, RenderingTags.Edit }, AvailableWithoutTag = false)]
    public class TextAreaBlockPreviewController : BlockTextAreaPreviewControllerBase<TextAreaBlockPreviewViewModel, TextAreaBlock>
    {
            protected override TextAreaBlockPreviewViewModel CreateModel(TextAreaBlock currentContent)
        {
            var model = base.CreateModel(currentContent);
            model.BackgroundColorCssClass = currentContent.Color.GetCssClass();
            return model;
        }
    }
}