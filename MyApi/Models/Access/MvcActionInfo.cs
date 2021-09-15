namespace MyApi.Models.Access
{
    public class MvcActionInfo
    {
        public string Id => $"{ControllerId}:{Name}";
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string ControllerId { get; set; }

        public MvcActionInfo()
        {

        }

        public MvcActionInfo(string name, string controller, string display)
        {
            Name = name;
            ControllerId = controller;
            DisplayName = display;
        }
    }
}
