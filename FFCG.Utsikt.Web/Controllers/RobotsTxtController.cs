using System.Web.Mvc;
using FFCG.Utsikt.Web.Business;

namespace FFCG.Utsikt.Web.Controllers
{
    public class RobotsTxtController : Controller
    {
        private readonly IGlobalSettings _globalSettings;


        public RobotsTxtController(IGlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;

        }

        [HttpGet]
        public ActionResult Index()
        {
            return Content(GetRobotsContent(), "text/plain");
        }

        private string GetRobotsContent()
        {
            return _globalSettings.RobotsTxtContent;
        }
    }
}