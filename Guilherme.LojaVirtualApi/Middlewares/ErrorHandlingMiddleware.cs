using Guilherme.LojaVirtualApi.Models.Responses;
using Guilherme.LojaVirtualApi.Models.Responses.Enums;
using Guilherme.LojaVirtualApi.Services.ExceptionHandlingStrategies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly Dictionary<Type, ExceptionHandlingStrategy> _exceptionHandling;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ErrorHandlingMiddleware(RequestDelegate next,
                                       ILogger logger,
                                       Dictionary<Type, ExceptionHandlingStrategy> exceptionHandling)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _next = next;
            _logger = logger;
            _exceptionHandling = exceptionHandling;
        }

        /// <summary>
        /// Invoke Method, to validate requisition errors
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var requestBody = string.Empty;
            context.Request.EnableBuffering();

            using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
                requestBody = await reader.ReadToEndAsync();
                context.Request.Body.Position = default;
            }
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(requestBody, context, ex);
            }
        }

        private async Task HandleExceptionAsync(string requestBody, HttpContext context, Exception exception)
        {
            var errorResult = ErrorResult.InternalServerError;

            if (_exceptionHandling.TryGetValue(exception.GetType(), out var handler))
            {
                context = await handler.HandleAsync(context, exception);
                errorResult = await handler.GetErrorResultAsync();
            }
            else
            {
                //_logger.Error(exception, "[{@user}] Error: {@exception}", context.Request.Headers[Constants.BLIP_USER_HEADER], exception.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

           // _logger.Error(exception, "[traceId:{@traceId}]{@user} Error. Headers: {@headers}. Query: {@query}. Path: {@path}. Body: {@requestBody}",
                         // context.TraceIdentifier, context.Request.Headers[Constants.BLIP_USER_HEADER],
                          //context.Request.Headers, context.Request.Query, context.Request.Path, requestBody);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorResponse(exception,errorResult)));
        }
    }
}
