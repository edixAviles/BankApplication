using BankApplication.Core.Domain;
using BankApplication.Src.Domain.Accounts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApplication.Src.Domain.Movements
{
    public class Movement : BaseModel
    {
        public DateTime Date { get; set; }
        [MaxLength(16)]
        public string Type { get; set; } = string.Empty;
        public double InitialBalance { get; set; }
        public double Value { get; set; }
        public double Balance { get; set; }
        
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = null!;
    }
}
