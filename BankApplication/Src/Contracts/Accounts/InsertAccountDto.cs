using System.ComponentModel.DataAnnotations;

namespace BankApplication.Src.Contracts.Accounts
{
    public class InsertAccountDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número de cuenta es requerido")]
        public string Number { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "El tipo de cuenta es requerido")]
        public string Type { get; set; } = string.Empty;

        [Range(0.0, double.MaxValue, ErrorMessage = "El saldo inicial debe ser mayor o igual a 0")]
        public double InitialBalance { get; set; }

        public Guid CustomerId { get; set; }

    }
}
