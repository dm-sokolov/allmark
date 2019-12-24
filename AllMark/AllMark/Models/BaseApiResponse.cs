using System.Net;

namespace AllMark.Models
{
    public class BaseApiResponse<T>
    {
        public bool IsSuccess { get; set; }

        public HttpStatusCode Status { get; set; }

        public T Content { get; set; }

        public string Message { get; set; }
    }
}
