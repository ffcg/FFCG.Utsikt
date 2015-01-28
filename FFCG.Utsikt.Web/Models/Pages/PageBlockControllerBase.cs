using System.Web.Mvc;
using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;

namespace FFCG.Utsikt.Web.Models.Pages
{
    [TemplateDescriptor(TemplateTypeCategory = TemplateTypeCategories.MvcPartialController, Inherited = true)]
    public class PageBlockControllerBase<TViewModel, TEpiData> : PageController<TEpiData>
        where TViewModel : PageViewModelBase<TEpiData>, new()
        where TEpiData : PageBase
    {
        public virtual ActionResult Index(TEpiData currentPage)
        {
            var model = CreateModel(currentPage);
            return PartialView(GetViewName(currentPage), model);
        }

        protected virtual string GetViewName(TEpiData currentPage)
        {
            return string.Format("~/Models/Pages/{0}/{0}Block.cshtml", currentPage.GetOriginalType().Name);
        }

        protected virtual string GetViewName(string pageName, string childActionName)
        {
            return string.Format("~/Models/Pages/{0}/{1}Block.cshtml", pageName, childActionName);
        }

        protected virtual TViewModel CreateModel(TEpiData currentPage)
        {
            var model = new TViewModel {EpiData = currentPage};
            return model;
        }
    }
}