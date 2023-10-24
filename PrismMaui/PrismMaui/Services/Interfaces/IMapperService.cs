using PrismMaui.Apis.Models;
using System.Text.Json;

namespace PrismMaui.Services.Interfaces
{
    public interface IMapperService
    {
        Response<JsonElement> MapErrorResponse(HttpResponseMessage serverResponse);
        Task<Response<JsonElement>> MapResponseAsync(HttpResponseMessage serverResponse);
    }
}
