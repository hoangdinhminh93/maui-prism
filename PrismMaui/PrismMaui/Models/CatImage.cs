namespace PrismMaui.Models
{
    public partial class CatImage : BaseModel
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
    }

    public partial class CatImage
    {
        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set => SetProperty(ref isSelected, value);
        }
    }
}
