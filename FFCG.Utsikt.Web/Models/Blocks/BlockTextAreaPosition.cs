namespace FFCG.Utsikt.Web.Models.Blocks
{
    public enum BlockTextAreaPosition
    {
        Left,
        Right
    }
    public static class BlockTextAreaPositionExtensions
    {
        public static string GetCssClass(this BlockTextAreaPosition position)
        {
            switch (position)
            {
                case BlockTextAreaPosition.Left:
                    return "blocktextarea-leftposition";
                case BlockTextAreaPosition.Right:
                    return "blocktextarea-rightposition";
            }
            return string.Empty;
        }
    }
}