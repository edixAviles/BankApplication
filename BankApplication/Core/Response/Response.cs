namespace BankApplication.Core.Response
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public T? Result { get; set; }
        public ErrorResponse? Error { get; set; }
    }
}
