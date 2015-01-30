using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace FFCG.Utsikt.Web
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            
            RegisterMyRoutes();
            AreaRegistration.RegisterAllAreas();

            
            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }

        private void RegisterMyRoutes()
        {
            RouteTable.Routes.MapRoute(
      "newsfeed",
      "newsfeed",
      new
      {
          controller = "NewsFeed",
          action = "Index"
      },
      new[] { "FFCG.Utsikt.Web.Controllers" });

               RouteTable.Routes.MapRoute(
              "pageasjson",
              "pageasjson/{url}",
              new
              {
                  controller = "PageAsJson",
                  action = "Index",
                  url=""
              },
              new[] { "FFCG.Utsikt.Web.Controllers" });

        }


    }
}