namespace FonTakip.API.Models
{
    public class ErrorResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}