using BankApplication.Src.Domain.Accounts;
using BankApplication.Src.Domain.Persons;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Src.Domain.Customers
{
    public class Customer : Person
    {
        [MaxLength(16)]
        public string Password { get; set; } = string.Empty;
        public bool State { get; set; }

        public ICollection<Account> Acounts { get; } = new List<Account>();
    }
}
