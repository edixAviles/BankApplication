using BankApplication.Core.Response;

namespace BankApplication.Src.Shared
{
    public class ServiceException : Exception
    {
        public ServiceException(ErrorResponse error) : base(error.Message)
        {
            HelpLink = error.Code;
        }
    }
}
