using EPiServer.Core;

namespace FFCG.Utsikt.Web.Components
{
    public interface IHasMenuIcon
    {
        ContentReference MenuIcon { get; set; }
    }
}