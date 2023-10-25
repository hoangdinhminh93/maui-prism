using PrismMaui.Models;

namespace PrismMaui.Services.Interfaces
{
    public interface ICatService
    {
        Task<IList<CatBreed>> SearchAllBreeds();
        Task<IList<CatImage>> SearchCatImagesById(string id, int limit = 10);
    }
}
