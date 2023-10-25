using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PrismMaui.Apis;
using PrismMaui.Apis.Interfaces;
using PrismMaui.Helpers;
using PrismMaui.Models;
using PrismMaui.Services.Interfaces;

namespace PrismMaui.Services
{
    public class CatService : ICatService, ILoggableService
    {
        protected readonly IMapperService mapperService;
        private readonly IApiService<ICatApi> apiService;

        public CatService(IMapperService mapperService, IApiService<ICatApi> apiService, ILoggerFactory loggerFactory)
        {
            this.mapperService = mapperService;
            this.apiService = apiService;
            LogHelper.SetLogger(loggerFactory.CreateLogger<ICatService>());
        }

        ICatApi GetApi()
        {
            return apiService.GetApi();
        }

        public async Task<IList<CatBreed>> SearchAllBreeds()
        {
            var api = GetApi();
            var serverResponse = await api.GetCatBreeds();

            var result = await ApiHelper.HandleResponseAsync(apiService, mapperService, serverResponse, LogHelper.GetLogger());
            if (!result.IsSuccess)
            {
                // Todo
            }
            var response = result.ResponseObject;
            return JsonConvert.DeserializeObject<IList<CatBreed>>(response.ToString());
        }

        public async Task<IList<CatImage>> SearchCatImagesById(string id, int limit = 10)
        {
            var api = GetApi();
            var serverResponse = await api.GetCatImages(id);

            var result = await ApiHelper.HandleResponseAsync(apiService, mapperService, serverResponse, LogHelper.GetLogger());
            if (!result.IsSuccess)
            {
                // Todo
            }
            var response = result.ResponseObject;
            return JsonConvert.DeserializeObject<IList<CatImage>>(response.ToString());
        }
    }
}
