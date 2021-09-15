using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models.Access
{
    public static class MvcActionInfoExtensions
    {
        public static IEnumerable<NavigationMenu> ToNavigationMenus(this IEnumerable<MvcActionInfo> actions, string name, string area, string display)
        {
            if (actions == null || !actions.Any())
                return new List<NavigationMenu>();
            return actions.Select(x => new NavigationMenu
            {
                ActionName = x.Name,
                Name = x.DisplayName,
                Area = area,
                ControllerName = name,
                ParentNavigationMenu = new NavigationMenu
                {
                    ControllerName = name,
                    Name = display,
                    Area = area
                }
            });
        }
    }
}
