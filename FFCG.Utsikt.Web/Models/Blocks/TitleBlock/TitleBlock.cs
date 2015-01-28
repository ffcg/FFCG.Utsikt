using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace FFCG.Utsikt.Web.Models.Blocks.TitleBlock
{
    [ContentType(DisplayName = "TitleBlock", GUID = "03907aea-731f-43a9-804b-54f6eb7f79c5", Description = "Title block")]
    [ImageUrl(BlockInformation.PreviewImagePath + "titelblock.png")]
    public class TitleBlock : BlockBase
    {

        [CultureSpecific]
        [Display(
            Name = "Name",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual String Title { get; set; }

        [CultureSpecific]
        [Display(
            Name= "TitleIcon",
            Description = "TitleIcon for title",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Icon { get; set; }

    }
}