namespace BankApplication.Core.Contracts.Configuration
{
    public class ControllerObject
    {
        public string Name { get; set; } = string.Empty;

        public List<BasicObject> Capabilities { get; set; } = new List<BasicObject>();
    }
}
