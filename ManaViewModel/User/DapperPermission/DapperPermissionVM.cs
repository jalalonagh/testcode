using ManaViewModel.Common;

namespace ManaViewModel.User.DapperPermission
{
    public class DapperPermissionVM : BaseJsonVM<DapperPermissionVM, Entities.User.DapperPermission.DapperPermission>
    {
        public string NavigationMenusActionName { get; set; }
        public string NavigationMenusArea { get; set; }
        public string NavigationMenusControllerName { get; set; }
        public int? NavigationMenusDisplayOrder { get; set; }
        public string NavigationMenusDomain { get; set; }
        public string NavigationMenusExternalUrl { get; set; }
        public string NavigationMenusId { get; set; }
        public bool? NavigationMenusIsExternal { get; set; }
        public string NavigationMenusName { get; set; }
        public string NavigationMenusParentMenuId { get; set; }
        public bool? NavigationMenusVisible { get; set; }
        public string RolesDescription { get; set; }
        public string RolesNormalizedName { get; set; }
        public string ChairsName { get; set; }
        public int ChairsId { get; set; }
        public bool Permitted { get; set; }
        public string RolesName { get; set; }
        public int? RolesId { get; set; }
    }
}
