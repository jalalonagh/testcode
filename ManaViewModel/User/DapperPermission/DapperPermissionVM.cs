using ManaViewModel.Common;
using Newtonsoft.Json;

namespace ManaViewModel.User.DapperPermission
{
    public class DapperPermissionVM : BaseJsonVM<DapperPermissionVM, Entities.User.DapperPermission.DapperPermission, int>
    {
        [JsonProperty("NavigationMenusActionName")]
        public string ActionName { get; set; }
        [JsonProperty("NavigationMenusArea")]
        public string Area { get; set; }
        [JsonProperty("NavigationMenusControllerName")]
        public string ControllerName { get; set; }
        [JsonProperty("NavigationMenusDisplayOrder")]
        public int? DisplayOrder { get; set; }
        [JsonProperty("NavigationMenusDomain")]
        public string Domain { get; set; }
        [JsonProperty("NavigationMenusExternalUrl")]
        public string ExternalUrl { get; set; }
        [JsonProperty("NavigationMenusId")]
        public string MenuId { get; set; }
        [JsonProperty("NavigationMenusIsExternal")]
        public bool? IsExternal { get; set; }
        [JsonProperty("NavigationMenusName")]
        public string Name { get; set; }
        [JsonProperty("NavigationMenusParentMenuId")]
        public string ParentMenuId { get; set; }
        [JsonProperty("NavigationMenusVisible")]
        public bool? Visible { get; set; }
        [JsonProperty("RolesDescription")]
        public string Description { get; set; }
        [JsonProperty("RolesNormalizedName")]
        public string NormalizedName { get; set; }
        [JsonProperty("ChairsName")]
        public string Chairs { get; set; }
        [JsonProperty("ChairsId")]
        public int ChairsId { get; set; }
        [JsonProperty("Permitted")]
        public bool Permitted { get; set; }
        [JsonProperty("RolesName")]
        public string Roles { get; set; }
        [JsonProperty("RolesId")]
        public int? RolesId { get; set; }
    }
}
