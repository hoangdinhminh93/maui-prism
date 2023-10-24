using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMaui.Apis.Interfaces
{
    public interface ICatApi
    {
        [Get("/breeds")]
        Task<HttpResponseMessage> GetCatBreeds();

        [Get("/images/search?breed_ids={id}")]
        Task<HttpResponseMessage> GetCatImage(string id);
    }
}
