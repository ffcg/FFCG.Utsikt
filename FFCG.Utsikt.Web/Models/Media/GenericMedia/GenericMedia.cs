using EPiServer.Core;
using EPiServer.DataAnnotations;
using FFCG.Utsikt.Web.Helpers;
using FFCG.Utsikt.Web.Util.Search;

namespace FFCG.Utsikt.Web.Models.Media.GenericMedia
{
    [ContentType(GUID = "EE3BD195-7CB0-4756-AB5F-E5E223CD9820")]
    public class GenericMedia : MediaData, ISearchTextMatcher, IAmMedia
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual XhtmlString Description { get; set; }

        public string MatchText(string query, int textLength)
        {
            return Description != null ? Description.ToString().RemoveHtmlTags() : string.Empty;
        }
    }
}
