using BankApplication.Core.Response;

namespace BankApplication.Src.Shared.Domain
{
    public class CustomerConsts
    {
        public static readonly CustomerError ErrorCustomerNotExists = new("ERROR_CUSTOMER_NOT_EXISTS", "El cliente buscado no existe");
    }

    public class CustomerError : ErrorResponse
    {
        public CustomerError(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
