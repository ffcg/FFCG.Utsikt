using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

namespace FFCG.Utsikt.Web.Models.Blocks.FormBlock
{
    public class FormBlockController : BlockControllerBase<FormBlockViewModel,FormBlock>
    {
        protected override FormBlockViewModel CreateModel(FormBlock currentContent)
        {

            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }
            var pageRouteHelper = ServiceLocator.Current.GetInstance<PageRouteHelper>();
            PageData currentPage = pageRouteHelper.Page;
            var model= base.CreateModel(currentContent);
            if (currentContent.Form != null && currentPage != null)
            {
                var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
                var pageUrl = urlResolver.GetUrl(currentPage.ContentLink);

                var actionUrl = string.Format("{0}XFormPost/", pageUrl);
                actionUrl = UriSupport.AddQueryString(actionUrl, "XFormId", currentContent.Form.Id.ToString());
                actionUrl = UriSupport.AddQueryString(actionUrl, "failedAction", "Failed");
                actionUrl = UriSupport.AddQueryString(actionUrl, "successAction", "Success");

                model.ActionUrl = actionUrl;
            }
            return model;
        }
    }
}