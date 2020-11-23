using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnMiddlewareComponent
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;
        public CustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string method = context.Request.Method;
            if (method == "GET")
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("This is GET request!");
            }
            else
                await next.Invoke(context);
        }
    }
}
