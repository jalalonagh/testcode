using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ManaRedis.Models
{
    public class PermissionCheckerInput
    {
        public object? controller { get; set; }
        public object? action { get; set; }
        public bool isAuthenticated { get; set; }
        public DefaultHttpContext resource { get; set; }
        public List<MR_Chair> chairs { get; set; }

        public PermissionCheckerInput()
        {

        }

        public PermissionCheckerInput(object? _controler, object? _action, bool _auth, DefaultHttpContext _resource, List<MR_Chair> _chairs)
        {
            controller = _controler;
            action = _action;
            isAuthenticated = _auth;
            resource = _resource;
            chairs = _chairs;
        }
    }
}
