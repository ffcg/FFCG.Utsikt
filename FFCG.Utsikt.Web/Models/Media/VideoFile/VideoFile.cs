using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using FFCG.Utsikt.Web.Util.Search;

namespace FFCG.Utsikt.Web.Models.Media.VideoFile
{
    [ContentType(GUID = "85468104-E06F-47E5-A317-FC9B83D3CBA6")]
    [MediaDescriptor(ExtensionString = "flv,mp4,webm")]
    public class VideoFile : VideoData, IExcludeFromSearch
    {
        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        public virtual string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the URL to the preview image.
        /// </summary>
        [UIHint(UIHint.Image)]
        public virtual ContentReference PreviewImage { get; set; }
    }
}
