using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Serilog;
using Guilherme.LojaVirtualApi.Models.Responses.Enums;

namespace Guilherme.LojaVirtualApi.Services.ExceptionHandlingStrategies
{
    public abstract class ExceptionHandlingStrategy
    {
        public abstract Task<HttpContext> HandleAsync(HttpContext context, Exception exception);
        public abstract Task<ErrorResult> GetErrorResultAsync();
    }
}
