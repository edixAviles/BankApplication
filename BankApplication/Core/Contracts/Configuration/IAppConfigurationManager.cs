namespace BankApplication.Core.Contracts.Configuration
{
    public interface IAppConfigurationManager
    {
        string GetServiceUrlBySystemControllerCapability(string system, string controller, string capability);

        string GetVariableByTypeName(string type, string name);
    }
}
