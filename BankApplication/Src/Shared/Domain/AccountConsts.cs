using BankApplication.Core.Response;
using System.Collections.ObjectModel;

namespace BankApplication.Src.Shared.Domain
{
    public static class AccountConsts
    {
        public const string SavingsAccount = "AHORRO";
        public const string CheckingAccount = "CORRIENTE";

        public static readonly IList<string> Types = new ReadOnlyCollection<string>(new[]
        {
            SavingsAccount, CheckingAccount
        });

        public static readonly AccuntError ErrorAccountTypeAccountNotValid = new("ERROR_ACCOUNT_TYPE_ACCOUNT_NOT_VALID", "El tipo de cuenta indicado no es válido");
        public static readonly AccuntError ErrorAccountNotExists = new("ERROR_ACCOUNT_NOT_EXISTS", "La cuenta buscada no existe");
    }

    public class AccuntError : ErrorResponse
    {
        public AccuntError(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
