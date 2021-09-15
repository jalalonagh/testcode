using ManaRedis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using ServiceStack;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaRedis
{
    public static class Extensions
    {
        public static bool RedisPermissionChecker(this AuthorizationHandlerContext context, PermissionCheckerInput permission)
        {
            using (var connection = new RedisClient())
            {
                var permisions = new List<MR_Permission>();
                var bytes = connection.Get("PERMISSION");
                if (bytes != null && bytes.Any())
                {
                    var json = ASCIIEncoding.UTF8.GetString(bytes);
                    permisions = json.FromJson<List<MR_Permission>>();
                    var permited = permisions.Where(x => x.NavigationMenusControllerName == permission.controller.ToString() &&
                      x.NavigationMenusActionName == permission.action.ToString() && x.Permitted && permission.chairs.Select(x => x.Id).Contains(x.ChairsId)
                      && x.NavigationMenusDomain.ToLower() == permission.resource.Request.HttpContext.Request.Host.Value.ToLower()).Any();
                    if (permission.isAuthenticated && permited && permission.controller != null && permission.action != null)
                        return true;
                }
            }
            return false;
        }
    }
}
