using Newtonsoft.Json;

namespace PrismMaui.Models
{
    public class CatBreed : BaseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
