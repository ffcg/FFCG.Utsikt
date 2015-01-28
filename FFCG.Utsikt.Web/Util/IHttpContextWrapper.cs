using System.Web;

namespace FFCG.Utsikt.Web.Util
{
    public interface IHttpContextWrapper
    {
        HttpContext Context { get; }
    }

    public class HttpContextWrapper : IHttpContextWrapper
    {
        public HttpContext Context { get { return HttpContext.Current; } }
    }
}