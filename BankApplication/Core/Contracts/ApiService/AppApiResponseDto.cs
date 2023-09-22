using Newtonsoft.Json;

namespace BankApplication.Core.Contracts.ApiService
{
    public class AppApiResponseDto
    {
        public string Status { get; set; } = string.Empty;
        public string? Content { get; set; }
        public string ContentError { get; set; } = string.Empty;
        public HttpResponseMessage ContentHtmlResponse { get; set; } = new HttpResponseMessage();

        public T? GetContentObject<T>() where T : class
        {
            return string.IsNullOrEmpty(Content) ? null : JsonConvert.DeserializeObject<T>(Content);
        }
    }
}
