﻿using System.Collections.Generic;

namespace MyApi.Models.Access
{
    public class MvcControllerInfo
    {
        public string Id => $"{AreaName}:{Name}";
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string AreaName { get; set; }
        public IEnumerable<MvcActionInfo> Actions { get; set; }
    }
}
