using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.Web;
using EPiServer.Search;
using EPiServer.Search.Queries;
using EPiServer.Search.Queries.Lucene;
using EPiServer.Security;
using EPiServer.Web;
using EPiServer.Web.Routing;
using FFCG.Utsikt.Web.Models.Media.GenericMedia;
using FFCG.Utsikt.Web.Models.Pages.SearchPage;
using Microsoft.Ajax.Utilities;

namespace FFCG.Utsikt.Web.Util.Search.EpiserverSearch
{
    public class EpiserverSearchService : ISearchService
    {
        private readonly IHttpContextWrapper _context;
        private readonly SearchHandler _searchHandler;
        private readonly IContentLoader _contentLoader;
        private readonly ContentSearchHandler _contentSearchHandler;
        private readonly UrlResolver _urlResolver;
        private readonly TemplateResolver _templateResolver;

        public int TextLength { get; set; }

        public EpiserverSearchService(IHttpContextWrapper context, SearchHandler searchHandler, IContentLoader contentLoader, 
            ContentSearchHandler contentSearchHandler, UrlResolver urlResolver, TemplateResolver templateResolver)
        {
            _context = context;
            _searchHandler = searchHandler;
            _contentLoader = contentLoader;
            _contentSearchHandler = contentSearchHandler;
            _urlResolver = urlResolver;
            _templateResolver = templateResolver;
            TextLength = 300;
        }

        public ISearchResult Search(string query, CultureInfo culture, int maxResults)
        {
            var searchRoots = new[]
            {ContentReference.StartPage, ContentReference.GlobalBlockFolder, ContentReference.SiteBlockFolder};
            var searchQuery = CreateQuery(query, searchRoots, _context.Context, culture.TwoLetterISOLanguageName);
            return MapToSearchResult(_searchHandler.GetSearchResults(searchQuery, 1, maxResults),query);
        }

        private ISearchResult MapToSearchResult(SearchResults searchResults, string query)
        {
            var result = new SearchResult{NumberOfHits = searchResults.TotalHits,SearchedQuery = query};
            result.SearchHits = searchResults.IndexResponseItems.SelectMany(x=>MapToSearchHit(x, query)).DistinctBy(x => x.Url).ToList(); 
            return result;
        }

        private IQueryExpression CreateQuery(string searchText, IEnumerable<ContentReference> searchRoots, HttpContext context, string languageBranch)
        {
            //Main query which groups other queries. Each query added
            //must match in order for a page or file to be returned.
            var query = new GroupQuery(LuceneOperator.AND);

            //Add free text query to the main query
            query.QueryExpressions.Add(new FieldQuery(searchText));

            //Search for pages using the provided language
            var pageTypeQuery = new GroupQuery(LuceneOperator.AND);
            pageTypeQuery.QueryExpressions.Add(new ContentQuery<PageData>());
            pageTypeQuery.QueryExpressions.Add(new FieldQuery(languageBranch, Field.Culture));

            //Search for media without languages
            var contentTypeQuery = new GroupQuery(LuceneOperator.OR);
            contentTypeQuery.QueryExpressions.Add(new ContentQuery<MediaData>());
            contentTypeQuery.QueryExpressions.Add(pageTypeQuery);

            query.QueryExpressions.Add(contentTypeQuery);

            //Create and add query which groups type conditions using OR
            var typeQueries = new GroupQuery(LuceneOperator.OR);
            query.QueryExpressions.Add(typeQueries);

            foreach (var root in searchRoots)
            {
                var contentRootQuery = new VirtualPathQuery();
                contentRootQuery.AddContentNodes(root, _contentLoader);
                typeQueries.QueryExpressions.Add(contentRootQuery);
            }

            var accessRightsQuery = new AccessControlListQuery();
            accessRightsQuery.AddAclForUser(PrincipalInfo.Current, context);
            query.QueryExpressions.Add(accessRightsQuery);

            return query;
        }

        private IEnumerable<SearchHit> MapToSearchHit(IndexResponseItem responseItem, string query)
        {
            var content = _contentSearchHandler.GetContent<IContent>(responseItem);
            if (content is IHaveSearchRedirect)
            {
                var haveSearchRedirect = content as IHaveSearchRedirect;
                content = _contentLoader.Get<IContent>(haveSearchRedirect.GetSeachRedirect());
            }

            if (content != null && HasTemplate(content) && IsPublished(content as IVersionable) && !(content is IExcludeFromSearch))
            {
                yield return CreatePageHit(content, query);
            }
        }

        private bool HasTemplate(IContent content)
        {
            return _templateResolver.HasTemplate(content, TemplateTypeCategories.Page);
        }

        private bool IsPublished(IVersionable content)
        {
            if (content == null)
                return true;
            return content.Status.HasFlag(VersionStatus.Published);
        }

        private SearchHit CreatePageHit(IContent content,string query)
        {
            return new SearchHit
            {
                Category = GetSearchResultTypeForContent(content),
                Title = content.Name,
                Url = _urlResolver.GetUrl(content.ContentLink),
                HighlightQueryText = content is ISearchTextMatcher ? MarkQuery(((ISearchTextMatcher)content).MatchText(query, TextLength), query) : string.Empty
            };
        }


        private SearchResultType GetSearchResultTypeForContent(IContent content)
        {
            
            if (content is IAmMedia)
            {
                return new DocumentSearchResultType();
            }
            return new SearchResultType();
        }

        private string MarkQuery(string matchText, string query)
        {
            return matchText.Replace(query, "<mark>" + query + "</mark>");
        }
    }
}