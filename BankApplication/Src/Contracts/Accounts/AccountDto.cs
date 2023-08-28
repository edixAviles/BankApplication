namespace BankApplication.Src.Contracts.Accounts
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public double InitialBalance { get; set; }
        public bool State { get; set; }
        public string Customer { get; set; } = string.Empty;
    }
}
