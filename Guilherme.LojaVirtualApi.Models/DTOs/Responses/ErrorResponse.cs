using Guilherme.LojaVirtualApi.Models.DTOs.Responses.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Guilherme.LojaVirtualApi.Models.DTOs.Responses
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ErrorResult Error { get; set; }
        [JsonIgnore]
        public Exception Exception { get; set; }

        public ErrorResponse(Exception exception,ErrorResult error)
        {
            Message = exception.Message;
            Error = error;
            Exception = exception;
        }
    }
}
