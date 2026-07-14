using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using FonTakip.API.Models;

namespace FonTakip.API.Middlewares
{
    public class ExceptionMiddleware
    {
        // Bir sonraki adıma (Garsona) geçiş yetkisi
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Restorana (API'ye) gelen HER istek önce buradan geçer
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                // İstek sorunsuzsa, müşteriyi içeri (Garsona) gönder
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // İçeride bir yerde hata patlarsa (tabak kırılırsa), catch bloğu devreye girer
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        // Hata durumunda müşteriye dönülecek standart cevap
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Cevabın tipini JSON yap
            context.Response.ContentType = "application/json";
            
            // 500 - Internal Server Error (Sunucu Hatası) kodu dön
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 

            // Müşteriye gönderilecek kibar şablonu doldur
            var errorResult = new ErrorResult
            {
                StatusCode = context.Response.StatusCode,
                Message = "Sistemde beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyin."
                
                // Not: Gerçek hayatta 'exception.Message' verisini bir dosyaya/log'a kaydederiz, 
                // ancak güvenliği tehlikeye atmamak için müşteriye yollamayız!
            };

            // Şablonu JSON metnine çevirip fırlat
            var json = JsonSerializer.Serialize(errorResult);
            return context.Response.WriteAsync(json);
        }
    }
}