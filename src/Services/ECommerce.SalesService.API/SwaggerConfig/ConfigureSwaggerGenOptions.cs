using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECommerce.SalesService.API.SwaggerConfig;

public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = "ECommerce Sales Service API",
            Version = description.ApiVersion.ToString(),
            Description = "API para gerenciamento de vendas e pedidos do e-commerce",
            Contact = new OpenApiContact
            {
                Name = "Sales Service Team",
                Email = "sales@ecommerce.com"
            }
        };

        if (description.IsDeprecated)
        {
            info.Description += " Esta versão da API foi descontinuada.";
        }

        return info;
    }
}