using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using FFCG.Utsikt.Web.Util.EditorDescriptors;

namespace FFCG.Utsikt.Web.Models.Blocks
{
    public class BlockTextAreaBase : BlockBase
    {
        [CultureSpecific]
        [Display(
            Name = "Width",
            Description = "The block width",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [BackingType(typeof(PropertyNumber))]
        [Enum(typeof(BlockTextAreaWidth))]
        public virtual BlockTextAreaWidth Width { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Position",
            Description = "Left or right position",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        [BackingType(typeof(PropertyNumber))]
        [Enum(typeof(BlockTextAreaPosition))]
        public virtual BlockTextAreaPosition Position { get; set; }
    }
}