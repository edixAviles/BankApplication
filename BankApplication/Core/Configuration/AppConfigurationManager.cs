using BankApplication.Core.Contracts.Configuration;

namespace BankApplication.Core.Configuration
{
    public class AppConfigurationManager : IAppConfigurationManager
    {
        private readonly AppConfigurationObject _appConfiguration;

        public AppConfigurationManager(IConfiguration configuration)
        {
            _appConfiguration = new AppConfigurationObject();
            configuration.GetSection("AppConfiguration").Bind(_appConfiguration);
        }

        public string GetServiceUrlBySystemControllerCapability(string system, string controller, string capability)
        {
            return _appConfiguration
                .Services.FirstOrDefault((ServiceObject s) => s.System == system)!
                .Controllers.FirstOrDefault((ControllerObject c) => c.Name == controller)!
                .Capabilities.FirstOrDefault((BasicObject c) => c.Name == capability)!
                .Value;
        }

        public string GetVariableByTypeName(string type, string name)
        {
            return _appConfiguration
                .Variables.FirstOrDefault((VariableObject s) => s.Type == type)!
                .Values.FirstOrDefault((BasicObject c) => c.Name == name)!
                .Value;
        }
    }
}
