using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using EPiServer;
using EPiServer.Core;
using EPiServer.Data.Dynamic;
using EPiServer.Web.Mvc.Html;
using HtmlAgilityPack;

namespace FFCG.Utsikt.Web.Business.Renderer
{
    public class BootstrapAwareContentAreaRenderer : ContentAreaRenderer
    {
        private static bool _fallbackCached;
        private static IEnumerable<DisplayModeFallback> _fallbacks;

        protected override string GetContentAreaItemCssClass(HtmlHelper htmlHelper, ContentAreaItem contentAreaItem)
        {
            var tag = GetContentAreaItemTemplateTag(htmlHelper, contentAreaItem);
            return string.Format("block {0} {1} {2}", GetTypeSpecificCssClasses(contentAreaItem, ContentRepository), GetCssClassesForTag(tag), tag);
        }

        protected override void RenderContentAreaItems(HtmlHelper htmlHelper, IEnumerable<ContentAreaItem> contentAreaItems)
        {
            var itemRows = GroupContentAreaItemsInRows(contentAreaItems, htmlHelper);

            foreach (var row in itemRows)
            {
                htmlHelper.ViewContext.Writer.WriteLine("<div class=\"row\">");
                foreach ( var contentAreaItem in row)
                {
                    RenderContentAreaItem(htmlHelper, contentAreaItem, this.GetContentAreaItemTemplateTag(htmlHelper, contentAreaItem), this.GetContentAreaItemHtmlTag(htmlHelper, contentAreaItem), this.GetContentAreaItemCssClass(htmlHelper, contentAreaItem));
                }
                htmlHelper.ViewContext.Writer.WriteLine("</div>");
            }
        }

        private List<List<ContentAreaItem>> GroupContentAreaItemsInRows(IEnumerable<ContentAreaItem> contentAreaItems, HtmlHelper htmlHelper)
        {
            var returnList = new List<List<ContentAreaItem>>();
            var rowlist = new List<ContentAreaItem>();
            var columsLeft = 12;
            foreach (var contentAreaItem in contentAreaItems)
            { 
                if (CantFitIntoRow(columsLeft, contentAreaItem, htmlHelper))
                {
                    rowlist.Add(contentAreaItem);
                    columsLeft = columsLeft - GetContentAreaColumnCount(contentAreaItem, htmlHelper);
                }
                else
                {
                    returnList.Add(rowlist);
                    rowlist = new List<ContentAreaItem>();
                    rowlist.Add(contentAreaItem);
                    columsLeft = 12- GetContentAreaColumnCount(contentAreaItem, htmlHelper);
                }
            }
            returnList.Add(rowlist);
            return returnList;
        }

        private bool CantFitIntoRow(int columsLeft, ContentAreaItem contentAreaItem, HtmlHelper htmlHelper)
        {
            return columsLeft >= GetContentAreaColumnCount(contentAreaItem, htmlHelper);
        }

        private int GetContentAreaColumnCount(ContentAreaItem contentAreaItem, HtmlHelper htmlHelper)
        {
            var tag = GetContentAreaItemTemplateTag(htmlHelper, contentAreaItem);
            ReadRegisteredDisplayModes();

            if (string.IsNullOrWhiteSpace(tag))
            {
                tag = ContentAreaTags.FullWidth;
            }

            var fallback = _fallbacks.FirstOrDefault(f => f.Tag == tag);
            if (fallback == null)
            {
                return 12;
            }
            return fallback.LargeScreenWidth;
        }

        protected override void RenderContentAreaItem(
            HtmlHelper htmlHelper,
            ContentAreaItem contentAreaItem,
            string templateTag,
            string htmlTag,
            string cssClass)
        {
            var originalWriter = htmlHelper.ViewContext.Writer;
            var tempWriter = new StringWriter();

            htmlHelper.ViewContext.Writer = tempWriter;
            var content = contentAreaItem.GetContent(ContentRepository);

            try
            {
                base.RenderContentAreaItem(htmlHelper, contentAreaItem, templateTag, htmlTag, cssClass);

                var contentItemContent = tempWriter.ToString();
                var shouldRender = IsInEditMode(htmlHelper);

                if (!shouldRender)
                {
                    var doc = new HtmlDocument();
                    doc.Load(new StringReader(contentItemContent));
                    var blockContentNode = doc.DocumentNode.ChildNodes.FirstOrDefault();

                    if (blockContentNode != null)
                    {
                        shouldRender = !string.IsNullOrEmpty(blockContentNode.InnerHtml);
                        if (!shouldRender)
                        {
                            // ReSharper disable once SuspiciousTypeConversion.Global
                            var visibilityControlledContent = content as IControlVisibility;
                            shouldRender = (visibilityControlledContent == null) ||
                                           (!visibilityControlledContent.HideIfEmpty);
                        }
                    }
                }

                if (shouldRender)
                {
                    originalWriter.Write(contentItemContent);
                }
                htmlHelper.ViewContext.Writer = originalWriter;
            }
            catch (Exception e)
            {
                htmlHelper.ViewContext.Writer = originalWriter;

                htmlHelper.RenderPartial("ErrorBlock",IsInEditMode(htmlHelper)?e.InnerException.ToString():"");
            }
        }

        private static string GetCssClassesForTag(string tagName)
        {
            ReadRegisteredDisplayModes();

            if (string.IsNullOrWhiteSpace(tagName))
            {
                tagName = ContentAreaTags.FullWidth;
            }

            var fallback = _fallbacks.FirstOrDefault(f => f.Tag == tagName);
            if (fallback == null)
            {
                return string.Empty;
            }

            return string.Format("col-lg-{0} col-md-{1} col-sm-{2} col-xs-{3}",
                                 fallback.LargeScreenWidth,
                                 fallback.MediumScreenWidth,
                                 fallback.SmallScreenWidth,
                                 fallback.ExtraSmallScreenWidth);
        }

        private static string GetTypeSpecificCssClasses(ContentAreaItem contentAreaItem, IContentRepository contentRepository)
        {
            var content = contentAreaItem.GetContent(contentRepository);
            var cssClass = content == null ? String.Empty : content.GetOriginalType().Name.ToLowerInvariant();

            // ReSharper disable once SuspiciousTypeConversion.Global
            var customClassContent = content as ICustomCssInContentArea;
            if (customClassContent != null && !string.IsNullOrWhiteSpace(customClassContent.ContentAreaCssClass))
            {
                cssClass += string.Format(" {0}", customClassContent.ContentAreaCssClass);
            }

            return cssClass;
        }

        private static void ReadRegisteredDisplayModes()
        {
            if (_fallbackCached)
            {
                return;
            }

            var store = typeof(DisplayModeFallback).GetStore();
            _fallbacks = store.LoadAll<DisplayModeFallback>().ToList();
            _fallbackCached = true;
        }
    }
}