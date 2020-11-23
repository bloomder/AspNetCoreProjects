using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Middleware1
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate next;
        public TokenMiddleware(RequestDelegate _next)
        {
            next = _next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string txt = context.Request.Path;
            txt = GetToken(txt);
            if(txt=="4444")
            {
                await context.Response.WriteAsync("True token!");                
                
            }
            else
            {
                await context.Response.WriteAsync("False token!");
            }
            await next.Invoke(context);
        }
        private string GetToken(string text)
        {
            string result = "";
            bool block = false;
            for (int i = 0; i < text.Length; i++)
            {
                if(!block)
                {
                    if (text[i] == '=') block = true;
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }
    }
}
