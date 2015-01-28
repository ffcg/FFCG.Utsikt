using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace FFCG.Utsikt.Web.Models.Blocks.YouTubeBlock
{
    [ContentType(DisplayName = "YouTubeBlock", GUID = "fb48c9c5-9c5b-436b-9f04-a658d204561d", Description = "")]
    [ImageUrl(BlockInformation.PreviewImagePath + "youtubeblock.png")]
    public class YouTubeBlock : BlockBase
    {

        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "Title field's description",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual String Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "VideoUrl",
            Description = "VideoUrl field's description",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual String VideoUrl { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Text field's description",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual String Text { get; set; }

    }
}