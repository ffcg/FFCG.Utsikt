using EPiServer.Web.Mvc.Html;
using FFCG.Utsikt.Web.Business;
using FFCG.Utsikt.Web.Business.Renderer;
using FFCG.Utsikt.Web.Util;
using FFCG.Utsikt.Web.Util.Search;
using FFCG.Utsikt.Web.Util.Search.EpiserverSearch;
using StructureMap;

namespace FFCG.Utsikt.Web.Infrastructure
{
    public class StructureMapConfiguration
    {
        public static void Configure(IContainer container)
        {
            container.Configure(
              x =>
              {
                  x.For<IGlobalSettings>().Use<GlobalSettings>();
                  x.For<ContentAreaRenderer>().Use<BootstrapAwareContentAreaRenderer>();
                  x.For<IHttpContextWrapper>().Use<HttpContextWrapper>();
                  x.For<ISearchService>().Use<EpiserverSearchService>();
                  x.For<ICalendarCreator>().Use<CalendarCreator>();
                  x.For<ISitemapFactory>().Use<SitemapFactory>();
              });
        }
    }
}