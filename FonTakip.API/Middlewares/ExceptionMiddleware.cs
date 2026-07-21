using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using FonTakip.API.Models;

namespace FonTakip.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 

            var errorResult = new ErrorResult
            {
                StatusCode = context.Response.StatusCode,
                Message = "Sistemde beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyin."
            };

            var json = JsonSerializer.Serialize(errorResult);
            return context.Response.WriteAsync(json);
        }
    }
}