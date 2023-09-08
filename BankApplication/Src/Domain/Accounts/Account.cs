using BankApplication.Core.Domain;
using BankApplication.Src.Domain.Customers;
using BankApplication.Src.Domain.Movements;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Src.Domain.Accounts
{
    public class Account : BaseModel
    {
        [MaxLength(32)]
        public string Number { get; set; } = string.Empty;
        [MaxLength(16)]
        public string Type { get; set; } = string.Empty;
        public double InitialBalance { get; set; }
        public bool State { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public ICollection<Movement> Movements { get; } = new List<Movement>();
    }
}
