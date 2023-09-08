using System.ComponentModel.DataAnnotations;

namespace BankApplication.Src.Contracts.Movements
{
    public class InsertMovementDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El tipo de movimiento es requerido ")]
        public string Type { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "El valor del movimiento debe ser mayor o igual a $0.01 ctvs")]
        public double Value { get; set; }

        public Guid AccountId { get; set; }
    }
}
