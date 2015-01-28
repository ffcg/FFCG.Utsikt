using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace FFCG.Utsikt.Web.Models.Blocks.TextBlock
{
    [ContentType(DisplayName = "HTML", GUID = "d4f75b1c-f7c6-48d2-9743-314ebfa2b868", Description = "Använd för att placera valfri innehåll på önskad plats. Dra in bilder, text och länkar.")]
    [ImageUrl(BlockInformation.PreviewImagePath + "textblock.png")]
    public class TextBlock : BlockBase
    {

        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Text field's description",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString Text { get; set; }

    }
}