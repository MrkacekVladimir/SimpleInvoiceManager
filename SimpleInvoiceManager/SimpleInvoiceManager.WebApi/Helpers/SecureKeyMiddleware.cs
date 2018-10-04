using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SimpleInvoiceManager.WebApi.Helpers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SecureKeyMiddleware
    {
        private readonly RequestDelegate _next;

        public SecureKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string secureKey = "PragueLabsSecretAPIKey";
            IHeaderDictionary headers = httpContext.Request.Headers;
            bool contains = headers.ContainsKey("secureKey");
            if (!contains)
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.WriteAsync("Invalid secure key", Encoding.UTF8);

                return Task.CompletedTask;
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SecureKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecureKeyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecureKeyMiddleware>();
        }
    }
}
