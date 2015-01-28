namespace FFCG.Utsikt.Web.Models.Blocks.TextAreaBlock
{
    public enum TextAreaBlockColor
    {
        Yellow,
        Yellow90,
        Yellow80,
        Limeyellow,
        Limeyellow80,
        Limeyellow60,
        Red,
        Red90,
        Red80,
        Green,
        Green90,
        Green80,
        Blue,
        Blue90,
        Blue80,
        Darkblue,
        Darkblue90,
        Darkblue80,
        Darkgray,
        Darkgray90,
        Darkgray80,
        Gray,
        White,
        Etikler,
        Etikler90,
        Etikler80
    }

    public static class TextAreaBlockColorExtensions
    {
        public static string GetCssClass(this TextAreaBlockColor color)
        {
            switch (color)
            {
                case TextAreaBlockColor.Yellow:
                    return "textareablock-background-color-yellow";
                case TextAreaBlockColor.Yellow90:
                    return "textareablock-background-color-yellow90";
                case TextAreaBlockColor.Yellow80:
                    return "textareablock-background-color-yellow80";
                case TextAreaBlockColor.Limeyellow:
                    return "textareablock-background-color-limeyellow";
                case TextAreaBlockColor.Limeyellow80:
                    return "textareablock-background-color-limeyellow80";
                case TextAreaBlockColor.Limeyellow60:
                    return "textareablock-background-color-limeyellow60";
                case TextAreaBlockColor.Red:
                    return "textareablock-background-color-red";
                case TextAreaBlockColor.Red90:
                    return "textareablock-background-color-red90";
                case TextAreaBlockColor.Red80:
                    return "textareablock-background-color-red80";
                case TextAreaBlockColor.Green:
                    return "textareablock-background-color-green";
                case TextAreaBlockColor.Green90:
                    return "textareablock-background-color-green90";
                case TextAreaBlockColor.Green80:
                    return "textareablock-background-color-green80";
                case TextAreaBlockColor.Blue:
                    return "textareablock-background-color-blue";
                case TextAreaBlockColor.Blue90:
                    return "textareablock-background-color-blue90";
                case TextAreaBlockColor.Blue80:
                    return "textareablock-background-color-blue80";
                case TextAreaBlockColor.Darkblue:
                    return "textareablock-background-color-darkblue";
                case TextAreaBlockColor.Darkblue90:
                    return "textareablock-background-color-darkblue90";
                case TextAreaBlockColor.Darkblue80:
                    return "textareablock-background-color-darkblue80";
                case TextAreaBlockColor.Darkgray:
                    return "textareablock-background-color-darkgray";
                case TextAreaBlockColor.Darkgray90:
                    return "textareablock-background-color-darkgray90";
                case TextAreaBlockColor.Darkgray80:
                    return "textareablock-background-color-darkgray80";
                case TextAreaBlockColor.Gray:
                    return "textareablock-background-color-gray";
                case TextAreaBlockColor.White:
                    return "textareablock-background-color-white";
                case TextAreaBlockColor.Etikler:
                    return "textareablock-background-color-etikler";
                case TextAreaBlockColor.Etikler90:
                    return "textareablock-background-color-etikler90";
                case TextAreaBlockColor.Etikler80:
                    return "textareablock-background-color-etikler80";
            }
            return string.Empty;
        }
    }



}