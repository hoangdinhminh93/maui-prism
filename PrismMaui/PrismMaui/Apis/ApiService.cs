using Microsoft.Extensions.Logging;
using PrismMaui.Apis.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMaui.Apis
{
    public class ApiService<T> : IApiService<T>
    {
        private T service;

        public T GetApi()
        {
            if (service == null)
            {
                var baseUrl = ApiSetup.BaseURL;
                var httpClientHandler = new HttpClient()
                {
                    BaseAddress = new Uri(baseUrl)
                };
                var refitSettings = new RefitSettings();
                return service = RestService.For<T>(httpClientHandler, refitSettings);
            }

            return service;
        }

        public async Task<bool> HandleHttpResponse(HttpResponseMessage response, ILogger logger)
        {
            if (response == null)
            {
                return false;
            }

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                // In case of failed request
                await LogFailedRequest(response, logger);
            }
            catch (Exception ex)
            {
                await LogErrorWithResponse(response, logger, ex);
            }

            return false;
        }

        private static async Task LogFailedRequest(HttpResponseMessage response, ILogger logger)
        {
            if (logger == null || response.RequestMessage == null)
            {
                return;
            }

            // Todo
        }

        private static async Task LogErrorWithResponse(HttpResponseMessage response, ILogger logger, Exception ex)
        {
            if (logger == null || response.RequestMessage == null)
            {
                return;
            }

            // Todo
        }
    }
}
