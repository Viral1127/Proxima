using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

public class SwaggerFileOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters != null)
        {
            operation.Parameters.Clear(); // Remove default parameters
        }

        operation.RequestBody = new OpenApiRequestBody
        {
            Content = new Dictionary<string, OpenApiMediaType>
            {
                ["multipart/form-data"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = "object",
                        Properties = new Dictionary<string, OpenApiSchema>
                        {
                            ["file"] = new OpenApiSchema { Type = "string", Format = "binary" },
                            ["projectID"] = new OpenApiSchema { Type = "integer" },
                            ["fileName"] = new OpenApiSchema { Type = "string" },
                            ["fileType"] = new OpenApiSchema { Type = "string" },
                            ["uploadedBy"] = new OpenApiSchema { Type = "integer" }
                        },
                        Required = new HashSet<string> { "file", "projectID", "fileName", "fileType", "uploadedBy" }
                    }
                }
            }
        };
    }
}
