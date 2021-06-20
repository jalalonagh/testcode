using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Pluralize.NET;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace SwaggerApi.V5
{
    public class ApplySummariesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var controllerActionDescriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor == null) return;
            var pluralizer = new Pluralizer();
            var actionName = controllerActionDescriptor.ActionName;
            var singularizeName = pluralizer.Singularize(controllerActionDescriptor.ControllerName);
            var pluralizeName = pluralizer.Pluralize(singularizeName);
            var parameterCount = operation.Parameters.Where(p => p.Name != "version" && p.Name != "api-version").Count();
            operation = UpdateApiOperation(operation, pluralizeName, singularizeName, parameterCount, actionName);
            #region Local Functions
            #endregion
        }

        bool IsGetAllAction(string actionName, int parameterCount, string pluralizeName, string singularizeName)
        {
            foreach (var name in new[] { "Get", "Read", "Select" })
            {
                if ((actionName.Equals(name, StringComparison.OrdinalIgnoreCase) && parameterCount == 0) ||
                    actionName.Equals($"{name}All", StringComparison.OrdinalIgnoreCase) ||
                    actionName.Equals($"{name}{pluralizeName}", StringComparison.OrdinalIgnoreCase) ||
                    actionName.Equals($"{name}All{singularizeName}", StringComparison.OrdinalIgnoreCase) ||
                    actionName.Equals($"{name}All{pluralizeName}", StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        bool IsActionName(string actionName, string singularizeName, params string[] names)
        {
            foreach (var name in names)
            {
                if (actionName.Equals(name, StringComparison.OrdinalIgnoreCase) ||
                    actionName.Equals($"{name}ById", StringComparison.OrdinalIgnoreCase) ||
                    actionName.Equals($"{name}{singularizeName}", StringComparison.OrdinalIgnoreCase) ||
                    actionName.Equals($"{name}{singularizeName}ById", StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private OpenApiOperation UpdateApiOperation(OpenApiOperation operation, string pluralizeName, string singularizeName, int parameterCount, string actionName)
        {
            if (IsGetAllAction(actionName, parameterCount, pluralizeName, singularizeName))
                if (!string.IsNullOrEmpty(operation.Summary))
                    operation.Summary = $"Returns all {pluralizeName}";
                else if (IsActionName("Post", "Create"))
                {
                    if (!string.IsNullOrEmpty(operation.Summary))
                        operation.Summary = $"Creates a {singularizeName}";
                    if (!string.IsNullOrEmpty(operation.Parameters[0].Description))
                        operation.Parameters[0].Description = $"A {singularizeName} representation";
                }
                else if (IsActionName("Read", "Get"))
                {
                    if (!string.IsNullOrEmpty(operation.Summary))
                        operation.Summary = $"Retrieves a {singularizeName} by unique id";
                    if (!string.IsNullOrEmpty(operation.Parameters[0].Description))
                        operation.Parameters[0].Description = $"a unique id for the {singularizeName}";
                }
                else if (IsActionName("Put", "Edit", "Update"))
                {
                    if (!string.IsNullOrEmpty(operation.Summary))
                        operation.Summary = $"Updates a {singularizeName} by unique id";
                    if (!string.IsNullOrEmpty(operation.Parameters[0].Description))
                        operation.Parameters[0].Description = $"A {singularizeName} representation";
                }
                else if (IsActionName("Delete", "Remove"))
                {
                    if (!string.IsNullOrEmpty(operation.Summary))
                        operation.Summary = $"Deletes a {singularizeName} by unique id";
                    if (!string.IsNullOrEmpty(operation.Parameters[0].Description))
                        operation.Parameters[0].Description = $"A unique id for the {singularizeName}";
                }
            return operation;
        }
    }
}
