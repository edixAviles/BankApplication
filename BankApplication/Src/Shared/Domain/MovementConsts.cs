using BankApplication.Core.Response;
using System.Collections.ObjectModel;

namespace BankApplication.Src.Shared.Domain
{
    public static class MovementConsts
    {
        public const string Debit = "DEBITO";
        public const string Credit = "CREDITO";
        public static readonly IList<string> Types = new ReadOnlyCollection<string>(new[]
        {
            Debit, Credit
        });

        public static readonly MovementError ErrorMovementTypeMovementNotValid = new("ERROR_MOVEMENT_TYPE_MOVEMENT_NOT_VALID", "El tipo de moviemiento indicado no es válido");
        public static readonly MovementError ErrorMovementBalanceIsZero = new("ERROR_MOVEMENT_BALANCE_IS_ZERO", "Saldo no disponible");
        public static readonly MovementError ErrorMovementInsufficientBalance = new("ERROR_MOVEMENT_INSUFFICIENT_BALANCE", "Saldo insuficiente");
        public static readonly MovementError ErrorMovementNotExists = new("ERROR_MOVEMENT_NOT_EXISTS", "El movimiento buscado no existe");
    }

    public class MovementError : ErrorResponse
    {
        public MovementError(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
