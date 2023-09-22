namespace BankApplication.Core.Contracts.ApiService
{
    public class RequestDataDto
    {
        public string UrlBase { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public Dictionary<string, string>? Parameters { get; set; }
        public CredentialsDto? Credentials { get; set; }
        public Dictionary<string, string>? Headers { get; set; }
        public string FailureLogDescription { get; set; } = string.Empty;

        public Dictionary<string, string>? FormData { get; set; }
        public Dictionary<string, string>? InLineParameters { get; set; }
        public string SourceMethod { get; set; } = string.Empty;
    }
}
