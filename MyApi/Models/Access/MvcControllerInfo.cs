using System.Collections.Generic;

namespace MyApi.Models.Access
{
    public class MvcControllerInfo
    {
        public string Id => $"{AreaName}:{Name}";
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string AreaName { get; set; }
        public IEnumerable<MvcActionInfo> Actions { get; set; }

        public MvcControllerInfo()
        {

        }

        public MvcControllerInfo(string name, string area)
        {
            AreaName = area;
            Name = name;
        }
        public MvcControllerInfo(string name, string area, string display)
        {
            AreaName = area;
            Name = name;
            DisplayName = display;
        }
        public MvcControllerInfo(string name, string area, string display, IEnumerable<MvcActionInfo> actions)
        {
            AreaName = area;
            Name = name;
            DisplayName = display;
            Actions = actions;
        }
    }
}
