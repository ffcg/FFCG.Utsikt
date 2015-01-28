using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Editor;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.XForms;
using EPiServer.XForms.Util;

namespace FFCG.Utsikt.Web.Models.Pages
{
    public class PageControllerBase<TViewModel, TEpiData> : PageController<TEpiData>
        where TViewModel : PageViewModelBase<TEpiData>, new()
        where TEpiData : PageBase
    {
         private readonly XFormPageUnknownActionHandler _xformHandler;


        public PageControllerBase()
        {
            _xformHandler = new XFormPageUnknownActionHandler();
        }
        public virtual ActionResult Index(TEpiData currentPage)
        {
            var model = CreateModel(currentPage);
            return View(GetViewName(currentPage), model);
        }

        protected virtual string GetViewName(TEpiData currentPage)
        {
            return string.Format("~/Models/Pages/{0}/{0}.cshtml", currentPage.GetOriginalType().Name);
        }

        protected virtual string GetViewName(string pageName, string childActionName)
        {
            return string.Format("~/Models/Pages/{0}/{1}.cshtml",pageName, childActionName);
        }

        protected virtual TViewModel CreateModel(TEpiData currentPage)
        {
            var model = new TViewModel {EpiData = currentPage};
            model.MetaTitle = currentPage.MetaTitle ?? currentPage.PageName;
            model.MetaDescription = currentPage.MetaDescription ?? currentPage.PageName;
            model.IsInEditMode = PageEditing.PageIsInEditMode;
            return model;
        }
        
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }
 
            base.OnActionExecuting(filterContext);
        }
 
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            TempData["ViewData"] = ViewData;
 
            base.OnResultExecuting(filterContext);
        }
 
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Success(PageData currentPage, XFormPostedData xFormPostedData)
        {
            return RedirectToAction("Index");
        }
 
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Failed(PageData currentPage, XFormPostedData xFormPostedData)
        {
            return RedirectToAction("Index");
        }
 
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost, ValidateInput(false)]
        public virtual ActionResult XFormPost(XFormPostedData xFormpostedData)
        {

            // Add posted xform instance id to viewdata, so we can retrieve it later
            this.ViewData["XFormID"] = xFormpostedData.XForm.Id;

            return _xformHandler.HandleAction(this);
        }
    }
}