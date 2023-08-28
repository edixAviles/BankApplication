namespace BankApplication.Src.Contracts.Movements
{
    public class MovementsReportDto
    {
        public string Date { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string NumberAccount { get; set; } = string.Empty;
        public string TypeAccount { get; set; } = string.Empty;
        public double InitialBalance { get; set; }
        public double Value { get; set; }
        public double Balance { get; set; }
        public bool StateAccount { get; set; }
    }
}
