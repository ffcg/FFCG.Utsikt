using System;
using System.Text;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Routing;
using FFCG.Utsikt.Web.Models.Pages.StartPage;

namespace FFCG.Utsikt.Web.Util
{
    public interface ISitemapFactory
    {
        string GetSiteMapAsXmlString();
    }

    public class SitemapFactory : ISitemapFactory
    {

        private readonly IContentRepository _contentRepository;
        private readonly UrlResolver _urlResolver;
        private StringBuilder _stringBuilder;

        public SitemapFactory(IContentRepository contentRepository, UrlResolver urlResolver)
        {
            _contentRepository = contentRepository;
            _urlResolver = urlResolver;
        }

        public string GetSiteMapAsXmlString()
        {
            _stringBuilder = new StringBuilder();

            _stringBuilder.Append(xmlencoding);
            _stringBuilder.Append(urlsetstart);
            var startPage = _contentRepository.Get<StartPage>(ContentReference.StartPage);
            GenerateSiteMapXmlForChildren(startPage);
            
            _stringBuilder.Append(urlsetend);
            return _stringBuilder.ToString();
        }

        private const string xmlencoding = "<?xml version='1.0' encoding='utf-8'?>";
        private const string urlsetstart = "<urlset xmlns='http://www.sitemaps.org/schemas/sitemap/0.9'>";
        private const string urlsetend = "</urlset>";

        private const string starttag = "<url>";
        private const string loc = "<loc>{0}</loc>";
        private const string lastmod = "<lastmod>{0}</lastmod>";
        private const string changefreq = "<changefreq>weekly</changefreq>";
        private const string priotag = "<priority>0.5</priority>";
        private const string endtag = "</url>";           

        private void GenerateSiteMapXml(Models.Pages.PageBase page)
        {

            if (page == null)
            {
                return;
            }
            if (page.LinkType == PageShortcutType.External)
            {
                GenerateSiteMapXmlForChildren(page);
                return;
            }
            var url = GetUrl(page);
            var changed = page.Changed;

            _stringBuilder.Append(String.Format("{0}{1}{2}{3}{4}{5}",
                                                                  starttag,
                                                                  string.Format(loc,url),
                                                                  string.Format(lastmod,changed.ToString("yyyy-MM-dd")),
                                                                  changefreq,
                                                                  priotag,
                                                                  endtag
                                                                  ));
            GenerateSiteMapXmlForChildren(page);
        }

        private void GenerateSiteMapXmlForChildren(Models.Pages.PageBase page)
        {

            foreach (Models.Pages.PageBase child in _contentRepository.GetChildren<Models.Pages.PageBase>(page.PageLink))
            {
                if (child.ShowInSiteMap())
                {
                    GenerateSiteMapXml(child);
                }
            }
        }

        private string GetUrl(Models.Pages.PageBase page)
        {
            var url = _urlResolver.GetUrl(page.PageLink);
            return string.Format("{0}{1}", SiteDefinition.Current.SiteUrl.ToString().TrimEnd('/'), url);
        }
    }
}