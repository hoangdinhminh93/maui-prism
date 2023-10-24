namespace PrismMaui.Models
{
    public class CatImage : BaseModel
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
    }
}
