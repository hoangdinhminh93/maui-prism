using Microsoft.Extensions.Logging;

namespace PrismMaui.Apis.Interfaces
{
    public interface IApiService<T>
    {
        T GetApi();
        Task<bool> HandleHttpResponse(HttpResponseMessage response, ILogger logger);
    }
}
