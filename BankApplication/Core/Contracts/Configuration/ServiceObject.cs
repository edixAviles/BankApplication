namespace BankApplication.Core.Contracts.Configuration
{
    public class ServiceObject
    {
        public string System { get; set; } = string.Empty;

        public List<ControllerObject> Controllers { get; set; } = new List<ControllerObject>();
    }
}
