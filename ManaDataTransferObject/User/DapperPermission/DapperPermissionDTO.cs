using ManaDataTransferObject.Common;
using Newtonsoft.Json;

namespace ManaDataTransferObject.User.DapperPermission
{
    public class DapperPermissionDTO : BaseJsonDTO<DapperPermissionDTO, Entities.User.DapperPermission.DapperPermission, int>
    {
        [JsonProperty("NavigationMenusActionName")]
        public string MenusActionName { get; set; }
        [JsonProperty("NavigationMenusArea")]
        public string MenusArea { get; set; }
        [JsonProperty("NavigationMenusControllerName")]
        public string MenusControllerName { get; set; }
        [JsonProperty("NavigationMenusDisplayOrder")]
        public int? MenusDisplayOrder { get; set; }
        [JsonProperty("NavigationMenusDomain")]
        public string MenusDomain { get; set; }
        [JsonProperty("NavigationMenusExternalUrl")]
        public string MenusExternalUrl { get; set; }
        [JsonProperty("NavigationMenusId")]
        public string MenusId { get; set; }
        [JsonProperty("NavigationMenusIsExternal")]
        public bool? MenusIsExternal { get; set; }
        [JsonProperty("NavigationMenusName")]
        public string MenusName { get; set; }
        [JsonProperty("NavigationMenusParentMenuId")]
        public string MenusParentMenuId { get; set; }
        [JsonProperty("NavigationMenusVisible")]
        public bool? MenusVisible { get; set; }
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
