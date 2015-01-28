using System;
using System.Linq;

namespace FFCG.Utsikt.Web.Models.Blocks.YouTubeBlock
{
    public class YouTubeBlockController : BlockControllerBase<YouTubeBlockViewModel, YouTubeBlock>
    {
        protected override YouTubeBlockViewModel CreateModel(YouTubeBlock currentContent)
        {
            var model = base.CreateModel(currentContent);
            if (currentContent.VideoUrl.Split(new string[] {"watch?v="},StringSplitOptions.None).Count() > 1)
            {
                model.VideoUrl = string.Format("//www.youtube-nocookie.com/embed/{0}", currentContent.VideoUrl.Split(new string[] { "watch?v=" }, StringSplitOptions.None)[1]);
            }
            return model;
        }
    }
}