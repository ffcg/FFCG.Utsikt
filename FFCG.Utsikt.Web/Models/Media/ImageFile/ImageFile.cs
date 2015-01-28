using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using FFCG.Utsikt.Web.Util.Search;

namespace FFCG.Utsikt.Web.Models.Media.ImageFile
{
    [ContentType(GUID = "0A89E464-56D4-449F-AEA8-2BF774AB8730")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFile : ImageData, IExcludeFromSearch
    {
        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        /// <value>
        /// The copyright.
        /// </value>
        public virtual string Copyright { get; set; }
    }
}
