namespace BankApplication.Core.Contracts.Configuration
{
    public class VariableObject
    {
        public string Type { get; set; } = string.Empty;

        public List<BasicObject> Values { get; set; } = new List<BasicObject>();
    }
}
