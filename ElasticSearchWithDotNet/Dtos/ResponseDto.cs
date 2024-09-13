using System.Net;

namespace ElasticSearchWithDotNet.Dtos
{
    public record  ResponseDto<T>
    {
        public T? Data { get; set; }

        public List<string>? Errors { get; set; } 

        public HttpStatusCode Status { get; set; }

        public static ResponseDto<T> Succes( T data, HttpStatusCode status)
        {
            return new ResponseDto<T> { Data = data, Status = status};
        }
        public static ResponseDto<T> Fail(List<string> Errors, HttpStatusCode status)
        {
            return new ResponseDto<T> { Errors = Errors, Status = status };
        }
    }
}
