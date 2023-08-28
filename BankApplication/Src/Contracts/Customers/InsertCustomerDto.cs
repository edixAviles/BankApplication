using System.ComponentModel.DataAnnotations;

namespace BankApplication.Src.Contracts.Customers
{
    public class InsertCustomerDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "La identificación del cliente es requerida")]
        [StringLength(10)]
        public string Identification { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre del cliente es requerido")]
        public string Name { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "El género del cliente es requerido")]
        public string Gender { get; set; } = string.Empty;

        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La dirección del cliente es requerida")]
        public string Address { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "El teléfono del cliente es requerido")]
        public string Phone { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "La contraseña del cliente es requerida")]
        public string Password { get; set; } = string.Empty;
    }
}
