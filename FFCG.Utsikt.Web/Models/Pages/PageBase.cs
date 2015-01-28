using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using FFCG.Utsikt.Web.Helpers;
using FFCG.Utsikt.Web.Util.Search;

namespace FFCG.Utsikt.Web.Models.Pages
{
    public class PageBase : PageData, ISearchTextMatcher
    {
        private static class Tabs
        {
            public const string MetaTag = "Meta tags";
        }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Meta Title",
            Description = "..",
            GroupName = Tabs.MetaTag,
            Order = 1)]
        public virtual string MetaTitle { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Meta Description",
            Description = "..",
            GroupName = Tabs.MetaTag,
            Order = 2)]
        public virtual string MetaDescription { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Meta Tags",
            Description = "..",
            GroupName = Tabs.MetaTag,
            Order = 2)]
        public virtual string MetaTags { get; set; }

        public virtual string MatchText(string query, int length)
        {
            return MatchQueryInProperties(this.Property.Select(PropertyToString), query, length);
        }

        protected virtual string PropertyToString(PropertyData property)
        {
            if (property != null && property.Value != null)
            {
                return property.ToString();
            }
            return string.Empty;
        }

        protected virtual string MatchQueryInProperties(IEnumerable<string> properties, string query, int length)
        {
            foreach (var property in properties)
            {
                    var matchString = property.RemoveHtmlTags();
                    var index = matchString.IndexOf(query);
                    if (index != -1)
                    {
                        return GetMatchingText(matchString, index, length);
                    }             
            }
            return GetFallbackSearchText();
        }

        protected virtual string GetMatchingText(string propertyValue, int index, int length)
        {
            if (index >= length/2)
            {
                return propertyValue.ToSubstring(index - length/2, length);
            }
            return propertyValue.ToSubstring(0, length);
        }

        public virtual string GetFallbackSearchText()
        {
            return this.MetaDescription??string.Empty;
        }

        public bool ShowInSiteMap()
        {
            return this.IsVisibleOnSite()&&this.VisibleInMenu;
        }
    }
}