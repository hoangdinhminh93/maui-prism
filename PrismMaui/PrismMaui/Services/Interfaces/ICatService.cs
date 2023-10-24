using PrismMaui.Models;

namespace PrismMaui.Services.Interfaces
{
    public interface ICatService
    {
        Task<IList<CatBreed>> SearchAllBreeds();
        Task<CatImage> SearchCatImageById(string id);
    }
}
