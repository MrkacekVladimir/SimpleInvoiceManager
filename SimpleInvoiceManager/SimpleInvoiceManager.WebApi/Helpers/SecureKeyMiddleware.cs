using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SimpleInvoiceManager.WebApi.Helpers
{    
    public class SecureKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secureKey;

        public SecureKeyMiddleware(RequestDelegate next,string secureKey)
        {
            _next = next;
            _secureKey = secureKey;
        }

        public Task Invoke(HttpContext httpContext)
        {            
            IHeaderDictionary headers = httpContext.Request.Headers;
            bool contains = headers.ContainsKey("secureKey");
            if (!contains || headers["secureKey"] != _secureKey)
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
        public static IApplicationBuilder UseSecureKeyMiddleware(this IApplicationBuilder builder, string secureKey)
        {
            return builder.UseMiddleware<SecureKeyMiddleware>(secureKey);
        }
    }
}
