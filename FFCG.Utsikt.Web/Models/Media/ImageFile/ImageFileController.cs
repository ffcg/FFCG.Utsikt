﻿using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;

namespace FFCG.Utsikt.Web.Models.Media.ImageFile
{
    public class ImageFileController : PartialContentController<ImageFile>
    {
        private readonly UrlResolver _urlResolver;

        public ImageFileController(UrlResolver urlResolver)
        {
            _urlResolver = urlResolver;
        }

        /// <summary>
        /// The index action for the image file. Creates the view model and renders the view.
        /// </summary>
        /// <param name="currentContent">The current image file.</param>
        public override ActionResult Index(ImageFile currentContent)
        {
            var model = new ImageViewModel
            {
                Url = _urlResolver.GetUrl(currentContent.ContentLink),
                Name = currentContent.Name,
                Copyright = currentContent.Copyright??""
            };

            return PartialView("~/Models/Media/ImageFile/ImageFile.cshtml",model);
        }
    }
}