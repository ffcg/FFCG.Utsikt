using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.XForms;

namespace FFCG.Utsikt.Web.Models.Blocks.FormBlock
{
    [ContentType(DisplayName = "FormBlock", GUID = "5e719bfb-c6c8-4912-b230-a492987533b8", Description = "")]
    [ImageUrl(BlockInformation.PreviewImagePath + "formblock.png")]
    public class FormBlock : BlockBase
    {

        [Display(
         GroupName = SystemTabNames.Content,
         Order = 1)]
        [CultureSpecific]
        public virtual string Heading { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 2)]
        [CultureSpecific]
        public virtual XForm Form { get; set; }
         
    }
}