namespace BankApplication.Src.Contracts.Movements
{
    public class MovementDto
    {
        public Guid Id { get; set; }
        public string Account { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public double InitialBalance { get; set; }
        public double Value { get; set; }
        public double Balance { get; set; }
    }
}
