using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSApp.API.Filters
{
    public class RemoveVersionFromParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters.Count > 0)
            {
                var versionParameter = operation.Parameters.SingleOrDefault(p => p.Name == "version");
                operation.Parameters.Remove(versionParameter);
            }
        }
    }

    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths;
            swaggerDoc.Paths = new OpenApiPaths();

            foreach (var path in paths)
            {
                var key = path.Key.Replace("v{version}", swaggerDoc.Info.Version);
                var value = path.Value;
                swaggerDoc.Paths.Add(key, value);
            }

        }
    }

    public class ControllerVisibility : IActionModelConvention
    {
        private readonly string[] VisibleControllers = { "Clients", "Users", "Enterings", "Exitings", "DevicesIPs" };
        public void Apply(ActionModel action)
        {
            action.ApiExplorer.IsVisible = VisibleControllers.Contains(action.Controller.ControllerName);
        }
    }

    public class RemoveSchemas : ISchemaFilter
    {
        private readonly string[] VisibleSchemas = { "ClientModel", "UserModel", "EnteringModel", "ExitingModel", "DevicesIPModel" };
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            foreach (var key in context.SchemaRepository.Schemas.Keys)
            {
                if (!VisibleSchemas.Contains(key))
                {
                    context.SchemaRepository.Schemas.Remove(key);
                }
            }
        }
    }

}
