namespace FFCG.Utsikt.Web.Models.Blocks
{
    public class BlockViewModelBase<TEpiData> : IBlockViewModel<TEpiData> where TEpiData : BlockBase
    {
        public BlockViewModelBase(TEpiData epiData, bool isInEditMode, string layout)
        {
            EpiData = epiData;
            IsInEditMode = isInEditMode;
            Layout = layout;

        }

        public BlockViewModelBase()
        {
            
        }

        public TEpiData EpiData { get; set; }
        public bool IsInEditMode { get; set; }
        public string Layout { get; set; }
    }
}