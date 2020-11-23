using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware1
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate next;
        public LoggingMiddleware(RequestDelegate _next)
        {
            next = _next;
        }
        public async Task InvokeAsync(HttpContext context, ILogger<LoggingMiddleware> logger)
        {
            logger.LogInformation($"Context.Request.Method: {context.Request.Method}");
            logger.LogInformation($"Context.Request.Path: {context.Request.Path}");
            await next.Invoke(context);
        }

    }
}
