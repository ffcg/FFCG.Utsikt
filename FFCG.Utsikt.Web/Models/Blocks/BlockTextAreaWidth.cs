namespace FFCG.Utsikt.Web.Models.Blocks
{
    public enum BlockTextAreaWidth
    {
        Full,
        Half
    }

    public static class BlockTextAreaWidthExtensions
    {
        public static string GetCssClass(this BlockTextAreaWidth width)
        {
            switch (width)
            {
                case BlockTextAreaWidth.Full:
                    return "col-md-12 col-xs-12 col-lg-12 col-sm-12";
                case BlockTextAreaWidth.Half:
                    return "col-md-6 col-xs-12 col-lg-6 col-sm-12";
            }
            return "col-md-12 col-xs-12 col-lg-12 col-sm-12";
        }
    }
}