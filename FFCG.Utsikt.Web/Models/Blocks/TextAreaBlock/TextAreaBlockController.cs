namespace FFCG.Utsikt.Web.Models.Blocks.TextAreaBlock
{
    public class TextAreaBlockController : BlockControllerBase<TextAreaBlockViewModel, TextAreaBlock>
    {
        protected override TextAreaBlockViewModel CreateModel(TextAreaBlock currentContent)
        {
            var model= base.CreateModel(currentContent);
            model.BackgroundColorCssClass = currentContent.Color.GetCssClass();
            return model;
        }
    }
}