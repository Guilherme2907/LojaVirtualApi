using Guilherme.LojaVirtualApi.Models.Exceptions;
using Guilherme.LojaVirtualApi.Models.Responses.Enums;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Services.ExceptionHandlingStrategies
{
    public class NotFoundExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        private readonly ILogger _logger;

        public NotFoundExceptionHandlingStrategy(ILogger logger)
        {
            _logger = logger;
        }

        public override async Task<HttpContext> HandleAsync(HttpContext context, Exception exception)
        {
            var notFoundException = exception as NotFoundException;
            //_logger.Error(notFoundException, "[{@user}] Error: {@exception}", context.Request.Headers[Constants.BLIP_USER_HEADER], apiException.Message);
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            return await Task.FromResult(context);
        }

        public override Task<ErrorResult> GetErrorResultAsync()
        {
            return Task.FromResult(ErrorResult.NotFound);
        }
    }
}
