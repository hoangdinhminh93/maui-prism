using PrismMaui.Apis.Models;
using PrismMaui.Services.Interfaces;
using System.Text.Json;

namespace PrismMaui.Services
{
    public class MapperService : IMapperService
    {
        public async Task<Response<JsonElement>> MapResponseAsync(HttpResponseMessage serverResponse)
        {
            var response = new Response<JsonElement>();
            var contentString = await serverResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(contentString))
            {
                var doc = JsonDocument.Parse(contentString);
                response.SetObject(doc.RootElement);
            }

            response.StatusCode = serverResponse.StatusCode;
            response.IsSuccess = serverResponse.IsSuccessStatusCode;
            return response;
        }

        public Response<JsonElement> MapErrorResponse(HttpResponseMessage serverResponse)
        {
            return new Response<JsonElement>
            {
                StatusCode = serverResponse.StatusCode,
                IsSuccess = false,
            };
        }
    }
}
