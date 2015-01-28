namespace FFCG.Utsikt.Web.Helpers
{
    public static class ObjectExtenstions
    {
        public static string ToNonNullString(this object o)
        {
            return o != null ? o.ToString() : string.Empty;
        }
    }
}