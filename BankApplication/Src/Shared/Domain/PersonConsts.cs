using BankApplication.Core.Response;
using System.Collections.ObjectModel;

namespace BankApplication.Src.Shared.Domain
{
    public class PersonConsts
    {
        public static readonly IList<string> Genders = new ReadOnlyCollection<string>(new[]
        {
            "MASCULINO", "FEMENINO"
        });

        public static readonly AccuntError ErrorPersonIncorrectGender = new("ERROR_PERSON_INCORRECT_GENDER", "El género indicado no es válido");
    }

    public class PersonError : ErrorResponse
    {
        public PersonError(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
