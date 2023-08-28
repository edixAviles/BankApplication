using BankApplication.Core.Response;

namespace BankApplication.Src.Shared
{
    public static class ServiceError
    {
        public static ErrorResponse GetException(Exception error)
        {
            return new ErrorResponse
            {
                Code = error.HelpLink ?? string.Empty,
                Message = error.Message
            };
        }
    }
}
