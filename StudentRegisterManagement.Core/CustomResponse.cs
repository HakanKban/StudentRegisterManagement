using StudentRegisterManagement.Core.Dtos;
using System.Text.Json.Serialization;

namespace StudentRegisterManagement.Core
{
    public record CustomResponse<T>
    {
        [JsonPropertyName("data")] public T Data { get; set; }

        [JsonIgnore] public int StatusCode { get; set; }

        [JsonIgnore] public bool Succeeded { get; private set; }

        [JsonIgnore] public object[] Args { get; private set; }

        [JsonPropertyName("error")] public ErrorDTO Error { get; set; }
        public static CustomResponse<T> Success(int statusCode, T data)
        {
            return new CustomResponse<T> { Data = data, StatusCode = statusCode, Succeeded = true };
        }

        public static CustomResponse<T> Success(int statusCode)
        {
            return new CustomResponse<T> { StatusCode = statusCode, Succeeded = true };
        }
        public static CustomResponse<T> Fail(int statusCode, string error)
        {
            return new CustomResponse<T>
            {
                StatusCode = statusCode,
                Error = new ErrorDTO { Details = new List<string> { error } },
                Succeeded = false
            };
        }
        public static CustomResponse<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponse<T>
            {
                StatusCode = statusCode,
                Error = new ErrorDTO { Details = errors },
                Succeeded = false
            };
        }
        public static CustomResponse<T> Fail(int statusCode, List<string> errors, params object[] args)
        {
            return new CustomResponse<T>
            {
                StatusCode = statusCode,
                Error = new ErrorDTO { Details = errors },
                Succeeded = false,
                Args = args
            };
        }
    }
}
