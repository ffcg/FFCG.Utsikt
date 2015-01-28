namespace FFCG.Utsikt.Web.Models.Pages.SearchPage
{
    public enum SearchResultTypeEnum
    {
        All,
        CalendarEvent,
        Document,
        Page
    }
    public class SearchResultType
    {
        public virtual SearchResultTypeEnum Type()
        {
            return SearchResultTypeEnum.Page;
        }

        public virtual string GetIconUrl()
        {
            return @"/Static/img/searchresulttype-page.png";
        }
    }

    public class CalendarEventSearchResultType : SearchResultType
    {
        public override SearchResultTypeEnum Type()
        {
            return SearchResultTypeEnum.CalendarEvent;
        }

        public override string GetIconUrl()
        {
            return @"/Static/img/searchresulttype-calendar.png";
        }
    }

    public class DocumentSearchResultType : SearchResultType
    {
        public override SearchResultTypeEnum Type()
        {
            return SearchResultTypeEnum.Document;
        }

        public override string GetIconUrl()
        {
            return @"/Static/img/searchresulttype-document.png";
        }
    }
}