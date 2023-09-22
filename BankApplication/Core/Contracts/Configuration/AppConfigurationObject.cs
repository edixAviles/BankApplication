namespace BankApplication.Core.Contracts.Configuration
{
    public class AppConfigurationObject
    {
        public List<ServiceObject> Services { get; set; } = new List<ServiceObject>();

        public List<VariableObject> Variables { get; set; } = new List<VariableObject>();
    }
}
