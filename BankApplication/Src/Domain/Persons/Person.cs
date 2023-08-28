using BankApplication.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Src.Domain.Persons
{
    public class Person : BaseModel
    {
        [MaxLength(32)]
        public string Identification { get; set; } = string.Empty;
        [MaxLength(128)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(16)]
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        [MaxLength(256)]
        public string Address { get; set; } = string.Empty;
        [MaxLength(32)]
        public string Phone { get; set; } = string.Empty;
    }
}
