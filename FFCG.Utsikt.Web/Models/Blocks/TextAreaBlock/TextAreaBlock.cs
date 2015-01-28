using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using FFCG.Utsikt.Web.Util.EditorDescriptors;

namespace FFCG.Utsikt.Web.Models.Blocks.TextAreaBlock
{
    [ContentType(DisplayName = "TextAreaBlock", GUID = "ab97cac1-9282-458f-aa4c-1dbe4201f442", Description = "", GroupName = BlockInformation.Categorization.Groups.TextAreaBlocks)]
    [ImageUrl(BlockInformation.PreviewImagePath + "textareablock.png")]
    public class TextAreaBlock : BlockTextAreaBase
    {
        [CultureSpecific]
        [Display(
            Name = "Image",
            Description = "The Image of the news",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "The Title of the news",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main Text",
            Description = "The main text of the news",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual XhtmlString MainText { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Color",
            Description = "The block background color",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        [BackingType(typeof(PropertyNumber))]
        [Enum(typeof(TextAreaBlockColor))]
        public virtual TextAreaBlockColor Color { get; set; }



    }
}