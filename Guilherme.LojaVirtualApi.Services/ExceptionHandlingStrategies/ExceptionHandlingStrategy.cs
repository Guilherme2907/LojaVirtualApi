using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Guilherme.LojaVirtualApi.Models.DTOs.Responses.Enums;

namespace Guilherme.LojaVirtualApi.Services.ExceptionHandlingStrategies
{
    public abstract class ExceptionHandlingStrategy
    {
        public abstract Task<HttpContext> HandleAsync(HttpContext context, Exception exception);
        public abstract Task<ErrorResult> GetErrorResultAsync();
    }
}
