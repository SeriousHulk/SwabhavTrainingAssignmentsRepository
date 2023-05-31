using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MiddlewareMVCApp.Services;
using System.Threading.Tasks;

namespace MiddlewareMVCApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private IEmailServices _emailServices;
        public Middleware(RequestDelegate next)
        {
            _next = next;
            //_emailServices = emailServices;
        }

        public async Task Invoke(HttpContext httpContext, IEmailServices emailServices)
        {
            _emailServices = emailServices;
            await _emailServices.SendEmail("Invoke method foo", "admin", "invoke completed");
            Console.WriteLine("(RED)Before mw");
            await _next(httpContext);
            Console.WriteLine("(BLUE)After mw");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
