using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace FFCG.Utsikt.Web.Models.Blocks.Preview
{
    [TemplateDescriptor(
      Inherited = true,
      TemplateTypeCategory = TemplateTypeCategories.MvcController,
      Tags = new[] { RenderingTags.Preview, RenderingTags.Edit },
      AvailableWithoutTag = false)]
    [VisitorGroupImpersonation]
    public class PreviewController : ActionControllerBase, IRenderTemplate<BlockBase>
    {

        public ActionResult Index(IContent currentContent)
        {

            // set flag
            ViewBag.IsInEditMode = true;

            var area = new ContentArea();
            area.Items.Add(new ContentAreaItem
            {
                ContentLink = currentContent.ContentLink
            });
            var model = new PreviewViewModel { PreviewContent = currentContent, Area = area };
            return View("~/Models/Blocks/Preview/Preview.cshtml", model);
        }
    }
}