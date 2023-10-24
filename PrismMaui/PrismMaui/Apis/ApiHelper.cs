using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using PrismMaui.Apis.Interfaces;
using PrismMaui.Apis.Models;
using PrismMaui.Services.Interfaces;

namespace PrismMaui.Apis
{
    public static class ApiHelper
    {
        public static async Task<Response<JsonElement>> HandleResponseAsync<T>(IApiService<T> apiService, IMapperService mapperService, HttpResponseMessage serverResponse, ILogger logger = null)
        {
            if (serverResponse is not HttpResponseMessage httpResponseMessage)
            {
                return mapperService.MapErrorResponse(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.ExpectationFailed
                });
            }

            var handleResult = await apiService.HandleHttpResponse(httpResponseMessage, logger);
            if (handleResult)
            {
                return await mapperService.MapResponseAsync(serverResponse);
            }
            return mapperService.MapErrorResponse(serverResponse);
        }
    }
}
