using EPiServer.Core;

namespace FFCG.Utsikt.Web.Util.Search
{
    public interface IHaveSearchRedirect
    {
        ContentReference GetSeachRedirect();
    }
}