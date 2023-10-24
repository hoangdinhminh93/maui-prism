using System.Net;

namespace PrismMaui.Apis.Models
{
    public class Response<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public T ResponseObject { get; private set; }
        public void SetObject(T response)
        {
            ResponseObject = response;
        }
    }
}
