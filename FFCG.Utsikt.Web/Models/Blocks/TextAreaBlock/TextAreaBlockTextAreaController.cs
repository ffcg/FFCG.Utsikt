using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using FFCG.Utsikt.Web.Business.Renderer;

namespace FFCG.Utsikt.Web.Models.Blocks.TextAreaBlock
{
  [TemplateDescriptor(Inherited = true, TemplateTypeCategory = TemplateTypeCategories.MvcPartialController,
            Tags = new[] { ContentAreaTags.InlineTextArea}, AvailableWithoutTag = false)]
    public class TextAreaBlockTextAreaController : BlockTextAreaControllerBase<TextAreaBlockViewModel, TextAreaBlock> 
    {

      protected override TextAreaBlockViewModel CreateModel(TextAreaBlock currentContent)
          {
              var model = base.CreateModel(currentContent);
              model.BackgroundColorCssClass = currentContent.Color.GetCssClass();
              return model;
          }
    }
}
